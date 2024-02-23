// <copyright file="VerifiableCredentialRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class VerifiableCredentialRepository : GenericRepository<VerifiableCredential>, IVerifiableCredentialRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerifiableCredentialRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public VerifiableCredentialRepository(LearningCredentialsDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }

        /// <inheritdoc/>
        public List<VerifiableCredential> GetAllWithClientSystem()
        {
            return this.DbContext.Set<VerifiableCredential>()
                                 .Include(vc => vc.ClientSystem)
                                 .ToList();
        }
    }
}