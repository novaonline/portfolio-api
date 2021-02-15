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
                ErrorMessagesPerProperty = (vSearch.IsValid) ? vInfo.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList()) : vSearch.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
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
            
            RuleFor(p => p.BirthDate)
            .GreaterThan(DateTime.UtcNow.AddYears(-200))
            .WithMessage("Valid birthdate please!")
            .When(x => x.BirthDate.HasValue);

            RuleFor(p => p.ImageUrl)
            .Matches(@"\.(?:jpg|gif|png)")
            .WithMessage("Image is not supported or formatted correctly")
            .When(x => !String.IsNullOrEmpty(x.ImageUrl));
        }
    }
}
