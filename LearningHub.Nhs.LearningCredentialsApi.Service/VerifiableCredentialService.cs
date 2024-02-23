// <copyright file="VerifiableCredentialService.cs" company="HEE.nhs.uk">
// Copyright (c) HEE.nhs.uk.
// </copyright>

namespace LearningHub.Nhs.LearningCredentialsApi.Service
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using LearningHub.Nhs.LearningCredentials.Models.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Entities.Dsp;
    using LearningHub.Nhs.LearningCredentials.Models.Enums.Dsp;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface;
    using LearningHub.Nhs.LearningCredentialsApi.Repository.Interface.Elfh;
    using LearningHub.Nhs.LearningCredentialsApi.Service.Interface;
    using LearningHub.Nhs.Models.Validation;

    /// <summary>
    /// Definition of the Verifiable Credential Service.
    /// </summary>
    public class VerifiableCredentialService : IVerifiableCredentialService
    {
        private readonly IMapper mapper;
        private readonly IVerifiableCredentialRepository verifiableCredentialRepository;
        private readonly IUserVerifiableCredentialRepository userVerifiableCredentialRepository;
        private readonly IElfhActivityRepository elfhActivityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VerifiableCredentialService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="verifiableCredentialRepository">The verifiable credential repository.</param>
        /// <param name="userVerifiableCredentialRepository">The user verifiable credential repository.</param>
        /// <param name="elfhActivityRepository">The elfh activity repository.</param>
        public VerifiableCredentialService(
            IMapper mapper,
            IVerifiableCredentialRepository verifiableCredentialRepository,
            IUserVerifiableCredentialRepository userVerifiableCredentialRepository,
            IElfhActivityRepository elfhActivityRepository)
        {
            this.mapper = mapper;
            this.verifiableCredentialRepository = verifiableCredentialRepository;
            this.userVerifiableCredentialRepository = userVerifiableCredentialRepository;
            this.elfhActivityRepository = elfhActivityRepository;
        }

        /// <inheritdoc/>
        public async Task<LearningHubValidationResult> CreateUserVerifiableCredentialAsync(int userId, UserVerifiableCredentialRequest userVerifiableCredentialRequest)
        {
            var userVerifiableCredential = this.mapper.Map<UserVerifiableCredential>(userVerifiableCredentialRequest);

            var verifiableCredential = this.verifiableCredentialRepository.GetAll().Where(vc => vc.Id == userVerifiableCredential.VerifiableCredentialId).FirstOrDefault();

            userVerifiableCredential.ExpiryDate = this.CalculateExpiryDate(userVerifiableCredential.ActivityDate.Value.DateTime, (PeriodUnitEnum)verifiableCredential.PeriodUnitId, verifiableCredential.PeriodQty);
            var userVerifiableCredentialId = await this.userVerifiableCredentialRepository.CreateAsync(userId, userVerifiableCredential);

            return new LearningHubValidationResult(true)
            {
                CreatedId = userVerifiableCredentialId,
            };
        }

        /// <inheritdoc/>
        public async Task<LearningHubValidationResult> UpdateUserVerifiableCredentialAsync(int userId, UserVerifiableCredentialRequest userVerifiableCredentialRequest)
        {
            var userVerifiableCredential = this.mapper.Map<UserVerifiableCredential>(userVerifiableCredentialRequest);

            await this.userVerifiableCredentialRepository.UpdateAsync(userId, userVerifiableCredential);

            return new LearningHubValidationResult(true)
            {
                CreatedId = userVerifiableCredentialRequest.UserVerifiableCredentialId,
            };
        }

        /// <inheritdoc/>
        public UserVerifiableCredentialResponse GetUserVerifiableCredentialById(int userVerifiableCredentialId)
        {
            var userVerifiableCredential = this.userVerifiableCredentialRepository.GetById(userVerifiableCredentialId);
            var returnVal = this.mapper.Map<UserVerifiableCredentialResponse>(userVerifiableCredential);
            return returnVal;
        }

        /// <inheritdoc/>
        public List<VerifiableCredentialResponse> GetAll()
        {
            var userVerifiableCredential = this.verifiableCredentialRepository.GetAll();
            var returnVal = this.mapper.Map<List<VerifiableCredentialResponse>>(userVerifiableCredential);
            return returnVal;
        }

        /// <inheritdoc/>
        public List<UserVerifiableCredentialResponse> GetUserVerifiableCredentialsByUserAndId(int userId, int verifiableCredentialId)
        {
            var userVerifiableCredential = this.userVerifiableCredentialRepository.GetAll()
                                                    .Where(uvc => uvc.UserId == userId && uvc.VerifiableCredentialId == verifiableCredentialId)
                                                    .OrderByDescending(uvc => uvc.AddedToDSPDate);

            var returnVal = this.mapper.Map<List<UserVerifiableCredentialResponse>>(userVerifiableCredential);

            return returnVal;
        }

        /// <inheritdoc/>
        public VerifiableCredentialResponse GetById(int verifiableCredentialId)
        {
            var verifiableCredential = this.verifiableCredentialRepository.GetAll().Where(vc => vc.Id == verifiableCredentialId).FirstOrDefault();
            var returnVal = this.mapper.Map<VerifiableCredentialResponse>(verifiableCredential);

            return returnVal;
        }

        /// <inheritdoc/>
        public async Task<List<UserVerifiableCredentialResponse>> GetSummaryForUser(int userId)
        {
            var allCredentials = this.verifiableCredentialRepository.GetAll().ToList();

            var clientCredentialIdList = allCredentials.Select(vc => vc.ClientSystemCredentialId.ToString()).ToList();
            var clientCredentialIdText = string.Join(",", clientCredentialIdList);

            var userVerifiableCredentialList = this.userVerifiableCredentialRepository.GetAllForUserAsync(userId);

            var elfhAvailableCredentials = await this.elfhActivityRepository.GetClientSystemCredentialsForUserAsync(userId, clientCredentialIdText);

            var outputList = new List<UserVerifiableCredentialResponse>();
            foreach (var credential in allCredentials)
            {
                var displayCredential = new UserVerifiableCredentialResponse()
                {
                    UserVerifiableCredentialId = credential.Id,
                    CredentialName = credential.CredentialName,
                    ClientSystemId = credential.ClientSystemId,
                    ClientSystemCredentialId = credential.ClientSystemCredentialId,
                    UserId = userId,
                };

                var existingCredential = userVerifiableCredentialList.Where(uvc => uvc.VerifiableCredential.ClientSystemCredentialId == credential.ClientSystemCredentialId)
                    .OrderByDescending(uvc => uvc.ActivityDate)
                    .FirstOrDefault();

                if (existingCredential != null)
                {
                    displayCredential.SerialNumber = existingCredential.SerialNumber;
                    displayCredential.AddedToDSPDate = existingCredential.AddedToDSPDate;
                    displayCredential.DSPActivityDate = existingCredential.ActivityDate;
                    displayCredential.DSPExpiryDate = existingCredential.ExpiryDate;
                    displayCredential.AttainmentStatus = existingCredential.AttainmentStatus;
                    displayCredential.DSPCode = existingCredential.DSPCode;
                    displayCredential.Status = (UserVerifiableCredentialStatusEnum)existingCredential.UserVerifiableCredentialStatusId;
                    displayCredential.VerifiableCredentialId = existingCredential.VerifiableCredentialId;
                }

                var clientCredential = elfhAvailableCredentials.Where(uvc => uvc.ComponentId == credential.ClientSystemCredentialId)
                    .FirstOrDefault();

                if (clientCredential != null)
                {
                    displayCredential.ActivityDate = clientCredential.ActivityDate.DateTime;
                    displayCredential.AttainmentStatus = clientCredential.AttainmentStatus;
                }

                if (displayCredential.ActivityDate == DateTimeOffset.MinValue)
                {
                    displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.NotAvailable;
                }
                else if (displayCredential.DSPActivityDate == null)
                {
                    displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.NotSentToDigitalWallet;
                }
                else if (this.DatesMatchToTheSecond(displayCredential.ActivityDate, displayCredential.DSPActivityDate))
                {
                    displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.SentToDigitalWallet;
                }
                else if (displayCredential.ActivityDate > displayCredential.DSPActivityDate)
                {
                    displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.LaterActivityAvailable;
                }
                else
                {
                    displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.SentToDigitalWallet;
                }

                outputList.Add(displayCredential);
            }

            return outputList;
        }

        /// <inheritdoc/>
        public async Task<List<UserVerifiableCredentialResponse>> GetForUser(int userId)
        {
            var allCredentials = this.verifiableCredentialRepository.GetAllWithClientSystem().ToList();

            var clientCredentialIdList = allCredentials.Select(vc => vc.ClientSystemCredentialId.ToString()).ToList();
            var clientCredentialIdText = string.Join(",", clientCredentialIdList);

            var userVerifiableCredentialList = this.userVerifiableCredentialRepository.GetAllForUserAsync(userId);

            var elfhAvailableCredentials = await this.elfhActivityRepository.GetClientSystemCredentialsForUserAsync(userId, clientCredentialIdText);

            var outputList = new List<UserVerifiableCredentialResponse>();

            foreach (var clientCredential in elfhAvailableCredentials)
            {
                var verifiableCredential = allCredentials
                                            .Where(vc => vc.ClientSystemCredentialId == clientCredential.ComponentId)
                                            .FirstOrDefault();

                var clientExpiryDate = this.CalculateExpiryDate(clientCredential.ActivityDate, (PeriodUnitEnum)verifiableCredential.PeriodUnitId, verifiableCredential.PeriodQty);

                if (clientExpiryDate > DateTimeOffset.Now)
                {
                    var displayCredential = new UserVerifiableCredentialResponse()
                    {
                        CredentialName = verifiableCredential!.CredentialName,
                        ClientSystemId = verifiableCredential.ClientSystemId,
                        ClientSystemCredentialId = verifiableCredential.ClientSystemCredentialId,
                        UserId = userId,
                        ActivityDate = clientCredential.ActivityDate,
                        ExpiryDate = clientExpiryDate,
                        AttainmentStatus = clientCredential.AttainmentStatus,
                        RenewalPeriodText = this.RenewalPeriodDescription((PeriodUnitEnum)verifiableCredential.PeriodUnitId, verifiableCredential.PeriodQty),
                        Origin = verifiableCredential.ClientSystem.Origin,
                        Provider = verifiableCredential.ClientSystem.Provider,
                        VerifiableCredentialId = verifiableCredential.Id,
                    };

                    var existingCredential = userVerifiableCredentialList.Where(uvc => uvc.VerifiableCredential.ClientSystemCredentialId == clientCredential.ComponentId)
                        .OrderByDescending(uvc => uvc.AddedToDSPDate)
                        .FirstOrDefault();

                    if (existingCredential != null)
                    {
                        displayCredential.UserVerifiableCredentialId = existingCredential.Id;
                        displayCredential.SerialNumber = existingCredential.SerialNumber;
                        displayCredential.AddedToDSPDate = existingCredential.AddedToDSPDate;
                        displayCredential.DSPActivityDate = existingCredential.ActivityDate;
                        displayCredential.DSPExpiryDate = existingCredential.ExpiryDate;
                        displayCredential.AttainmentStatus = existingCredential.AttainmentStatus;
                        displayCredential.DSPCode = existingCredential.DSPCode;
                        displayCredential.Status = (UserVerifiableCredentialStatusEnum)existingCredential.UserVerifiableCredentialStatusId;
                        displayCredential.VerifiableCredentialId = existingCredential.VerifiableCredentialId;
                    }

                    if (displayCredential.DSPActivityDate == null)
                    {
                        displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.NotSentToDigitalWallet;
                    }
                    else if (this.DatesMatchToTheSecond(displayCredential.ActivityDate, displayCredential.DSPActivityDate))
                    {
                        displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.SentToDigitalWallet;
                    }
                    else if (displayCredential.ActivityDate > displayCredential.DSPActivityDate)
                    {
                        displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.LaterActivityAvailable;
                    }
                    else
                    {
                        displayCredential.DisplayStatus = UserVerifiableCredentialDisplayStatusEnum.SentToDigitalWallet;
                    }

                    outputList.Add(displayCredential);
                }
            }

            return outputList;
        }

        /// <inheritdoc/>
        public async Task<ClientSystemCredentialResult> GetClientSystemCredentialForUser(int userId, int verifiableCredentialId)
        {
            var credential = this.GetById(verifiableCredentialId);

            var elfhAvailableCredential = await this.elfhActivityRepository.GetClientSystemCredentialsForUserAsync(userId, credential.ClientSystemCredentialId.ToString());

            return elfhAvailableCredential.ToList().FirstOrDefault() !;
        }

        private bool DatesMatchToTheSecond(DateTimeOffset? date1, DateTimeOffset? date2)
        {
            if (date1 == null || date2 == null)
            {
                return false;
            }

            if (Math.Abs(((TimeSpan)(date1 - date2)).TotalSeconds) < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string RenewalPeriodDescription(PeriodUnitEnum periodUnit, short periodQty)
        {
            return periodQty.ToString() + " " + periodUnit.ToString().ToLower() + (periodQty > 1 ? "s" : string.Empty);
        }

        private DateTimeOffset CalculateExpiryDate(DateTimeOffset activityDate, PeriodUnitEnum periodUnit, short periodQty)
        {
            switch (periodUnit)
            {
                case PeriodUnitEnum.Minute:
                    return activityDate.AddMinutes(periodQty);
                case PeriodUnitEnum.Hour:
                    return activityDate.AddHours(periodQty);
                case PeriodUnitEnum.Day:
                    return activityDate.AddDays(periodQty);
                case PeriodUnitEnum.Week:
                    return activityDate.AddDays(periodQty * 7);
                case PeriodUnitEnum.Month:
                    return activityDate.AddMonths(periodQty);
                case PeriodUnitEnum.Year:
                default:
                    return activityDate.AddYears(periodQty);
            }
        }
    }
}
