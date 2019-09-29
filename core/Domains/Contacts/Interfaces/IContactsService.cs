using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces;

namespace PortfolioApi.Core.Domains.Contacts.Interfaces
{
    public interface IContactsService : ICrud<Contact, ServiceMessage<Contact>>
    {

    }
}
