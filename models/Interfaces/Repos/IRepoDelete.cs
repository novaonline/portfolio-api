namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A Repository that allows delete operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoDelete<T> where T : Entity
    {
        T Delete(T input, RequestContext requestContext);
    }
}
