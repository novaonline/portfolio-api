using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Profiles;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Profiles.Repository
{
    /// <summary>
    /// The Repository Implementation for Profile Entities
    /// </summary>
    public class ProfilesEntityRepository : IRepoCrud<Profile>
    {
        private readonly PortfolioContext _portfolioContext;

        public ProfilesEntityRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public Profile Create(Profile input)
        {
            var changeTracking = _portfolioContext.Profiles.Add(input);
            var result = _portfolioContext.SaveChanges();
            return input;
        }

        public Profile Delete(Profile input)
        {
            var model = _portfolioContext.Profiles.Find(input.Id);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public IEnumerable<Profile> Get(Profile input)
        {
            if (input.Info != null && !string.IsNullOrEmpty(input.Info.LastName) && !string.IsNullOrEmpty(input.Info.FirstName))
            {
                return _portfolioContext.Profiles.Where(
                    x => x.Info.LastName == input.Info.LastName
                    && x.Info.FirstName == input.Info.FirstName);
            }
            else if (input.Info != null && !string.IsNullOrEmpty(input.Info.LastName))
            {
               return _portfolioContext.Profiles.Where(x => x.Info.LastName == input.Info.LastName);
            }
            else
            {
                var result = new List<Profile>();
                var item = _portfolioContext.Profiles.Find(input.Id);
                if(item != null) result.Add(item);
                return result;
            }
        }

        public Profile Update(Profile input)
        {
            var m = _portfolioContext.Profiles.Find(input.Id);
            m.Info = input.Info;
            var result = _portfolioContext.SaveChanges();
            return m;
        }
    }
}
