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
    public class ExperiencesCreateFluentValidator : IValidatorUpdate<Experience, ExperienceInfo>
    {
        private readonly ExperiencesCreateFluentValidatorModel _validator;
        private readonly ExperiencesInfoCreateFluentValidatorModel _validatorInfo;

        public ExperiencesCreateFluentValidator()
        {
            _validator = new ExperiencesCreateFluentValidatorModel();
            _validatorInfo = new ExperiencesInfoCreateFluentValidatorModel();
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

    public class ExperiencesCreateFluentValidatorModel : AbstractValidator<Experience>
    {

    }

    public class ExperiencesInfoCreateFluentValidatorModel : AbstractValidator<ExperienceInfo>
    {

    }
}
