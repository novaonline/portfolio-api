using System;
using System.Linq;
using PortfolioApi.Core.Domains.Profiles.Validation;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;
using Xunit;

namespace PortfolioApi.Tests.Unit.Profiles
{
    public class ProfilesValidationUnitTests
    {
        private readonly IValidatorCreate<Profile> _validator;

        public ProfilesValidationUnitTests()
        {
            _validator = new ProfilesFluentValidator();
        }


        [Fact]
        public void Profiles_HappyPathInput_SuccessfulValidation()
        {
            //Given
            var profile = new Profile
            {
                Id = 1,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Info = new ProfileInfo
                {
                    AboutMe = "I'm me",
                    BirthDate = new DateTime(1992, 08, 13),
                    FirstName = "Emmanuel",
                    LastName = "Quagraine",
                    ImageUrl = "http://homepage.usask.ca/~eeq488/images/me_outside_cropped.jpg"
                }
            };
            //When
            var result = _validator.Validate(profile);

            //Then
            Assert.True(result.IsValid, "All fields should be valid entries");
            Assert.True(!result.ErrorMessagesPerProperty.Any(), "Error list should be empty because its valid");
            Assert.Equal(profile, result.Result);
        }
    }
}
