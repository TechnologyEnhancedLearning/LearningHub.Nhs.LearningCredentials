// <copyright file="LearningCredentialsDbContextOptions.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using System.Collections.Generic;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The Learning Credentials db context options.
    /// </summary>
    public class LearningCredentialsDbContextOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LearningCredentialsDbContextOptions"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mappings">The mappings.</param>
        public LearningCredentialsDbContextOptions(DbContextOptions<LearningCredentialsDbContext> options, IEnumerable<IEntityTypeMap> mappings)
        {
            this.Options = options;
            this.Mappings = mappings;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public DbContextOptions<LearningCredentialsDbContext> Options { get; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        public IEnumerable<IEntityTypeMap> Mappings { get; }
    }
}