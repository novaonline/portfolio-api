namespace PortfolioApi.Models.Contents.Sections
{
    public class Section : DateAware
    {
        public Info Info { get; set; }

        public int ContentId { get; set; }
    }
}
