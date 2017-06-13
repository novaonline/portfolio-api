using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using portfolio_api.Models.Addresses;
using portfolio_api.Models.Phones;

namespace portfolio_api.Models
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
