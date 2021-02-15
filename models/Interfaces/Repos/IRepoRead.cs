using System.Collections.Generic;

namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A repository that has read operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoRead<T> where T : Entity
    {
        IEnumerable<T> Read(T input, RequestContext requestContext);
    }
}
