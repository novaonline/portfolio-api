namespace PortfolioApi.Models.RankableItems.Frameworks
{
    public class Info : InfoItem, IPortfolioInfo<Info>
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public void Update(Info model)
        {
            Description = model.Description;
            ImageUrl = model.ImageUrl;
        }
    }
}
