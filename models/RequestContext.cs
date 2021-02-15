using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioApi.Models
{
	public class RequestContext
	{

		public IEnumerable<System.Security.Claims.Claim> Claims { get; private set; }
		public string? RequestedUserId { get; private set; }
		public RequestContext(IEnumerable<System.Security.Claims.Claim> claims)
		{
			Claims = claims ?? new List<System.Security.Claims.Claim>();
			RequestedUserId = claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
		}

	}
}
