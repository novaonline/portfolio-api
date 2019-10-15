using Microsoft.Extensions.DependencyInjection;
using PortfolioApi.Core.Domains.Contacts.Interfaces;
using PortfolioApi.Core.Domains.Contacts.Repository;
using PortfolioApi.Core.Domains.Contacts.Validation;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers.Builder;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Contacts
{
    public class ContactsDependencyInjectionSetup : IDependencyInjectionSetup
    {
        public void Inject(IServiceCollection services, PortfolioConfiguration config)
        {
            services.AddTransient<IRepoCrud<Contact, ContactInfo>, ContactsEntityRepository>();
            services.AddTransient<IValidatorCreate<Contact>, ContactsCreateFluentValidator>();
            services.AddTransient<IValidatorUpdate<Contact, ContactInfo>, ContactsUpdateFluentValidator>();
            services.AddTransient<IValidatorDelete<Contact>, ContactsDeleteSimpleValidator>();
            services.AddTransient<IContactsService, ContactsService>();
        }
    }
}
