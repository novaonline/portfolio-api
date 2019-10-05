namespace PortfolioApi.Models.Interfaces
{
    public interface IInfo<T>
    {
        void UpdateProperties(T input);
    }
}
