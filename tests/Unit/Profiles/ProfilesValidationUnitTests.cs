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
        private readonly IValidatorCreate<Profile> createValidator;
        private readonly IValidatorUpdate<Profile, ProfileInfo> updateValidator;
        private readonly IValidatorDelete<Profile> deleteValidator;

        public ProfilesValidationUnitTests()
        {
            createValidator = new ProfilesCreateFluentValidator();
            updateValidator = new ProfilesUpdateFluentValidator();
            deleteValidator = new ProfilesDeleteSimpleValidator();
        }


        [Fact]
        public void Profiles_CUD_CorrectInput_SuccessfulValidation()
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
            var createResult = createValidator.Validate(profile);
            var updateResult = updateValidator.Validate(profile, profile.Info);
            var deleteResult = deleteValidator.Validate(profile);

            //Then
            Assert.True(createResult.IsValid, "All fields should be valid entries");
            Assert.True(!createResult.ErrorMessagesPerProperty.Any(), "Error list should be empty because its valid");
            Assert.Equal(profile, createResult.Result);

            Assert.True(updateResult.IsValid);
            Assert.True(deleteResult.IsValid);
        }

        [Fact]
        public void Profiles_Create_EmptyInput_UnSuccessfulValidation()
        {
            //Given
            var p = new Profile
            {
                Id = 1,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            //When
            var result = createValidator.Validate(p);

            //Then
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Profiles_Update_WrongInput_UnSuccessfulValidation()
        {
            //Given
            var p = new Profile
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
                    ImageUrl = "http://homepage.usask.ca/~eeq488/images/me_outside_cropped.mp4"
                }
            };

            var p2 = new Profile
            {
                Id = 1,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Info = new ProfileInfo
                {
                    AboutMe = "I'm me",
                    BirthDate = new DateTime(1700, 08, 13),
                    FirstName = "Emmanuel"
                }
            };

            //When
            var result = updateValidator.Validate(p, p.Info);
            var result2 = updateValidator.Validate(p2, p2.Info);


            //Then
            Assert.False(result.IsValid);
            Assert.False(result2.IsValid);
            Assert.NotEmpty(result2.ErrorMessagesPerProperty);
        }

        [Fact]
        public void Profiles_Delete_MissingReference_UnsuccessfilValidation()
        {
            //Given
            var p = new Profile
            {
                Id = 0,
            };

            //When
            var result = deleteValidator.Validate(p);

            //Then
            Assert.False(result.IsValid);
        }
    }
}
