namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A repository that has update operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoUpdate<T, O> : IUpdate<O, T, O> where T : Info where O : Entity
    {

    }
}
