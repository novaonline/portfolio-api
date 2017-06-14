using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class RankableItem
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }


        public int RankId { get; set; }
        public Rank Rank { get; set; }
    }
}
