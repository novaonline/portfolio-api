namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General update of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdate<I, O> 
    {
         O Update(I input);
    }
}
