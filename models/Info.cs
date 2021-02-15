using PortfolioApi.Models.Interfaces;

namespace PortfolioApi.Models
{
    public abstract class Info<T> : IInfo<T>
    {
        public abstract void UpdateProperties(T update);
    }
}
