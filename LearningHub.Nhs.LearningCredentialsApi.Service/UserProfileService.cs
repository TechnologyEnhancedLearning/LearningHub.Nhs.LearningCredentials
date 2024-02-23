// <copyright file="UserProfileService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service
{
    using System.Threading.Tasks;
    using AutoMapper;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.User;
    using LearningHub.Nhs.LearningCredentials.Models.User;
    using LearningHub.Nhs.LearningCredentials.Models.Validation;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using lhModelsValidation = LearningHub.Nhs.Models.Validation;

    /// <summary>
    /// Definition of the User Profile Service.
    /// </summary>
    public class UserProfileService : IUserProfileService
    {
        private readonly IMapper mapper;
        private readonly IUserProfileRepository userProfileRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileService"/> class.
        /// </summary>
        /// <param name="userProfileRepository">The user profile repository.</param>
        /// <param name="mapper">The mapper.</param>
        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            this.userProfileRepository = userProfileRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserProfileResponse> GetBasicUserByIdAsync(int id)
        {
            var user = await this.userProfileRepository.GetByIdAsync(id);
            return this.mapper.Map<UserProfileResponse>(user);
        }

        /// <inheritdoc/>
        public async Task<lhModelsValidation.LearningHubValidationResult> CreateUserAsync(int userId, UserProfileRequest userProfileRequest)
        {
            var userProfile = this.mapper.Map<UserProfile>(userProfileRequest);

            var retVal = await this.ValidateAsync(userProfile);

            if (retVal.IsValid)
            {
                retVal.CreatedId = await this.userProfileRepository.CreateAsync(userId, userProfile);
            }

            return retVal;
        }

        /// <inheritdoc/>
        public async Task<lhModelsValidation.LearningHubValidationResult> UpdateUserAsync(int userId, UserProfileRequest userProfileRequest)
        {
            var userProfile = this.mapper.Map<UserProfile>(userProfileRequest);

            var retVal = await this.ValidateAsync(userProfile);

            if (retVal.IsValid)
            {
                await this.userProfileRepository.UpdateAsync(userId, userProfile);
                retVal.CreatedId = userProfileRequest.Id;
            }

            return retVal;
        }

        private async Task<lhModelsValidation.LearningHubValidationResult> ValidateAsync(UserProfile userProfile)
        {
            var notificationValidator = new UserProfileValidator();
            var clientValidationResult = await notificationValidator.ValidateAsync(userProfile);

            var retVal = new lhModelsValidation.LearningHubValidationResult(clientValidationResult);

            return retVal;
        }
    }
}
