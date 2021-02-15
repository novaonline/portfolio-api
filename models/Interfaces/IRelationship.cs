using PortfolioApi.Models;

namespace PortfolioApi.Models.Interfaces
{
    /// <summary>
    /// Relationship between two entities
    /// </summary>
    /// <typeparam name="L">Left Entity</typeparam>
    /// <typeparam name="R">Right Entity</typeparam>
    public interface IRelationship<L,R> 
    where L : Entity 
    where R : Entity
    {
        
    }
}
