// <copyright file="ClientSystemRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.System;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class ClientSystemRepository : GenericRepository<ClientSystem>, IClientSystemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSystemRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public ClientSystemRepository(LearningCredentialsDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }
    }
}