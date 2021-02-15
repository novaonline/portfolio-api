using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models;
using PortfolioApi.Models.Interfaces.Repos;
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
			IQueryable<Profile> baseQuery = _portfolioContext.Profiles
				.Where(x => x.OwnerUserId.Equals(requestContext.RequestedUserId));
			if (input.Info != null && !string.IsNullOrEmpty(input.Info.LastName) && !string.IsNullOrEmpty(input.Info.FirstName))
			{
				return baseQuery.Where(
					x => x.Info.LastName == input.Info.LastName
					&& x.Info.FirstName == input.Info.FirstName);
			}
			else if (input.Info != null && !string.IsNullOrEmpty(input.Info.LastName))
			{
				return baseQuery.Where(x => x.Info.LastName == input.Info.LastName);
			}
			else if (input.Id != default)
			{
				var result = new List<Profile>();
				var item = _portfolioContext.Profiles.Find(input.Id);
				OwnershipPrecondition(item, requestContext);
				if (item != null) result.Add(item);
				return result;
			}
			else
			{
				return baseQuery;
			}
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
