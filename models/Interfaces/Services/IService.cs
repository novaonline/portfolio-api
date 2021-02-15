using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Models.Interfaces.Services
{
    public interface IService<T, I>  where T : Entity, new() where I : IInfo<I>
    {
        ServiceMessage<T> Create(T input, RequestContext requestContext);
        ServiceMessages<T> Read(T input, RequestContext requestContext);
        ServiceMessage<T> Update(T search, I input, RequestContext requestContext);
        ServiceMessage<T> Delete(T input, RequestContext requestContext);

        
    }
}
