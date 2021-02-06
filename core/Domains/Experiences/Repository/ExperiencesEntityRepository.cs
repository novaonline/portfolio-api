using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Experiences.Repository
{
    /// <summary>
    /// Repository Implementation to access the Experience Entities
    /// </summary>
    public class ExperiencesEntityRepository : BaseRepo<Experience, ExperienceInfo>
    {
        private readonly PortfolioContext _portfolioContext;

        public ExperiencesEntityRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public override Experience Create(Experience input, RequestContext requestContext)
        {
            input.OwnerUserId = requestContext.RequestedUserId;
            var changeTracking = _portfolioContext.Experiences.Add(input);
            var result = _portfolioContext.SaveChanges();
            return input;
        }

        public override Experience Delete(Experience input, RequestContext requestContext)
        {
            var model = _portfolioContext.Experiences.Find(input.Id);
            OwnershipPrecondition(input, requestContext);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public override IEnumerable<Experience> Read(Experience input, RequestContext requestContext)
        {
            var baseRequest = _portfolioContext.Experiences.Where(x => x.OwnerUserId.Equals(requestContext.RequestedUserId));
            if (input.Info != null && !string.IsNullOrEmpty(input.Type) && !string.IsNullOrEmpty(input.Info.Title))
            {
                return baseRequest.Where(
                    x => x.Type == input.Type
                    && x.Info.Title == input.Info.Title);
            }
            else if (!string.IsNullOrEmpty(input.Type))
            {
                return baseRequest.Where(x => x.Type == input.Type);
            }
            else
            {
                var result = new List<Experience>();
                var item = _portfolioContext.Experiences.Find(input.Id);
                OwnershipPrecondition(item, requestContext);
                if (item != null) result.Add(item);
                return result;
            }
        }

        public override Experience Update(Experience search, ExperienceInfo input, RequestContext requestContext)
        {
            var m = _portfolioContext.Experiences.Find(search.Id);
            OwnershipPrecondition(m, requestContext);
            m.Info = input;
            var result = _portfolioContext.SaveChanges();
            return m;
        }
    }
}
