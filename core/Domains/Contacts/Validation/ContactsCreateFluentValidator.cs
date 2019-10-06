using System.Linq;
using FluentValidation;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Contacts.Validation
{
    /// <summary>
    /// The validation of Contact Information
    /// </summary>
    public class ContactsCreateFluentValidator : IValidatorUpdate<Contact, ContactInfo>
    {
        private readonly ContactsCreateFluentValidatorModel _validator;
        private readonly ContactsInfoCreateFluentValidatorModel _validatorInfo;

        public ContactsCreateFluentValidator()
        {
            _validator = new ContactsCreateFluentValidatorModel();
            _validatorInfo = new ContactsInfoCreateFluentValidatorModel();
        }

        public Validation<Contact> Validate(Contact search, ContactInfo input)
        {
            var vSearch = _validator.Validate(search);
            var vInfo = _validatorInfo.Validate(input);
            return new Validation<Contact>
            {
                Result = search,
                ErrorMessagesPerProperty = vSearch.IsValid ? vInfo.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList()) : vSearch.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };
        }
    }

    public class ContactsCreateFluentValidatorModel : AbstractValidator<Contact>
    {

    }

    public class ContactsInfoCreateFluentValidatorModel : AbstractValidator<ContactInfo>
    {

    }
}
