using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Models.Contents
{
    public class InputGroup
    {
        public string HtmlId { get; set; }
        public Info ContentInfo { get; set; }
        public List<Sections.Info> SectionInfo { get; set; }

        public InputGroup()
        {
            SectionInfo = new List<Sections.Info>();
        }
    }
}
