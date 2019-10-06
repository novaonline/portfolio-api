using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Services
{
    public interface IService<T, I>  where T : Entity, new() where I : IInfo<I>
    {
        ServiceMessage<T> Create(T input);
        ServiceMessages<T> Read(T input);
        ServiceMessage<T> Update(T search, I input);
        ServiceMessage<T> Delete(T input);

        
    }
}
