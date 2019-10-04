using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Models
{
    /// <summary>
    /// Making a Model Date Aware of the following:
    /// The date it was created
    /// The date it was updated
    /// All Dates are stored using the UTC time zone
    /// </summary>
    public class Entity : IdentityItem 
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdateDate { get; set; }

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.UtcNow;
        }
    }
}
