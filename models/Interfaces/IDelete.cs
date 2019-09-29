namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General Removal of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDelete<I, O>
    {
        O Delete(I input);
    }
}
