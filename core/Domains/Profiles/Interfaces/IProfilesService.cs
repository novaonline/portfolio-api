using System.Collections.Generic;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Services;
using PortfolioApi.Models.Profiles;

namespace core.Domains.Profiles.Interfaces
{
    public interface IProfilesService : IService<Profile, ProfileInfo>
    {
        IEnumerable<Profile> GetAll();
    }
}
