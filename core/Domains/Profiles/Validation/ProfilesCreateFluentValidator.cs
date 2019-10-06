using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;

namespace PortfolioApi.Core.Domains.Profiles.Validation
{
    /// <summary>
    /// The validation of Profile entities
    /// </summary>
    public class ProfilesCreateFluentValidator : IValidatorCreate<Profile>
    {
        private readonly ProfilesCreateFluentValidatorModel _validator;

        public ProfilesCreateFluentValidator()
        {
            _validator = new ProfilesCreateFluentValidatorModel();
        }
        public Validation<Profile> Validate(Profile input)
        {
            // TODO: Create input clean up for adjust values.
            var v = _validator.Validate(input);

            // TODO: Turn this into a common function. Maybe as a base.
            return new Validation<Profile>
            {
                Result = input,
                ErrorMessagesPerProperty = v.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };
        }
    }

    public class ProfilesCreateFluentValidatorModel : AbstractValidator<Profile>
    {
        public ProfilesCreateFluentValidatorModel()
        {
            RuleFor(p => p.Info).NotNull();
            RuleFor(p => p.Info.AboutMe).NotEmpty().WithMessage("Please tell us about yourself. People want to know!");
            RuleFor(p => p.Info.BirthDate).GreaterThan(DateTime.UtcNow.AddYears(-500)).WithMessage("Valid birthdate please!");
            RuleFor(p => p.Info.FirstName).NotEmpty();
            RuleFor(p => p.Info.LastName).NotEmpty();
            RuleFor(p => p.Info.ImageUrl).Custom((p, ctx) =>
            {
                if (!String.IsNullOrEmpty(p)
                && !Regex.Match(p, @"\.(?:jpg|gif|png)").Success)
                {
                    ctx.AddFailure("Image is not supported or formatted correctly");
                }
            });
        }
    }

}
