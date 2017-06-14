using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models.Addresses
{
    public class Address
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public AddressType Type { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
    }
}
