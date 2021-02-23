using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models;
using PortfolioApi.Models.Profiles;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Profiles.Repository
{
	/// <summary>
	/// The Repository Implementation for Profile Entities
	/// </summary>
	public class ProfilesEntityRepository : BaseRepo<Profile, ProfileInfo>
	{
		private readonly PortfolioContext _portfolioContext;

		public ProfilesEntityRepository(PortfolioContext portfolioContext)
		{
			_portfolioContext = portfolioContext;
		}

		public override Profile Create(Profile input, RequestContext requestContext)
		{
			input.OwnerUserId = requestContext.RequestedUserId;
			var changeTracking = _portfolioContext.Profiles.Add(input);
			var result = _portfolioContext.SaveChanges();
			return input;
		}

		public override Profile Delete(Profile input, RequestContext requestContext)
		{
			var model = _portfolioContext.Profiles.Find(input.Id);
			OwnershipPrecondition(model, requestContext);
			_portfolioContext.Remove(model);
			_portfolioContext.SaveChanges();
			return model;
		}

		public override IEnumerable<Profile> Read(Profile input, RequestContext requestContext)
		{
			if (input.Id != default)
			{
				var result = new List<Profile>();
				var item = _portfolioContext.Profiles.Find(input.Id);
				if (item != null) result.Add(item);
				return result;
			}
			IQueryable<Profile> baseQuery = _portfolioContext.Profiles;
			if (input.Info != null && !string.IsNullOrEmpty(input.Info.LastName))
			{
				baseQuery = baseQuery.Where(x => x.Info.LastName == input.Info.LastName);
			}
			if(input.Info != null && !string.IsNullOrEmpty(input.Info.FirstName))
			{
				baseQuery = baseQuery.Where(x => x.Info.FirstName == input.Info.FirstName);
			}
			return baseQuery.ToList();
		}

		public override Profile Update(Profile search, ProfileInfo input, RequestContext requestContext)
		{
			var m = _portfolioContext.Profiles.Find(search.Id);
			OwnershipPrecondition(m, requestContext);
			m.Info.UpdateProperties(input);
			m.SetUpdateDate();
			var result = _portfolioContext.SaveChanges();
			return m;
		}
	}
}
