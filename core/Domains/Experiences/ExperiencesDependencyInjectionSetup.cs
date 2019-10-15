using Microsoft.Extensions.DependencyInjection;
using PortfolioApi.Core.Domains.Experiences.Repository;
using PortfolioApi.Core.Domains.Experiences.Validation;
using PortfolioApi.Domains.Experiences.Interfaces;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers.Builder;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;

namespace PortfolioApi.Core.Domains.Experiences
{
    public class ExperiencesDependencyInjectionSetup : IDependencyInjectionSetup
    {
        public void Inject(IServiceCollection services, PortfolioConfiguration config)
        {
            services.AddTransient<IRepoCrud<Experience, ExperienceInfo>, ExperiencesEntityRepository>();
            services.AddTransient<IValidatorCreate<Experience>, ExperiencesCreateFluentValidator>();
            services.AddTransient<IValidatorUpdate<Experience, ExperienceInfo>, ExperiencesUpdateFluentValidator>();
            services.AddTransient<IValidatorDelete<Experience>, ExperiencesDeleteSimpleValidator>();
            services.AddTransient<IExperiencesService, ExperiencesService>();
        }
    }
}
