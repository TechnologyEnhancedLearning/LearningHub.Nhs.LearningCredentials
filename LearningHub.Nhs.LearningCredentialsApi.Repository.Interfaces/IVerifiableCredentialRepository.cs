// <copyright file="IVerifiableCredentialRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Interface
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;

    /// <summary>
    /// The Verifiable Credential interface.
    /// </summary>
    public interface IVerifiableCredentialRepository : IGenericRepository<VerifiableCredential>
    {
        /// <summary>
        /// Returns verifiable credentials with clinet sustem details.
        /// </summary>
        /// <returns>Verifiable credentials.</returns>
        public List<VerifiableCredential> GetAllWithClientSystem();
    }
}