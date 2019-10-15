using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Models.Helpers;
namespace PortfolioApi.Controllers
{

    //https://github.com/domaindrivendev/Swashbuckle.AspNetCore
    //https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md
    [Authorize, ResponseCache(CacheProfileName = "Default")]
    [Route("api/[controller]")]
    public class PortfolioController : Controller
    {
        public PortfolioController()
        {
        }

        protected ActionResult Respond<T>(ServiceMessage<T> result) where T : Entity, new()
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

        protected ActionResult Respond<T>(ServiceMessages<T> result) where T : Entity, new()
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
