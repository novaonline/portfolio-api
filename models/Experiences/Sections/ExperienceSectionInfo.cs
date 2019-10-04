namespace PortfolioApi.Models.Experiences.Sections
{
	public class ExperienceSectionInfo : Info<ExperienceSectionInfo>
    {
        public string? Meta { get; set; }
        public string? Body { get; set; }

        public ExperienceSectionInfo() { }

        public ExperienceSectionInfo(ExperienceSectionInfo model) : this()
        {
            UpdateProperties(model);
        }

        public override void UpdateProperties(ExperienceSectionInfo update)
        {
            this.Body = update.Body ?? this.Body;
            this.Meta = update.Meta ?? this.Meta;
        }
    }
}
