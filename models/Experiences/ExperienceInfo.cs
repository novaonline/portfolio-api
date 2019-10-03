using System.Collections.Generic;
using ExperienceSection = PortfolioApi.Models.Experiences.Sections.ExperienceSection;

namespace PortfolioApi.Models.Experiences
{
    public class ExperienceInfo : Info
    {
        public string Title { get; set; }

        public string BackgroundUrl { get; set; }

        public int ExperienceYears { get; set; }

        public List<ExperienceSection> Sections { get; set; }

        public ExperienceInfo()
        {
            Sections = new List<ExperienceSection>();
        }

        public ExperienceInfo(ExperienceInfo model) : this()
        {
            Title = model.Title;
            BackgroundUrl = model.BackgroundUrl;
            ExperienceYears = model.ExperienceYears;
            Sections = model.Sections ?? new List<ExperienceSection>();
        }
    }
}
