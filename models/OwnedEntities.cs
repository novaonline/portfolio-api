using System.Collections;
using System.Collections.Generic;

namespace PortfolioApi.Models
{
	public class OwnedEntities<T> : IEnumerable<T> where T : OwnedEntity
	{
		private readonly IEnumerable<T> results;
		private readonly RequestContext requestContext;

		public OwnedEntities(IEnumerable<T> results, RequestContext requestContext)
		{
			this.results = results;
			this.requestContext = requestContext;
		}


		public IEnumerator<T> GetEnumerator()
		{
			foreach (var val in results)
			{
				if (val.IsOwnedBy(requestContext?.RequestedUserId))
				{
					yield return val;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
