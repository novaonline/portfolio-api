namespace PortfolioApi.Models.Helpers.Builder
{
    public class PortfolioConfiguration
    {
        public PersistenceSettings DefaultPersistenceSettings { get; set; }
        public PersistenceSettings? MainPersistenceSettings { get; set; }
        public PersistenceSettings? ExperienceRelationshipPersistenceSettings { get; set; }
        public bool AutoMigration {get; set;}

        public PortfolioConfiguration()
        {
            AutoMigration = true;
            DefaultPersistenceSettings = new PersistenceSettings
            {
                PersistenceType = PersistenceType.InMemorySqlSever,
                ConnectionString = "DataSource=:memory:"
            };
        }

        public void Resolve()
        {
            MainPersistenceSettings ??= DefaultPersistenceSettings;
            ExperienceRelationshipPersistenceSettings ??= DefaultPersistenceSettings;
        }
    }
}
