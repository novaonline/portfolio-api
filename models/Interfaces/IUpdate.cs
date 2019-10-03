namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// General update of entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdate<S, I, O> 
    {
         O Update(S search, I input);
    }
}
