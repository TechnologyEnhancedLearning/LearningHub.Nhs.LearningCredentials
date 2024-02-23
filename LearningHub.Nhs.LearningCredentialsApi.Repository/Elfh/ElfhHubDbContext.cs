// <copyright file="ElfhHubDbContext.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Elfh
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The elfh hub db context.
    /// </summary>
    public partial class ElfhHubDbContext : DbContext
    {
        private readonly ElfhHubDbContextOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElfhHubDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ElfhHubDbContext(ElfhHubDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        /// <summary>
        /// Gets or sets the client system credential result.
        /// </summary>
        public virtual DbSet<ClientSystemCredentialResult> ClientSystemCredentialResult { get; set; } = null!;

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
