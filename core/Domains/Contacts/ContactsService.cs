using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Contacts
{
    /// <summary>
    /// Main Contacts Logic
    /// </summary>
    public class ContactsService : BaseService<Contact, ContactInfo>, IContactsService
    {
        public ContactsService(IRepoCrud<Contact, ContactInfo> profileRepo, IValidatorCreate<Contact> validateForCreation, IValidatorUpdate<Contact, ContactInfo> validateForUpdate, IValidatorDelete<Contact> validateForDelete) : base(profileRepo, validateForCreation, validateForUpdate, validateForDelete)
        {
        }
    }
}
