using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Interfaces;

namespace core.Domains.Experiences.Interfaces
{
    public interface IExperiencesService : ICrud<Experience, ServiceMessage<Experience>>
    {

    }
}
