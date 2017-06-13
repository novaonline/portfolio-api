using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portfolio_api.Models
{
    public class RankableItem
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }


        public int RankId { get; set; }
        public Rank Rank { get; set; }
    }
}
