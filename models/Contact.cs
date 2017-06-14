using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PortfolioApi.Models.Addresses;
using PortfolioApi.Models.Phones;

namespace PortfolioApi.Models
{
    /// <summary>
    /// Contact Information
    /// </summary>
    public class Contact
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
