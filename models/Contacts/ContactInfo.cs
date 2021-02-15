using System.Collections.Generic;

namespace PortfolioApi.Models.Contacts
{
    public class ContactInfo : Info<ContactInfo>
    {
        public string? Email { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public Addresses.AddressType? AddressType { get; set; }
        public Phones.PhoneType? PhoneType { get; set; }

        public ContactInfo() { }
        public ContactInfo(ContactInfo model)
        {
            UpdateProperties(model);
        }

        public override void UpdateProperties(ContactInfo update)
        {
            this.AddressType = update.AddressType ?? this.AddressType;
            this.City = update.City ?? this.City;
            this.Country = update.Country ?? this.Country;
            this.Email = update.Email ?? this.Email;
            this.PhoneNumber = update.PhoneNumber ?? this.PhoneNumber;
            this.PhoneType = update.PhoneType ?? this.PhoneType;
            this.Postal = update.Postal ?? this.Postal;
            this.State = update.State ?? this.State;
        }
    }
}
