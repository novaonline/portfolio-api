using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Contacts;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController: PortfolioController
    {
        public ContactController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Contact))]
        public IActionResult Get()
        {
            return Ok(_context.Contacts
            .Include(contact => contact.Info.Addresses)
            .Include(contact => contact.Info.PhoneNumbers)
            .FirstOrDefault());
        }
    }
}
