using PortfolioApi.Models;
using PortfolioApi.Models.Helpers.Exceptions;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Core.Domains.Common
{
	public abstract class BaseRepo<T,U>: IRepoCrud<T, U> where T : Entity where U : IInfo<U>
	{
		public abstract T Create(T input, RequestContext requestContext);
		public abstract T Delete(T input, RequestContext requestContext);
		public abstract IEnumerable<T> Read(T input, RequestContext requestContext);
		public abstract T Update(T search, U input, RequestContext requestContext);

		protected void OwnershipPrecondition(T input, RequestContext requestContext)
		{
			if (input is OwnedEntity ownedEntity && !ownedEntity.IsOwnedBy(requestContext?.RequestedUserId))
				throw new InternalLevelAuthorizationException();
		}
	}
}
