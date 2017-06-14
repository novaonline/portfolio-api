using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Contact;

namespace PortfolioApi.Controllers
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
