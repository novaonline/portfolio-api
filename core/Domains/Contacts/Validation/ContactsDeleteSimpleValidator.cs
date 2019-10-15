using System.Collections.Generic;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Contacts.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ContactsDeleteSimpleValidator : IValidatorDelete<Contact>
    {
        public ContactsDeleteSimpleValidator() { }

        public Validation<Contact> Validate(Contact input)
        {
            if (input.Id == default)
            {
                return new Validation<Contact>
                {
                    Result = input,
                    ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>
                    {
                        {nameof(input.Id), new List<ValidationErrorMessage> { new ValidationErrorMessage("Id is required") }}
                    }
                };
            }

            return new Validation<Contact>
            {
                Result = input,
                ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>()
            };
        }
    }
}
