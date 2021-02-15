using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PortfolioApi.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityController : PortfolioController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get() => new JsonResult(from c in User.Claims select new { c.Type, c.Value });
	}
}
