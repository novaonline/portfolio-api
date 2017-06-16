namespace PortfolioApi.Models.RankableItems.Libraries
{
    public class Info : InfoItem, IPortfolioInfo<Info>
    {
        public string Description { get; set; }

        public void Update(Info model)
        {
            Description = model.Description;
        }
    }
}
