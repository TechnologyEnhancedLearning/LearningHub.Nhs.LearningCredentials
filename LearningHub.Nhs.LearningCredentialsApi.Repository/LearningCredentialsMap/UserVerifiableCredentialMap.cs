// <copyright file="UserVerifiableCredentialMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The user verifiable credential map.
    /// </summary>
    public partial class UserVerifiableCredentialMap : BaseEntityMap<UserVerifiableCredential>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<UserVerifiableCredential> modelBuilder)
        {
            modelBuilder.ToTable("UserVerifiableCredential", "dsp");

            modelBuilder.HasOne(d => d.User)
                .WithMany(p => p.UserVerifiableCredentials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserVerifiableCredential_UserProfile");

            modelBuilder.HasOne(d => d.VerifiableCredential)
                .WithMany(p => p.UserVerifiableCredentials)
                .HasForeignKey(d => d.VerifiableCredentialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserVerifiableCredential_VerifiableCredential");
        }
    }
}
