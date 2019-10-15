namespace PortfolioApi.Models.Experiences
{
    public class Experience : Entity
    {
        public string? Type { get; set; }

        public ExperienceInfo Info { get; set; }

        public Experience()
        {
            this.Info = new ExperienceInfo();
        }

        public Experience(int Id) : this()
        {
            this.Id = Id;
        }
    }
}
