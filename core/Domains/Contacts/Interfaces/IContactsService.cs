using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Services;

namespace PortfolioApi.Core.Domains.Contacts.Interfaces
{
    public interface IContactsService : IService<Contact, ContactInfo>
    {

    }
}
