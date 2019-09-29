using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Repository.EntityFramework.Context;
namespace PortfolioApi.Controllers
{

    [Authorize, ResponseCache(CacheProfileName = "Default")]
    [Route("api/[controller]")]
    public class PortfolioController : Controller
    {
        public PortfolioController()
        {
        }

        protected ActionResult Respond<T>(ServiceMessage<T> result) where T : Entity
        {
            if (!result.Validation.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
