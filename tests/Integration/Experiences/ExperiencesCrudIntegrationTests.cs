using System;
using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Experiences.Repository;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Experiences.Sections;
using Xunit;

namespace PortfolioApi.Tests.Integration.Experiences
{
    public class ExperiencesCrudIntegrationTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public ExperiencesCrudIntegrationTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Experiences_FullCrud_Succesful()
        {
            //Given
            var profile = new Experience
            {
                Id = 1,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Type = "Skill",
                Info = new ExperienceInfo
                {
                    BackgroundUrl = "http://homepage.usask.ca/~eeq488/images/me_outside_cropped.jpg",
                    Title = "Test Driven Development",
                    Sections = new List<Models.Experiences.Sections.ExperienceSection> {
                        new ExperienceSection {
                            Id = 1,
                            AddDate = DateTime.UtcNow,
                            UpdateDate = DateTime.UtcNow,
                            Info = new ExperienceSectionInfo {
                                Body = "Test Section Body",
                                Meta = "Test Section Meta"
                            }
                        }
                    }
                },

            };

            var repo = new ExperiencesEntityRepository(fixture._portfolioContext);

            //When
            var experienceId = new Experience { Id = 1 };
            var rCreate = repo.Create(profile);
            var rGetList = repo.Read(experienceId);
            var rGet = rGetList.First();
            var updatedValue = "The new TDD Pattern";
            rGet.Info.Title = updatedValue;
            var rUpdate = repo.Update(experienceId, rGet.Info);
            var rUpdateOutput = repo.Read(experienceId);
            var rDelete = repo.Delete(experienceId);
            var rDeleteOutput = repo.Read(experienceId);

            //Then
            Assert.Equal(profile, rCreate);
            Assert.Equal(profile, rGet);
            Assert.Equal(rUpdate.Info.Title, updatedValue);
            Assert.True(rUpdate.Info.Title.Equals(rUpdateOutput.First().Info.Title), "The property was updated succesfully");
            Assert.Empty(rDeleteOutput);
        }
    }
}
