namespace PortfolioApi.Models.Experiences.Sections
{
	public class ExperienceSectionInfo
    {
        public string Meta { get; set; }
        public string Body { get; set; }

        public ExperienceSectionInfo() { }

        public ExperienceSectionInfo(ExperienceSectionInfo model) : this()
        {
            Meta = model.Meta;
            Body = model.Body;
        }
    }
}
