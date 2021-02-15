using System;
using System.Linq;
using FluentValidation;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Experiences.Sections;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ExperiencesCreateFluentValidator : IValidatorCreate<Experience>
    {
        private readonly ExperiencesCreateFluentValidatorModel _validator;
        private readonly ExperiencesInfoCreateFluentValidatorModel _validatorInfo;

        public ExperiencesCreateFluentValidator()
        {
            _validator = new ExperiencesCreateFluentValidatorModel();
            _validatorInfo = new ExperiencesInfoCreateFluentValidatorModel();
        }
        public Validation<Experience> Validate(Experience input)
        {
            var v = _validator.Validate(input);
            return new Validation<Experience>
            {
                Result = input,
                ErrorMessagesPerProperty = v.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(f => new ValidationErrorMessage(f.ErrorMessage)).ToList())
            };
        }
    }

    public class ExperiencesCreateFluentValidatorModel : AbstractValidator<Experience>
    {
        public ExperiencesCreateFluentValidatorModel()
        {
            //RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Type).NotEmpty();
            RuleFor(x => x.Info.Title)
            .NotEmpty()
            .When(x => x.Info != null);

            RuleFor(p => p.Info.BackgroundUrl)
            .Matches(@"\.(?:jpg|gif|png)")
            .WithMessage("Image is not supported or formatted correctly")
            .When(x => !String.IsNullOrEmpty(x.Info?.BackgroundUrl));

            RuleForEach(x => x.Info.Sections)
            .SetValidator(new ExperienceSectionCreateAbstractValidator())
            .When(x => x.Info != null);

        }
    }

    public class ExperiencesInfoCreateFluentValidatorModel : AbstractValidator<ExperienceInfo>
    {
        public ExperiencesInfoCreateFluentValidatorModel()
        {
                    }
    }

    public class ExperienceSectionCreateAbstractValidator : AbstractValidator<ExperienceSection>
    {
        public ExperienceSectionCreateAbstractValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Info.Body).NotEmpty();
            RuleFor(x => x.Info.Meta).NotEmpty();
        }
    }
}
