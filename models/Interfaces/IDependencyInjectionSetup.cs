using Microsoft.Extensions.DependencyInjection;
using PortfolioApi.Models.Helpers.Builder;

namespace PortfolioApi.Models.Interfaces
{
    public interface IDependencyInjectionSetup
    {
        void Inject(IServiceCollection services, PortfolioConfiguration config);
    }
}
