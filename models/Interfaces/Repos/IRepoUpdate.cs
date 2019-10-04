namespace PortfolioApi.Models.Interfaces.Repos
{
    /// <summary>
    /// A repository that has update operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepoUpdate<T, O>  where O : Entity where T : IInfo<T>
    {
        O Update(O search, T input);
    }
}
