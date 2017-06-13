using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio_api.Services;
using Model = portfolio_api.Models.Contact;

namespace portfolio_api.Controllers
{
    [Route("api/[controller]")]
    public class ContactController: PortfolioController
    {
        public ContactController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        public Model Get()
        {
            return _context.Contacts
            .Include(contact => contact.Addresses)
            .Include(contact => contact.PhoneNumbers)
            .First();
        }
    }
}
