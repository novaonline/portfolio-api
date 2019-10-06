using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Domains.Experiences.Interfaces;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences
{
    /// <summary>
    /// Main Experiences Logic
    /// </summary>
    public class ExperiencesService : BaseService<Experience, ExperienceInfo>, IExperiencesService
    {

        public ExperiencesService(
            IRepoCrud<Experience, ExperienceInfo> profileRepo,
            IValidatorCreate<Experience> validateForCreation,
            IValidatorUpdate<Experience, ExperienceInfo> validateForUpdate,
            IValidatorDelete<Experience> validateForDelete) : base(profileRepo, validateForCreation, validateForUpdate, validateForDelete)
        { 
            
        }
    }
}
