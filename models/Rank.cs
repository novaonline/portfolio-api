using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class Rank
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RankId { get; set; }
        public string Description { get; set; }  

    }
}
