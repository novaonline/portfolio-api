namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General creation of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreate<I, O>
    {
         O Create(I input);
    }
}
