// <copyright file="IUserVerifiableCredentialRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Interface
{
    using LearningHub.Nhs.LearningCredentials.Models.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;

    /// <summary>
    /// The Verifiable Credential interface.
    /// </summary>
    public interface IUserVerifiableCredentialRepository : IGenericRepository<UserVerifiableCredential>
    {
        /// <summary>
        /// Get the user verifiable credential by id.
        /// </summary>
        /// <param name="userVerifiableCredentialId">The verifiable credention id.</param>
        /// <returns>The verifiable credential.</returns>
        UserVerifiableCredential GetById(int userVerifiableCredentialId);

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        List<UserVerifiableCredential> GetAllForUserAsync(int userId);
    }
}