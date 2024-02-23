// <copyright file="LearningCredentialsDbContext.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.System;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.User;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The learning credentials db context.
    /// </summary>
    public partial class LearningCredentialsDbContext : DbContext
    {
        private readonly LearningCredentialsDbContextOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="LearningCredentialsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public LearningCredentialsDbContext(LearningCredentialsDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        /// <summary>
        /// Gets or sets the client system.
        /// </summary>
        public virtual DbSet<ClientSystem> ClientSystem { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        public virtual DbSet<UserProfile> UserProfile { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user verifiable credential status.
        /// </summary>
        public virtual DbSet<UserVerifiableCredentialStatus> UserVerifiableCredentialStatus { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user verifiable credential.
        /// </summary>
        public virtual DbSet<UserVerifiableCredential> UserVerifiableCredential { get; set; } = null!;

        /// <summary>
        /// Gets or sets the verifiable credential.
        /// </summary>
        public virtual DbSet<VerifiableCredential> VerifiableCredential { get; set; } = null!;

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mapping in this.options.Mappings)
            {
                mapping.Map(modelBuilder);
            }
        }
    }
}
