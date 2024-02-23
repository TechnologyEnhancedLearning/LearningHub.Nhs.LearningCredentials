// <copyright file="IElfhActivityRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Interface.Elfh
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;

    /// <summary>
    /// The elfh activity repository interface.
    /// </summary>
    public interface IElfhActivityRepository
    {
        /// <summary>
        /// The get client system verifiable credentials by user id async.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="componentIds">The component ids.</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<ClientSystemCredentialResult>> GetClientSystemCredentialsForUserAsync(int userId, string componentIds);
    }
}
