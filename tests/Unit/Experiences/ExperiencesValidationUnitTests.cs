using System;
using System.Collections.Generic;
using PortfolioApi.Core.Domains.Experiences.Validation;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Experiences.Sections;
using PortfolioApi.Models.Interfaces.Validators;
using Xunit;

namespace PortfolioApi.Tests.Unit.ExperienFces
{
    public class ExperiencesValidationUnitTests : IDisposable
    {
        IValidatorCreate<Experience> createValidator;
        IValidatorUpdate<Experience, ExperienceInfo> updateValidator;
        IValidatorDelete<Experience> deleteValidator;

        public ExperiencesValidationUnitTests()
        {
            createValidator = new ExperiencesCreateFluentValidator();
            updateValidator = new ExperiencesUpdateFluentValidator();
            deleteValidator = new ExperiencesDeleteSimpleValidator();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void Contacts_Create_EmptyInput_UnSuccessfulValidation()
        {
            //Given
            var exp = new Experience
            {
                Id = 1,
                Type = "Skill"
            };

            //When
            var result = createValidator.Validate(exp);

            //Then
            Assert.False(result.IsValid, "Empty Info should be invalid");
        }

        [Fact]
        public void Contacts_Update_WrongInput_UnSuccesfulValidation()
        {
            //Given
            var exp = new Experience
            {
                Id = 1,
                Info = new ExperienceInfo
                {
                    Title = "Some Experience",
                    BackgroundUrl = "notAnImageUrl",
                    Sections = new List<ExperienceSection> {
                        new ExperienceSection {
                            Id = 1,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body",
                                Meta = "Some Section Title"
                            }
                        },
                        new ExperienceSection {
                            Id = 2,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body 2",
                                Meta = "Some Section Title 2"
                            }
                        }
                    }
                }
            };

            var expRef = new Experience
            {
                Id = 0,
                Info = new ExperienceInfo
                {
                    Title = "Some Experience",
                    Sections = new List<ExperienceSection> {
                        new ExperienceSection {
                            Id = 1,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body",
                                Meta = "Some Section Title"
                            }
                        },
                        new ExperienceSection {
                            Id = 2,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body 2",
                                Meta = "Some Section Title 2"
                            }
                        }
                    }
                }
            };

            //When
            var resultBadImage = updateValidator.Validate(exp, exp.Info);
            var resultMissingRef = updateValidator.Validate(expRef, expRef.Info);

            //Then
            Assert.False(resultBadImage.IsValid, "Email is not valid and should return unsuccessful");
            Assert.False(resultMissingRef.IsValid, "Reference to item is missing and should return unsuccessful");
        }

        [Fact]
        public void Contacts_Delete_WrongInput_UnSuccesfulValidation()
        {
            //Given
            var c = new Experience
            {
                Id = 0,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            //When
            var result = deleteValidator.Validate(c);

            //Then
            Assert.False(result.IsValid, "Wrong input during delete");
        }

        [Fact]
        public void Contacts_CUD_CorrectInput_SuccesfulValidation()
        {
            //Given
            var exp = new Experience
            {
                Id = 1,
                Type = "Skill",
                Info = new ExperienceInfo
                {
                    Title = "Some Experience",
                    Sections = new List<ExperienceSection> {
                        new ExperienceSection {
                            Id = 1,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body",
                                Meta = "Some Section Title"
                            }
                        },
                        new ExperienceSection {
                            Id = 2,
                            Info = new ExperienceSectionInfo {
                                Body = "Some Section Body 2",
                                Meta = "Some Section Title 2"
                            }
                        }
                    }
                }
            };

            //When
            var resultCreate = createValidator.Validate(exp);
            var resultUpdate = updateValidator.Validate(exp, exp.Info);
            var resultDelete = deleteValidator.Validate(exp);

            //Then
            Assert.True(resultCreate.IsValid);
            Assert.True(resultUpdate.IsValid);
            Assert.True(resultDelete.IsValid);
        }
    }
}
