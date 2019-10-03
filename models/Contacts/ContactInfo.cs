using System.Collections.Generic;

namespace PortfolioApi.Models.Contacts
{
    public class ContactInfo : Info
    {
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public Addresses.AddressType AddressType { get; set; }
        public Phones.PhoneType PhoneType { get; set; }

        public ContactInfo() { }
        public ContactInfo(ContactInfo model)
        {
            Email = model.Email;
            StreetAddress = model.StreetAddress;
            City = model.City;
            State = model.State;
            Postal = model.Postal;
            Country = model.Country;
            PhoneNumber = model.PhoneNumber;
            AddressType = AddressType;
            PhoneType = PhoneType;
        }
    }
}
