using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class Content
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContentId { get; set; }
        public string HtmlId { get; set; }
        public string Header { get; set; }
        public string BackgroundUrl { get; set; }
        public int SectionId { get; set; }

        public List<Section> Sections { get; set; }
    }
}
