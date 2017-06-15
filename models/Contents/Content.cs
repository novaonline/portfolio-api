using System.Collections.Generic;
using Section = PortfolioApi.Models.Contents.Sections.Section;

namespace PortfolioApi.Models.Contents
{
    public class Content : DateAware
    {
        public Info Info { get; set; }

        public List<Section> Sections { get; set; }
    }
}
