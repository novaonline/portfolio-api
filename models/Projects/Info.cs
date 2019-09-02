using PortfolioApi.Models.Interfaces;

namespace PortfolioApi.Models.Projects
{
	public class Info : InfoItem, IPortfolioInfo<Info>
    {
        public string Description { get; set; }
        public string Url { get; set; }

        public void Update(Info model)
        {
            Description = model.Description;
            Url = model.Url;
        }
    }
}
