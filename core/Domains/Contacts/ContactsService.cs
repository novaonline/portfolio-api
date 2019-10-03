using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Core.Domains.Contacts
{
    /// <summary>
    /// Main Contacts Logic
    /// </summary>
    public class ContactsService : IContactsService
    {
        public ServiceMessage<Contact> Create(Contact input)
        {
            throw new System.NotImplementedException();
        }

        public ServiceMessage<Contact> Delete(Contact input)
        {
            throw new System.NotImplementedException();
        }

        public ServiceMessage<Contact> Get(Contact input)
        {
            throw new System.NotImplementedException();
        }

        public ServiceMessage<Contact> Update(Contact search, ContactInfo input)
        {
            throw new System.NotImplementedException();
        }
    }
}
