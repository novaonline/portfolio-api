using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Experiences
{
    /// <summary>
    /// Repository Implementation to access the Experience Entities
    /// </summary>
    public class ExperienceEntityRepository : IRepoCrud<Experience>
    {
        private readonly PortfolioContext _portfolioContext;

        public ExperienceEntityRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public Experience Create(Experience input)
        {
           var changeTracking = _portfolioContext.Experiences.Add(input);
            var result = _portfolioContext.SaveChanges();
            return input;
        }

        public Experience Delete(Experience input)
        {
            var model = _portfolioContext.Experiences.Find(input.Id);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public IEnumerable<Experience> Get(Experience input)
        {
            if (input.Info != null && !string.IsNullOrEmpty(input.Type) && !string.IsNullOrEmpty(input.Info.Title))
            {
                return _portfolioContext.Experiences.Where(
                    x => x.Type == input.Type
                    && x.Info.Title == input.Info.Title);
            }
            else if (!string.IsNullOrEmpty(input.Type))
            {
               return _portfolioContext.Experiences.Where(x => x.Type == input.Type);
            }
            else
            {
                var result = new List<Experience>();
                var item = _portfolioContext.Experiences.Find(input.Id);
                if(item != null) result.Add(item);
                return result;
            }
        }

        public Experience Update(Experience input)
        {
            var m = _portfolioContext.Experiences.Find(input.Id);
            m.Info = input.Info;
            var result = _portfolioContext.SaveChanges();
            return m;
        }
    }
}
