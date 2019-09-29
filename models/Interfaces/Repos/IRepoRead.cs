using System.Collections.Generic;

namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A repository that has read operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoRead<T> : IRead<T, IEnumerable<T>> where T : Entity
    {

    }
}
