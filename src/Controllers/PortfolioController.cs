using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services;
namespace PortfolioApi.Controllers
{

    [Authorize, ResponseCache(CacheProfileName = "Default")]
    public class PortfolioController : Controller
    {
        protected readonly PortfolioContext _context;
        public PortfolioController(PortfolioContext context)
        {
            _context = context;
        }
    }
}
