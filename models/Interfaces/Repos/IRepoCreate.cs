namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// Repository with Create abilitiy
    /// </summary>
    /// <typeparam name="T">An Entity</typeparam>
    public interface IRepoCreate<T> where T : Entity
    {
        T Create(T input, RequestContext requestContext);
    }
}
