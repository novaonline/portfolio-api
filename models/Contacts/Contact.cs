﻿namespace PortfolioApi.Models.Contacts
{
    public class Contact : Entity
    {
        public int ProfileId { get; set; }
        public ContactInfo Info { get; set; }

        public Contact()
        {
            this.Info = new ContactInfo();
        }
    }
}
