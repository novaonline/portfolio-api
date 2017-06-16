using System.Collections.Generic;

namespace PortfolioApi.Models.Contacts
{
    public class Info: InfoItem, IPortfolioInfo<Info>
    {
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public Addresses.Type AddressType { get; set; }
        public Phones.Type PhoneType { get; set; }

        public void Update(Info model)
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
