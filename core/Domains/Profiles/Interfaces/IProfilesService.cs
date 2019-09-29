using System.Collections.Generic;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Profiles;

namespace core.Domains.Profiles.Interfaces
{
    public interface IProfilesService : ICrud<Profile, ServiceMessage<Profile>>
    {
        IEnumerable<Profile> GetAll();
    }
}
