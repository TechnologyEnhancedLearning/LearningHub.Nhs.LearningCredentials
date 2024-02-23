// <copyright file="IUserProfileService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service.Interface
{
    using LearningHub.Nhs.LearningCredentials.Models.User;
    using LearningHub.Nhs.Models.Validation;

    /// <summary>
    /// Definition of the User Profile Service interface.
    /// </summary>
    public interface IUserProfileService
    {
        /// <summary>
        /// Get basic user by user id.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<UserProfileResponse> GetBasicUserByIdAsync(int id);

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <param name="userCreateViewModel">The userCreateViewModel.</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<LearningHubValidationResult> CreateUserAsync(int userId, UserProfileRequest userCreateViewModel);

        /// <summary>
        /// Update the lh user async.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userUpdateViewModel">The userUpdate ViewModel.</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<LearningHubValidationResult> UpdateUserAsync(int userId, UserProfileRequest userUpdateViewModel);
    }
}
