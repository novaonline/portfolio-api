using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PortfolioApi.Models.Addresses;
using PortfolioApi.Models.Phones;

namespace PortfolioApi.Models
{
    /// <summary>
    /// Contact Information
    /// </summary>
    public class Client
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]        
        public string Secret { get; set; }
        public string Name { get; set; }
    }
}
