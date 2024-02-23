// <copyright file="UserController.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Controllers
{
    using LearningHub.Nhs.LearningCredentials.Models.User;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using LearningHub.Nhs.Models.Common;
    using LearningHub.Nhs.Models.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Api for interacting with user entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userProfileService">The user profile service.</param>
        public UserController(IUserProfileService userProfileService)
             : base(userProfileService)
        {
        }

        /// <summary>
        /// The get basic user by user id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="UserProfileResponse"/>.</returns>
        [HttpGet]
        [Route("GetBasicByUserId/{id}")]
        public async Task<ActionResult<UserProfileResponse>> GetBasicByUserId(int id)
        {
            var basicUser = await this.UserProfileService.GetBasicUserByIdAsync(id);

            return this.Ok(basicUser);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="userCreateViewModel">
        /// The userCreateViewModel.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUserAsync(UserProfileRequest userCreateViewModel)
        {
            var vr = await this.UserProfileService.CreateUserAsync(this.CurrentUserId, userCreateViewModel);

            if (vr.IsValid)
            {
                return this.Ok(new ApiResponse(true, vr));
            }
            else
            {
                return this.BadRequest(new ApiResponse(false, vr));
            }
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="userUpdateViewModel">
        /// The userCreateViewModel.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync(UserProfileRequest userUpdateViewModel)
        {
            var vr = await this.UserProfileService.UpdateUserAsync(this.CurrentUserId, userUpdateViewModel);

            if (vr.IsValid)
            {
                return this.Ok(new ApiResponse(true, vr));
            }
            else
            {
                return this.BadRequest(new ApiResponse(false, vr));
            }
        }
    }
}
