// <copyright file="VerifiableCredentialController.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Controllers
{
    using LearningHub.Nhs.LearningCredentials.Models.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using LearningHub.Nhs.Models.Common;
    using LearningHub.Nhs.Models.Validation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Api for interacting with verifiable credential entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VerifiableCredentialController : ApiControllerBase
    {
        private readonly IVerifiableCredentialService verifiableCredentialService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VerifiableCredentialController"/> class.
        /// </summary>
        /// <param name="userProfileService">The user profile service.</param>
        /// <param name="verifiableCredentialService">The verifiable credential system service.</param>
        public VerifiableCredentialController(
            IUserProfileService userProfileService,
            IVerifiableCredentialService verifiableCredentialService)
            : base(userProfileService)
        {
            this.verifiableCredentialService = verifiableCredentialService;
        }

        /// <summary>
        /// Gets a verifiable credential.
        /// </summary>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The verifiable credential.</returns>
        [HttpGet]
        [Route("GetById/{verifiableCredentialId}")]
        public ActionResult<VerifiableCredentialResponse> GetById(int verifiableCredentialId)
        {
            var userVerifiableCredentials = this.verifiableCredentialService.GetById(verifiableCredentialId);

            return this.Ok(userVerifiableCredentials);
        }

        /// <summary>
        /// The verifiable credentials list.
        /// </summary>
        /// <returns>The verifiable credentials.</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<VerifiableCredentialResponse>> GetAll()
        {
            var userVerifiableCredentials = this.verifiableCredentialService.GetAll();

            return this.Ok(userVerifiableCredentials);
        }

        /// <summary>
        /// The list of verifiable credentials.
        /// </summary>
        /// <param name="userVerifiableCredentialId">The user verifiable credential id.</param>
        /// <returns>The verifiable credentials.</returns>
        [HttpGet]
        [Route("GetUserVerifiableCredentialById/{userVerifiableCredentialId}")]
        public ActionResult<UserVerifiableCredentialResponse> GetUserVerifiableCredentialById(int userVerifiableCredentialId)
        {
            var userVerifiableCredential = this.verifiableCredentialService.GetUserVerifiableCredentialById(userVerifiableCredentialId);

            return this.Ok(userVerifiableCredential);
        }

        /// <summary>
        /// The list of verifiable credentials.
        /// </summary>
        /// <returns>The verifiable credentials.</returns>
        [HttpGet]
        [Route("GetSummaryForCurrentUser")]
        public async Task<ActionResult<List<UserVerifiableCredentialResponse>>> GetSummaryForCurrentUser()
        {
            var userVerifiableCredentials = await this.verifiableCredentialService.GetSummaryForUser(this.CurrentUserId);

            return this.Ok(userVerifiableCredentials);
        }

        /// <summary>
        /// The list of verifiable credentials.
        /// </summary>
        /// <returns>The verifiable credentials.</returns>
        [HttpGet]
        [Route("GetForCurrentUser")]
        public async Task<ActionResult<List<UserVerifiableCredentialResponse>>> GetForCurrentUser()
        {
            var userVerifiableCredentials = await this.verifiableCredentialService.GetForUser(this.CurrentUserId);

            return this.Ok(userVerifiableCredentials);
        }

        /// <summary>
        /// The list of verifiable credentials filetered by verifiable credential id.
        /// </summary>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The verifiable credentials.</returns>
        [HttpGet]
        [Route("GetCurrentUserVerifiableCredentialsById/{verifiableCredentialId}")]
        public ActionResult<List<UserVerifiableCredentialResponse>> GetCurrentUserVerifiableCredentialsById(int verifiableCredentialId)
        {
            var userVerifiableCredentials = this.verifiableCredentialService.GetUserVerifiableCredentialsByUserAndId(this.CurrentUserId, verifiableCredentialId);

            return this.Ok(userVerifiableCredentials);
        }

        /// <summary>
        /// Return the client system credential for a user.
        /// </summary>
        /// <param name="verifiableCredentialId">The verifiable credential id.</param>
        /// <returns>The client system credential.</returns>
        [HttpGet]
        [Route("GetClientSystemCredentialForCurrentUser/{verifiableCredentialId}")]
        public async Task<ActionResult<ClientSystemCredentialResult>> GetClientSystemCredentialForCurrentUser(int verifiableCredentialId)
        {
            var userClientCredential = await this.verifiableCredentialService.GetClientSystemCredentialForUser(this.CurrentUserId, verifiableCredentialId);

            return this.Ok(userClientCredential);
        }

        /// <summary>
        /// The create verifiable credential method.
        /// </summary>
        /// <param name="userVerifiableCredentialRequest">The new user verifiable credential.</param>
        /// <returns>The verifiable credentials.</returns>
        [HttpPost]
        [Route("CreateForUser")]
        public async Task<ActionResult> CreateForUser(UserVerifiableCredentialRequest userVerifiableCredentialRequest)
        {
            try
            {
                var vr = await this.verifiableCredentialService.CreateUserVerifiableCredentialAsync(this.CurrentUserId, userVerifiableCredentialRequest);
                return this.Ok(new ApiResponse(true, vr));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(false, new LearningHubValidationResult(false, ex.Message)));
            }
        }

        /// <summary>
        /// The update verifiable credential method.
        /// </summary>
        /// <param name="userVerifiableCredentialRequest">The new user verifiable credential.</param>
        /// <returns>The verifiable credentials.</returns>
        [HttpPut]
        [Route("UpdateForUser")]
        public async Task<ActionResult> UpdateForUser(UserVerifiableCredentialRequest userVerifiableCredentialRequest)
        {
            try
            {
                var vr = await this.verifiableCredentialService.UpdateUserVerifiableCredentialAsync(this.CurrentUserId, userVerifiableCredentialRequest);
                return this.Ok(new ApiResponse(true, vr));
            }
            catch (Exception ex)
            {
                return this.Ok(new ApiResponse(false, new LearningHubValidationResult(false, ex.Message)));
            }
        }
    }
}
