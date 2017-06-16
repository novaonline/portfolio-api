namespace PortfolioApi.Models.Projects
{
    public class Project : DateAware
    {
        public string Title { get; set; }
        public Info Info { get; set; }
    }
}
