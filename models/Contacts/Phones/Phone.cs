namespace PortfolioApi.Models.Contacts.Phones
{
    public class Phone : DateAware
    {
        public Info Info { get; set; }

        public int ContactId { get; set; }
    }
}
