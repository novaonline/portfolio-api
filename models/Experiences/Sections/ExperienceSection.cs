namespace PortfolioApi.Models.Experiences.Sections
{
    public class ExperienceSection : Entity
    {
        public ExperienceSectionInfo Info { get; set; }

        public ExperienceSection()
        {
            this.Info = new ExperienceSectionInfo();
        }
    }
}
