using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Contacts
{
    /// <summary>
    /// The validation of Contact Information
    /// </summary>
    public class ContactsUpdateValidator : IValidatorUpdate<Contact>
    {
        public Validation<Contact> Validate(Contact input)
        {
            throw new System.NotImplementedException();
        }
    }
}
