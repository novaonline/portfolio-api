namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A repository that has update operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoUpdate<T> : IUpdate<T, T> where T : Entity
    {

    }
}
