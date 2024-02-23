// <copyright file="IClientSystemService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service.Interface
{
    using LearningHub.Nhs.LearningCredentials.Models.System;

    /// <summary>
    /// Definition the Client System Service interface.
    /// </summary>
    public interface IClientSystemService
    {
        /// <summary>
        /// Get all the client systems.
        /// </summary>
        /// <returns>The client system list.</returns>
        List<ClientSystemResponse> GetAll();
    }
}
