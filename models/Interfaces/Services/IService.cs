using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Services
{
    public interface IService<T, I> : ICrud<T, I, ServiceMessage<T>> where T : Entity
    {

    }
}
