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
    public class ContactsCreateFluentValidator : IValidatorCreate<Contact>
    {
        private readonly ContactsCreateFluentValidatorModel _validator;

        public ContactsCreateFluentValidator()
        {
            _validator = new ContactsCreateFluentValidatorModel();
        }

        public Validation<Contact> Validate(Contact input)
        {
            var v = _validator.Validate(input);
            return new Validation<Contact>
            {
                Result = input,
                ErrorMessagesPerProperty = v.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };
        }
    }

    public class ContactsCreateFluentValidatorModel : AbstractValidator<Contact>
    {
        public ContactsCreateFluentValidatorModel()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProfileId).NotEmpty();
            RuleFor(x => x.Info).NotNull();
            RuleFor(x => x.Info.Email).NotEmpty();
            RuleFor(x => x.Info.Email).EmailAddress();
        }
    }
}
