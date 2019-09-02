using PortfolioApi.Models.Interfaces;

namespace PortfolioApi.Models.RankableItems.Languages
{
	public class Info: InfoItem, IPortfolioInfo<Info>
    {
        public string Description { get; set; }

        public void Update(Info model)
        {
            Description = model.Description;
        }
    }
}
