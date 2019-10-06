using System.Collections.Generic;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ContactsDeleteSimpleValidator : IValidatorUpdate<Contact, ContactInfo>
    {
        public ContactsDeleteSimpleValidator() { }
        public Validation<Contact> Validate(Contact search, ContactInfo input)
        {
            if (search.Id == default)
            {
                return new Validation<Contact>
                {
                    Result = search,
                    ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>
                    {
                        {nameof(search.Id), new List<ValidationErrorMessage> { new ValidationErrorMessage("Id is required") }}
                    }
                };
            }

            return new Validation<Contact>
            {
                Result = search,
                ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>()
            };
        }
    }
}
