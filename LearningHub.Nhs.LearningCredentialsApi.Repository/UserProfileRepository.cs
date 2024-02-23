// <copyright file="UserProfileRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository
{
    using System.Threading.Tasks;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.User;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="tzOffsetManager">The Timezone offset manager.</param>
        public UserProfileRepository(LearningCredentialsDbContext dbContext, ITimezoneOffsetManager tzOffsetManager)
            : base(dbContext, tzOffsetManager)
        {
        }

        /// <inheritdoc/>
        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await this.DbContext.UserProfile.FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}