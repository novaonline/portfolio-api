namespace PortfolioApi.Models.Contacts.Addresses
{
    public class Address : DateAware
    {
        public Info Info { get; set; }

        public int ContactId { get; set; }
    }
}
