// <copyright file="ServiceMappings.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi
{
    using AutoMapper;
    using IdentityServer4.AccessTokenValidation;
    using LearningHub.Nhs.LearningCredentials.Models.Automapper;
    using LearningHub.Nhs.LearningCredentialsApi.Authentication;
    using LearningHub.Nhs.LearningCredentialsApi.Repository;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Elfh;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface.Elfh;
    using LearningHub.Nhs.LearningCredentialsApi.Service;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

    /// <summary>
    /// Extension class for <see cref="IServiceCollection"/> service mappings.
    /// </summary>
    public static class ServiceMappings
    {
        /// <summary>
        /// The add mappings.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddMappings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbMappings(configuration);
            services.AddElfhDBMappings(configuration);
            services.AddServices(configuration);
            services.AddAuthentication(configuration);
            services.AddAutomapper();
        }

        private static void AddDbMappings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new DbContextOptionsBuilder<LearningCredentialsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("LearningCredentialsDbConnection"), opt => opt.CommandTimeout(120)).Options);

            services.AddSingleton<LearningCredentialsDbContextOptions>();

            services.AddDbContext<LearningCredentialsDbContext>();

            services.AddSingleton<Repository.LearningCredentialsMap.IEntityTypeMap, Repository.LearningCredentialsMap.ClientSystemMap>();
            services.AddSingleton<Repository.LearningCredentialsMap.IEntityTypeMap, Repository.LearningCredentialsMap.UserProfileMap>();
            services.AddSingleton<Repository.LearningCredentialsMap.IEntityTypeMap, Repository.LearningCredentialsMap.UserVerifiableCredentialMap>();
            services.AddSingleton<Repository.LearningCredentialsMap.IEntityTypeMap, Repository.LearningCredentialsMap.VerifiableCredentialMap>();

            services.AddScoped<IClientSystemRepository, ClientSystemRepository>();
            services.AddScoped<ITimezoneOffsetManager, TimezoneOffsetManager>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserVerifiableCredentialRepository, UserVerifiableCredentialRepository>();
            services.AddScoped<IVerifiableCredentialRepository, VerifiableCredentialRepository>();
        }

        private static void AddElfhDBMappings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new DbContextOptionsBuilder<ElfhHubDbContext>()
                .UseSqlServer(configuration.GetConnectionString("ElfhHubDbConnection"), opt => opt.CommandTimeout(120)).Options);

            services.AddSingleton<ElfhHubDbContextOptions>();

            services.AddDbContext<ElfhHubDbContext>();

            services.AddScoped<IElfhActivityRepository, ElfhActivityRepository>();
        }

        private static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientSystemService, ClientSystemService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IVerifiableCredentialService, VerifiableCredentialService>();
        }

        private static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = configuration.GetValue<string>("Settings:AuthenticationServiceUrl");
                  options.ApiName = "learningcredentialsapi";
              });

            services.AddSingleton<IAuthorizationHandler, AuthorizeOrCallFromLHHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthorizeOrCallFromLH", policy => policy.Requirements.Add(new AuthorizeOrCallFromLHRequirement()));
            });
        }

        private static void AddAutomapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper());
        }
    }
}