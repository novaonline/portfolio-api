using System.Collections.Generic;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ExperiencesDeleteSimpleValidator : IValidatorDelete<Experience>
    {
        public ExperiencesDeleteSimpleValidator() { }
        public Validation<Experience> Validate(Experience input)
        {
            if (input.Id == default)
            {
                return new Validation<Experience>
                {
                    Result = input,
                    ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>
                    {
                        {nameof(input.Id), new List<ValidationErrorMessage> { new ValidationErrorMessage("Id is required") }}
                    }
                };
            }

            return new Validation<Experience>
            {
                Result = input,
                ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>()
            };
        }
    }
}
