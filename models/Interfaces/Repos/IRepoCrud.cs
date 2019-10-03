namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// Facade for a simple CRUD repository
    /// </summary>
    /// <typeparam name="T">The Entity</typeparam>
    /// <typeparam name="U">Info Type</typeparam>
    public interface IRepoCrud<T,U> : IRepoCreate<T>,
    IRepoRead<T>,
    IRepoUpdate<U, T>,
    IRepoDelete<T> where T : Entity where U : Info
    {

    }
}
