namespace PortfolioApi.Models.Experiences
{
    public class Experience : Entity
    {
        public string Type { get; set; }

        public ExperienceInfo Info { get; set; }

        public Experience()
        {
            this.Type = "Skill";
            this.Info = new ExperienceInfo();
        }
    }
}
