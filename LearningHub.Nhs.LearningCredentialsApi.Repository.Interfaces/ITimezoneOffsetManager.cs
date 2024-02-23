// <copyright file="ITimezoneOffsetManager.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Repository.Interface
{
    /// <summary>
    /// The TimezoneOffsetManager interface.
    /// </summary>
    public interface ITimezoneOffsetManager
    {
        /// <summary>
        /// Gets User Timezone Offset.
        /// </summary>
        int? UserTimezoneOffset { get; }
    }
}
