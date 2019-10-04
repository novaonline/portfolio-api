using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Models.Helpers;
using Model = PortfolioApi.Models.Contacts;

namespace PortfolioApi.Controllers
{
    public class ContactController : PortfolioController
    {
        private readonly IContactsService _contactService;

        public ContactController(IContactsService contactService) : base()
        {
            _contactService = contactService;
        }

        [HttpGet("{profileId}"), AllowAnonymous]
        [Produces(typeof(ServiceMessage<Model.Contact>))]
        public IActionResult Get(int profileId)
        {
            // TODO: Create a Validation function that will check if Validation returns client error
            return Respond(_contactService.Read(new Model.Contact
            {
                ProfileId = profileId
            }));
        }

    }
}
