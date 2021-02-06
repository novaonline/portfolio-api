using Microsoft.AspNetCore.Authorization;

namespace PortfolioApi.Helpers.Authorization
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityServerAuthorizationPermissionRequirement : IAuthorizationRequirement
	{
		/// <summary>
		/// 
		/// </summary>
		public string ReadScope { get; }

		/// <summary>
		/// 
		/// </summary>
		public string WriteScope { get; }

		/// <summary>
		/// 
		/// </summary>
		public string DeleteScope { get; }

		/// <summary>
		/// 
		/// </summary>
		public string AdminScope { get; }
		
		/// <summary>
		/// 
		/// </summary>
		public bool AuthorizeAsRead { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiName"></param>
		/// <param name="authorizeAsRead"></param>
		public IdentityServerAuthorizationPermissionRequirement(string apiName, bool? authorizeAsRead = null)
		{
			ReadScope = $"{apiName}.read";
			WriteScope = $"{apiName}.write";
			DeleteScope = $"{apiName}.delete";
			AdminScope = $"{apiName}.manage";
			if (authorizeAsRead.HasValue)
			{
				AuthorizeAsRead = authorizeAsRead.Value;
			}
		}
	}
}
