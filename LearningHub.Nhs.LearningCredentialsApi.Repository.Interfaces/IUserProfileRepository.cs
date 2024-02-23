// <copyright file="IUserProfileRepository.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Interface
{
    using System.Threading.Tasks;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.User;

    /// <summary>
    /// The Learning Hub User Repository interface.
    /// </summary>
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<UserProfile> GetByIdAsync(int id);
    }
}