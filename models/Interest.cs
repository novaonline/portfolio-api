using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class Interest
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        public string Description { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
    }
}
