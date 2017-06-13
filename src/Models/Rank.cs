using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_api.Models
{
    public class Rank
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RankId { get; set; }
        public string Description { get; set; }  

    }
}
