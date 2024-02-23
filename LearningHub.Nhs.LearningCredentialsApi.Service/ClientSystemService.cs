// <copyright file="ClientSystemService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service
{
    using AutoMapper;
    using LearningHub.Nhs.LearningCredentials.Models.System;
    using LearningHub.Nhs.LearningCredentials.Models.User;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;

    /// <summary>
    /// Definition of the Client System Service.
    /// </summary>
    public class ClientSystemService : IClientSystemService
    {
        private readonly IMapper mapper;
        private readonly IClientSystemRepository clientSystemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSystemService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="clientSystemRepository">The client system repository.</param>
        public ClientSystemService(IMapper mapper, IClientSystemRepository clientSystemRepository)
        {
            this.mapper = mapper;
            this.clientSystemRepository = clientSystemRepository;
        }

        /// <inheritdoc/>
        public List<ClientSystemResponse> GetAll()
        {
            var clientSystemList = this.clientSystemRepository.GetAll()
                .ToList();

            return this.mapper.Map<List<ClientSystemResponse>>(clientSystemList);
        }
    }
}
