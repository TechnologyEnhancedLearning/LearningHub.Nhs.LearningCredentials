// <copyright file="ClientSystemMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The user profile map.
    /// </summary>
    public partial class ClientSystemMap : BaseEntityMap<ClientSystem>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<ClientSystem> modelBuilder)
        {
            modelBuilder.ToTable("ClientSystem", "system");

            modelBuilder.Property(e => e.Id).ValueGeneratedNever();

            modelBuilder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}