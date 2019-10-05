using System.Collections.Generic;
using System.Linq;
using ExperienceSection = PortfolioApi.Models.Experiences.Sections.ExperienceSection;

namespace PortfolioApi.Models.Experiences
{
    public class ExperienceInfo : Info<ExperienceInfo>
    {
        public string? Title { get; set; }

        public string? BackgroundUrl { get; set; }

        public List<ExperienceSection>? Sections { get; set; }

        public ExperienceInfo() { }

        public ExperienceInfo(ExperienceInfo model) : this()
        {
            UpdateProperties(model);
        }

        public override void UpdateProperties(ExperienceInfo update)
        {
            this.BackgroundUrl = update.BackgroundUrl ?? this.BackgroundUrl;
            this.Sections = update.Sections ?? this.Sections ?? new List<ExperienceSection>();
            this.Title = update.Title ?? this.Title;
        }
    }
}
