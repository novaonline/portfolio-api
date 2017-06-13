using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portfolio_api.Services;
namespace portfolio_api.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        protected readonly PortfolioContext _context;
        public PortfolioController(PortfolioContext context)
        {
            _context = context;
        }
    }
}
