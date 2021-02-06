namespace PortfolioApi.Models.Contacts
{
    public class Contact : OwnedEntity
    {
        public int ProfileId { get; set; }
        public ContactInfo Info { get; set; }

        public Contact()
        {
            this.Info = new ContactInfo();
        }

        public Contact(int Id) : this()
        {
            this.Id = Id;
        }
    }
}
