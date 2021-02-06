using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortfolioApi.Helpers.Authorization
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityServerPermissionAuthorizationHandler : AuthorizationHandler<IdentityServerAuthorizationPermissionRequirement>
	{
		private readonly IHttpContextAccessor contextAccessor;
		private readonly string[] modifyVerbs;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contextAccessor"></param>
		public IdentityServerPermissionAuthorizationHandler(IHttpContextAccessor contextAccessor)
		{
			this.contextAccessor = contextAccessor;
			modifyVerbs = new string[] { HttpMethod.Post.Method, HttpMethod.Put.Method };
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="requirement"></param>
		/// <returns></returns>
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdentityServerAuthorizationPermissionRequirement requirement)
		{
			var httpMethod = contextAccessor.HttpContext.Request.Method;
			var user = context.User;
			if (user != null && httpMethod != null)
			{
				switch (httpMethod)
				{
					case var method when (requirement.AuthorizeAsRead || HttpMethod.Get.Method == method) && user.HasClaim("scope", requirement.ReadScope):
						context.Succeed(requirement);
						break;
					case var method when modifyVerbs.Contains(method) && user.HasClaim("scope", requirement.WriteScope):
						context.Succeed(requirement);
						break;
					case var method when HttpMethod.Delete.Method == method && user.HasClaim("scope", requirement.DeleteScope):
						context.Succeed(requirement);
						break;
					default:
						if (user.HasClaim("scope", requirement.AdminScope))
						{
							context.Succeed(requirement);
						}
						else
						{
							context.Fail();
						}
						break;
				}
			}
			return Task.CompletedTask;
		}
	}
}
