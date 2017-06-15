using System.Collections.Generic;

namespace PortfolioApi.Models.Contacts
{
    public class Info: InfoItem
    {
        public string Email { get; set; }
        public List<Phones.Phone> PhoneNumbers { get; set; }
        public List<Addresses.Address> Addresses { get; set; }
    }
}
