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
    public class ProfilesUpdateFluentValidator : IValidatorUpdate<Profile, ProfileInfo>
    {
        private readonly ProfilesUpdateFluentValidatorModel _validator;
        private readonly ProfilesInfoUpdateFluentValidatorModel _validatorInfo;


        public ProfilesUpdateFluentValidator()
        {
            _validator = new ProfilesUpdateFluentValidatorModel();
            _validatorInfo = new ProfilesInfoUpdateFluentValidatorModel();
        }
        public Validation<Profile> Validate(Profile search, ProfileInfo input)
        {
            // TODO: Create input clean up for adjust values.
            var vSearch = _validator.Validate(search);
            var vInfo = _validatorInfo.Validate(input);

            return new Validation<Profile>
            {
                Result = search,
                ErrorMessagesPerProperty = (vSearch.IsValid) ? vInfo.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())  : vSearch.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };

        }
    }

    public class ProfilesUpdateFluentValidatorModel : AbstractValidator<Profile>
    {
        public ProfilesUpdateFluentValidatorModel()
        {
            RuleFor(p => p.Id).NotEqual(default(int));
        }
    }

    public class ProfilesInfoUpdateFluentValidatorModel : AbstractValidator<ProfileInfo>
    {
        public ProfilesInfoUpdateFluentValidatorModel()
        {
            RuleFor(p => p).NotNull();
            RuleFor(p => p.AboutMe).NotEmpty().WithMessage("Please tell us about yourself. People want to know!");
            RuleFor(p => p.BirthDate).GreaterThan(DateTime.UtcNow.AddYears(-500)).WithMessage("Valid birthdate please!");
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.ImageUrl).Custom((p, ctx) =>
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
