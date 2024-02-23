// <copyright file="IVerifiableCredentialService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service.Interface
{
    using System.Threading.Tasks;
    using LearningHub.Nhs.LearningCredentials.Models.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.Models.Validation;

    /// <summary>
    /// Definition of the Verifiable Credential Service interface.
    /// </summary>
    public interface IVerifiableCredentialService
    {
        /// <summary>
        /// Creates a new user verifiable credentials.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userVerifiableCredentialRequest">The new user verifiable credential.</param>
        /// <returns>The verifiable credential list.</returns>
        Task<LearningHubValidationResult> CreateUserVerifiableCredentialAsync(int userId, UserVerifiableCredentialRequest userVerifiableCredentialRequest);

        /// <summary>
        /// Update a user verifiable credentials.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userVerifiableCredentialRequest">The new user verifiable credential.</param>
        /// <returns>The verifiable credential list.</returns>
        Task<LearningHubValidationResult> UpdateUserVerifiableCredentialAsync(int userId, UserVerifiableCredentialRequest userVerifiableCredentialRequest);

        /// <summary>
        /// Get a verifiable credentials by id.
        /// </summary>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The verifiable credential list.</returns>
        VerifiableCredentialResponse GetById(int verifiableCredentialId);

        /// <summary>
        /// Get all the verifiable credentials.
        /// </summary>
        /// <returns>The verifiable credential list.</returns>
        List<VerifiableCredentialResponse> GetAll();

        /// <summary>
        /// Get verifiable credentials summary for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The verifiable credential list summary.</returns>
        Task<List<UserVerifiableCredentialResponse>> GetSummaryForUser(int userId);

        /// <summary>
        /// Get verifiable credentials for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The verifiable credential list.</returns>
        List<UserVerifiableCredentialResponse> GetUserVerifiableCredentialsByUserAndId(int userId, int verifiableCredentialId);

        /// <summary>
        /// Gets a user verifiable credential by id.
        /// </summary>
        /// <param name="userVerifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The user verifiable credential.</returns>
        UserVerifiableCredentialResponse GetUserVerifiableCredentialById(int userVerifiableCredentialId);

        /// <summary>
        /// Gets a client system credential.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The client system credential.</returns>
        Task<ClientSystemCredentialResult> GetClientSystemCredentialForUser(int userId, int verifiableCredentialId);

        /// <summary>
        /// Get verifiable credentials for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The verifiable credential list.</returns>
        Task<List<UserVerifiableCredentialResponse>> GetForUser(int userId);
    }
}
