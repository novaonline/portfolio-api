using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences
{
    /// <summary>
    /// The Validation of Experience entities
    /// </summary>
    public class ExperiencesValidator : IValidatorUpdate<Experience>
    {
        public Models.Helpers.Validation<Experience> Validate(Experience input)
        {
            throw new System.NotImplementedException();
        }
    }
}
