using System;
using System.Linq;
using PortfolioApi.Core.Domains.Profiles.Repository;
using PortfolioApi.Models.Profiles;
using Xunit;

namespace PortfolioApi.Tests.Integration.Profiles
{
    // https://xunit.net/docs/shared-context
    public class ProfilesCrudIntegrationTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public ProfilesCrudIntegrationTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Profiles_FullCrud_Succesful()
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

            var repo = new ProfilesEntityRepository(fixture._portfolioContext);

            //When
            var profileWithJustId = new Profile { Id = 1 };
            var rCreate = repo.Create(profile);
            var rGetList = repo.Get(profileWithJustId);
            var rGet = rGetList.First();
            var aboutMeUpdateExpected = "I'm you";
            rGet.Info.AboutMe = aboutMeUpdateExpected;
            var rUpdate = repo.Update(profileWithJustId, rGet.Info);
            var rUpdateOutput = repo.Get(profileWithJustId);
            var rDelete = repo.Delete(profileWithJustId);
            var rDeleteOutput = repo.Get(profileWithJustId);

            //Then
            Assert.Equal(profile, rCreate);
            Assert.Equal(profile, rGet);
            Assert.Equal(rUpdate.Info.AboutMe, aboutMeUpdateExpected);
            Assert.True(rUpdate.Info.AboutMe.Equals(rUpdateOutput.First().Info.AboutMe), "The property was updated succesfully");
            Assert.Empty(rDeleteOutput);



        }
    }
}
