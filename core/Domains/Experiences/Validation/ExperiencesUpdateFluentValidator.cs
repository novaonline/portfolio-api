using System.Linq;
using FluentValidation;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ExperiencesUpdateFluentValidator : IValidatorUpdate<Experience, ExperienceInfo>
    {
        private readonly ExperiencesUpdateFluentValidatorModel _validator;
        private readonly ExperiencesInfoUpdateFluentValidatorModel _validatorInfo;

        public ExperiencesUpdateFluentValidator()
        {
            _validator = new ExperiencesUpdateFluentValidatorModel();
            _validatorInfo = new ExperiencesInfoUpdateFluentValidatorModel();
        }
        public Validation<Experience> Validate(Experience search, ExperienceInfo input)
        {
            var vSearch = _validator.Validate(search);
            var vInfo = _validatorInfo.Validate(input);
            return new Validation<Experience>
            {
                Result = search,
                ErrorMessagesPerProperty = vSearch.IsValid ? vInfo.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList()) : vSearch.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };
        }
    }

    public class ExperiencesUpdateFluentValidatorModel : AbstractValidator<Experience>
    {

    }

    public class ExperiencesInfoUpdateFluentValidatorModel : AbstractValidator<ExperienceInfo>
    {

    }
}
