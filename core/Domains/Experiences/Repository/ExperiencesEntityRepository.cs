using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models;
using PortfolioApi.Models.Experiences;
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
            OwnershipPrecondition(model, requestContext);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public override IEnumerable<Experience> Read(Experience input, RequestContext requestContext)
        {
            if (input.Id != default)
            {
                var result = new List<Experience>();
                var item = _portfolioContext.Experiences.Find(input.Id);
                if (item != null) result.Add(item);
                return result;
            }

            var baseRequest = _portfolioContext.Experiences.AsQueryable();
            if (input.ProfileId != default)
			{
                baseRequest = baseRequest.Where(x => x.ProfileId == input.ProfileId);
            }
            if (input.Info != null && !string.IsNullOrEmpty(input.Type))
            {
                baseRequest = baseRequest.Where(x => x.Type == input.Type);
            }
            if (input.Info != null && !string.IsNullOrEmpty(input.Info.Title))
            {
                baseRequest = baseRequest.Where(x => x.Info.Title == input.Info.Title);
            }
            return baseRequest.ToList();
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
