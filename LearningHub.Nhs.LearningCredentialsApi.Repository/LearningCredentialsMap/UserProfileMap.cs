// <copyright file="UserProfileMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.User;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The user profile map.
    /// </summary>
    public partial class UserProfileMap : BaseEntityMap<UserProfile>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<UserProfile> modelBuilder)
        {
            modelBuilder.ToTable("UserProfile", "user");

            ////modelBuilder.Property(e => e.Id).HasColumnName("Id");

            modelBuilder.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("userName")
                .HasMaxLength(50);
        }
    }
}