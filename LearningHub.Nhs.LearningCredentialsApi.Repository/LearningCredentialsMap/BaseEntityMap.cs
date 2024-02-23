// <copyright file="BaseEntityMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap
{
    using LearningHub.Nhs.LearningCredentials.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The base entity map.
    /// </summary>
    /// <typeparam name="TEntityType">Input type.</typeparam>
    public abstract class BaseEntityMap<TEntityType> : IEntityTypeMap
       where TEntityType : EntityBase
    {
        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Map(ModelBuilder builder)
        {
            builder.Entity<TEntityType>().Property(e => e.AmendDate).HasColumnName("AmendDate");

            builder.Entity<TEntityType>().Property(e => e.AmendUserId).HasColumnName("AmendUserId");

            this.InternalMap(builder.Entity<TEntityType>());
        }

        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected abstract void InternalMap(EntityTypeBuilder<TEntityType> builder);
    }
}