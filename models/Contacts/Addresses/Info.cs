namespace PortfolioApi.Models.Contacts.Addresses
{
    public class Info : InfoItem
    {
        public Type Type { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
    }
}
