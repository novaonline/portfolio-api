namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General create, read, update, delete of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrud<I, U, O> : ICreate<I, O>, IRead<I, O>, IUpdate<I, U, O>, IDelete<I, O>
    {

    }
}
