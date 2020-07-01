using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Models.Helpers;
namespace PortfolioApi.Controllers
{

    /// <summary>
    /// https://github.com/domaindrivendev/Swashbuckle.AspNetCore
    ///  https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md
    /// </summary>
    [ResponseCache(CacheProfileName = "Default")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PortfolioController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public PortfolioController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected ActionResult Respond<T>(ServiceMessages<T> result) where T : Entity, new()
        {
            if (result.Validation != null && !result.Validation.IsValid)
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
