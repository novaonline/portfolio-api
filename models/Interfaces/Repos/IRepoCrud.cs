namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// Facade for a simple CRUD repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoCrud<T> : IRepoCreate<T>,
    IRepoRead<T>,
    IRepoUpdate<T>,
    IRepoDelete<T> where T : Entity
    {

    }
}
