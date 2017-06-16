using Rank = PortfolioApi.Models.RankableItems.Ranks.Rank;

namespace PortfolioApi.Models.RankableItems
{
    public class RankableItems : DateAware
    {
        public int RankId { get; set; }

        public Rank Rank { get; set; }
    }
}
