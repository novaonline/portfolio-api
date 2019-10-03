using System.Collections.Generic;
using core.Domains.Profiles.Interfaces;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;

namespace PortfolioApi.Core.Domains.Profiles
{
    /// <summary>
    /// The main profile logic
    /// </summary>
    public class ProfilesService : IProfilesService
    {
        private readonly IValidatorCreate<Profile> _validateForCreation;
        private readonly IRepoCrud<Profile, ProfileInfo> _profileRepo;

        public ProfilesService(IValidatorCreate<Profile> validateForCreation, IRepoCrud<Profile, ProfileInfo> profileRepo)
        {
            _validateForCreation = validateForCreation;
            _profileRepo = profileRepo;
        }
        
        public ServiceMessage<Profile> Create(Profile input)
        {
            var validationResult = _validateForCreation.Validate(input);
            var result = new ServiceMessage<Profile> { Validation = validationResult };
            if (validationResult.IsValid)
            {
                result.Result = _profileRepo.Create(validationResult.Result);
            }
            return result;
        }

        public ServiceMessage<Profile> Delete(Profile input)
        {
            throw new System.NotImplementedException();
        }

        public ServiceMessage<Profile> Get(Profile input)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Profile> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ServiceMessage<Profile> Update(Profile search, ProfileInfo input)
        {
            throw new System.NotImplementedException();
        }
    }
}
