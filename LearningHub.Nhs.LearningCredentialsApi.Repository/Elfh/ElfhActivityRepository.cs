// <copyright file="ElfhActivityRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Elfh
{
    using System.Data;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface.Elfh;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The elfh activity repository.
    /// </summary>
    public class ElfhActivityRepository : IElfhActivityRepository
    {
        private ElfhHubDbContext elfhDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElfhActivityRepository"/> class.
        /// </summary>
        /// <param name="elfhDbContext">The db context.</param>
        public ElfhActivityRepository(ElfhHubDbContext elfhDbContext)
        {
            this.elfhDbContext = elfhDbContext;
        }

        /// <inheritdoc/>
        public async Task<List<ClientSystemCredentialResult>> GetClientSystemCredentialsForUserAsync(int userId, string componentIds)
        {
            var param0 = new SqlParameter("@p0", SqlDbType.Int) { Value = userId };
            var param1 = new SqlParameter("@p1", SqlDbType.NVarChar) { Value = componentIds };

            var result = await this.elfhDbContext.Set<ClientSystemCredentialResult>().FromSqlRaw(
                                "[dsp].[proc_LatestCompletedActivityByComponents] @p0, @p1", param0, param1).AsNoTracking().ToListAsync();

            return result;
        }
    }
}
