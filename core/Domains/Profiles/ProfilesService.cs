using System.Collections.Generic;
using core.Domains.Profiles.Interfaces;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;

namespace PortfolioApi.Core.Domains.Profiles
{
    /// <summary>
    /// The main profile logic
    /// </summary>
    public class ProfilesService : BaseService<Profile, ProfileInfo>, IProfilesService
    {
        public ProfilesService(
            IRepoCrud<Profile, ProfileInfo> profileRepo,
            IValidatorCreate<Profile> validateForCreation,
            IValidatorUpdate<Profile, ProfileInfo> validateForUpdate,
            IValidatorDelete<Profile> validateForDelete) : base(profileRepo,validateForCreation, validateForUpdate, validateForDelete)
        {
        
        }

        public IEnumerable<Profile> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
