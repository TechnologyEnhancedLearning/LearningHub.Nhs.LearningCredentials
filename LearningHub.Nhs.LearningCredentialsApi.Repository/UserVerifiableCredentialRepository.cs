// <copyright file="UserVerifiableCredentialRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using LearningHub.Nhs.LearningCredentials.Models.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserVerifiableCredentialRepository : GenericRepository<UserVerifiableCredential>, IUserVerifiableCredentialRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserVerifiableCredentialRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public UserVerifiableCredentialRepository(LearningCredentialsDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }

        /// <inheritdoc/>
        public UserVerifiableCredential GetById(int userVerifiableCredentialId)
        {
            var userVerifiableCredential = this.DbContext.Set<UserVerifiableCredential>()
                .Include(uvc => uvc.VerifiableCredential)
                .Where(uvc => uvc.Id == userVerifiableCredentialId && !uvc.Deleted)
                .FirstOrDefault();
            return userVerifiableCredential!;
        }

        /// <inheritdoc/>
        public List<UserVerifiableCredential> GetAllForUserAsync(int userId)
        {
            var returnData = this.DbContext.Set<UserVerifiableCredential>()
                .Include(uvc => uvc.VerifiableCredential)
                .Where(uvc => uvc.UserId == userId && !uvc.Deleted)
                .ToList();

            return returnData;
        }
    }
}