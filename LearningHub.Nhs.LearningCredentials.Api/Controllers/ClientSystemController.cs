// <copyright file="ClientSystemController.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Controllers
{
    using LearningHub.Nhs.LearningCredentials.Models.System;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Api for interacting with user entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientSystemController : ControllerBase
    {
        private readonly IClientSystemService clientSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSystemController"/> class.
        /// </summary>
        /// <param name="clientSystemService">The client system service.</param>
        public ClientSystemController(IClientSystemService clientSystemService)
        {
            this.clientSystemService = clientSystemService;
        }

        /// <summary>
        /// The list of client systems.
        /// </summary>
        /// <returns>The client systems.</returns>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<ClientSystemResponse>> GetAll()
        {
            var clientSystems = this.clientSystemService.GetAll();

            return this.Ok(clientSystems);
        }
    }
}
