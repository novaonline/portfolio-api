using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Contacts;
using Microsoft.AspNetCore.Cors;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : PortfolioController
    {
        public ContactController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Contact))]
        public IActionResult Get()
        {
            return Ok(
            _context.Contacts.Include(c => c.Info)
            );
        }

    }
}
