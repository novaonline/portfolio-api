using System.Collections.Generic;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;

namespace PortfolioApi.Core.Domains.Profiles.Validation
{
    /// <summary>
    /// The validation of Profile entities
    /// </summary>
    public class ProfilesDeleteSimpleValidator : IValidatorDelete<Profile>
    {
        public ProfilesDeleteSimpleValidator() { }

        public Validation<Profile> Validate(Profile input)
        {
            if (input.Id == default(int))
            {
                return new Validation<Profile>
                {
                    Result = input,
                    ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>
                    {
                        {nameof(input.Id), new List<ValidationErrorMessage> { new ValidationErrorMessage("Id is required") }}
                    }
                };
            }

            return new Validation<Profile>
            {
                Result = input,
                ErrorMessagesPerProperty = new Dictionary<string, List<ValidationErrorMessage>>()
            };
        }
    }
}
