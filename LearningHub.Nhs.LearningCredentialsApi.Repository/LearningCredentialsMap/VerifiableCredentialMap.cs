// <copyright file="VerifiableCredentialMap.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.LearningCredentialsMap
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The verifiable credential map.
    /// </summary>
    public partial class VerifiableCredentialMap : BaseEntityMap<VerifiableCredential>
    {
        /// <summary>
        /// The internal map.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void InternalMap(EntityTypeBuilder<VerifiableCredential> modelBuilder)
        {
            modelBuilder.ToTable("VerifiableCredential", "dsp");

            modelBuilder.Property(e => e.CredentialName).HasMaxLength(50);

            modelBuilder.HasOne(d => d.ClientSystem)
                .WithMany(p => p.VerifiableCredentials)
                .HasForeignKey(d => d.ClientSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VerifiableCredential_ClientSystem");
        }
    }
}
