using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_api.Models
{
    public class Section
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SectionId { get; set; }
        public string Meta { get; set; }
        public string Body { get; set; }
        public int ContentId { get; set; }      
    }
}

