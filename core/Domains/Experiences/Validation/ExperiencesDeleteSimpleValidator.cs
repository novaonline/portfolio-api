using System.Collections.Generic;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences.Validation
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ExperiencesDeleteSimpleValidator : IValidatorUpdate<Experience, ExperienceInfo>
    {
        public ExperiencesDeleteSimpleValidator() { }
        public Validation<Experience> Validate(Experience search, ExperienceInfo input)
        {
            if (search.Id == default)
            {
                return new Validation<Experience>
                {
                    Result = search,
                    ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>
                    {
                        {nameof(search.Id), new List<ValidationErrorMessage> { new ValidationErrorMessage("Id is required") }}
                    }
                };
            }

            return new Validation<Experience>
            {
                Result = search,
                ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>()
            };
        }
    }
}
