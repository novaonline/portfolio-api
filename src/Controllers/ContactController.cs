using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactController : PortfolioController
    {
        private readonly IContactsService _contactService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactService"></param>
        /// <returns></returns>
        public ContactController(IContactsService contactService) : base()
        {
            _contactService = contactService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        [HttpGet, Produces(typeof(ServiceMessages<Contact>))]
        public IActionResult Get(Contact searchTerm) => Respond(_contactService.Read(searchTerm, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Get(int Id) => Respond(_contactService.Read(new Contact(Id), RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost, Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Post([FromBody]Contact contact) => Respond(_contactService.Create(contact, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Put(int Id, [FromBody]ContactInfo contactInfo) => Respond(_contactService.Update(new Contact(Id), contactInfo, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Contact>))]
        public IActionResult Delete(int Id) => Respond(_contactService.Delete(new Contact(Id), RequestContext));
    }
}
