using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Controllers
{
    public class ContactController : PortfolioController
    {
        private readonly IContactsService _contactService;

        public ContactController(IContactsService contactService) : base()
        {
            _contactService = contactService;
        }

        [HttpGet, Produces(typeof(ServiceMessages<Contact>))]
        public IActionResult Get(Contact searchTerm) => Respond(_contactService.Read(searchTerm));

        [HttpGet(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Get(int Id) => Respond(_contactService.Read(new Contact(Id)));

        [HttpPost, Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Post(Contact contact) => Respond(_contactService.Create(contact));

        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Put(int Id, ContactInfo contactInfo) => Respond(_contactService.Update(new Contact(Id), contactInfo));

        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Delete(int Id) => Respond(_contactService.Delete(new Contact(Id)));
    }
}
