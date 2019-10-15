using core.Domains.Profiles.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApi.Core.Domains.Profiles.Repository;
using PortfolioApi.Core.Domains.Profiles.Validation;
using PortfolioApi.Models.Helpers.Builder;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Models.Interfaces.Validators;
using PortfolioApi.Models.Profiles;

namespace PortfolioApi.Core.Domains.Profiles
{
    public class ProfilesDependencyInjectionSetup : IDependencyInjectionSetup
    {
        public void Inject(IServiceCollection services, PortfolioConfiguration config)
        {
            services.AddTransient<IRepoCrud<Profile, ProfileInfo>, ProfilesEntityRepository>();
            services.AddTransient<IValidatorCreate<Profile>, ProfilesCreateFluentValidator>();
            services.AddTransient<IValidatorUpdate<Profile, ProfileInfo>, ProfilesUpdateFluentValidator>();
            services.AddTransient<IValidatorDelete<Profile>, ProfilesDeleteSimpleValidator>();
            services.AddTransient<IProfilesService, ProfilesService>();
        }
    }
}
