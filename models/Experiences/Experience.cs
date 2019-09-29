namespace PortfolioApi.Models.Experiences
{
    public class Experience : Entity
    {
        public string Type { get; set; }

        public ExperienceInfo Info {get; set;}
    }
}
