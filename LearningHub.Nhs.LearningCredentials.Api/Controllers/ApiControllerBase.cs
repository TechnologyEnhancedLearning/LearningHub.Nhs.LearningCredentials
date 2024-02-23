// <copyright file="ApiControllerBase.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Controllers
{
    using System.Threading.Tasks;
    using LearningHub.Nhs.LearningCredentials.Models.User;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using LearningHub.Nhs.Models.Extensions;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The api elfh controller base.
    /// </summary>
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// The current user.
        /// </summary>
        private UserProfileResponse currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase"/> class.
        /// </summary>
        /// <param name="userService">
        /// The user service.
        /// </param>
        protected ApiControllerBase(IUserProfileService userService)
        {
            this.UserProfileService = userService;
            this.currentUser = new UserProfileResponse();
        }

        /// <summary>
        /// Gets the current user id.
        /// </summary>
        public int CurrentUserId
        {
            get
            {
                var currentUserId = this.User.Identity.GetCurrentUserId();
                return currentUserId;
            }
        }

        /// <summary>
        /// Gets the elfh user service.
        /// </summary>
        protected IUserProfileService UserProfileService { get; }

        /// <summary>
        /// The get current user async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        internal async Task<UserProfileResponse> GetCurrentUserAsync()
        {
            if (this.currentUser == null || this.currentUser.Id == 0)
            {
                this.currentUser = await this.UserProfileService.GetBasicUserByIdAsync(this.CurrentUserId);
                this.HttpContext.User.Identity.GetCurrentUserId();
            }

            return this.currentUser;
        }
    }
}