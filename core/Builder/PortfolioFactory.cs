namespace PortfolioApi.Core.Builder
{
    public class PortfolioFactory : PortfolioPersistenceBuilder<PortfolioFactory>
    {
        public static PortfolioFactory NewFactory => new PortfolioFactory();

    }
}
