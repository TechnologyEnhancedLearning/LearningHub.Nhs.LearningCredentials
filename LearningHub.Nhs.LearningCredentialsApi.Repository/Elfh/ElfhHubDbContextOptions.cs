﻿// <copyright file="ElfhHubDbContextOptions.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Elfh
{
    using System.Collections.Generic;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Elfh.ElfhMap;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The elfh hub db context options.
    /// </summary>
    public class ElfhHubDbContextOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfhHubDbContextOptions"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="mappings">The mappings.</param>
        public ElfhHubDbContextOptions(DbContextOptions<ElfhHubDbContext> options, IEnumerable<IEntityTypeMap> mappings)
        {
            this.Options = options;
            this.Mappings = mappings;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public DbContextOptions<ElfhHubDbContext> Options { get; }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        public IEnumerable<IEntityTypeMap> Mappings { get; }
    }
}