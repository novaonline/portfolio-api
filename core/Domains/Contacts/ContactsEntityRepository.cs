using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Contacts
{
    /// <summary>
    /// Repository Implementation to access Contact Information
    /// </summary>
    public class ContactsEntityRepository : IRepoCrud<Contact, ContactInfo>
    {
        private readonly PortfolioContext _portfolioContext;

        public ContactsEntityRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public Contact Create(Contact input)
        {
            var changeTracking = _portfolioContext.Contacts.Add(input);
            var result = _portfolioContext.SaveChanges();
            return input;
        }

        public Contact Delete(Contact input)
        {
            var model = _portfolioContext.Contacts.Find(input.Id);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public IEnumerable<Contact> Get(Contact input)
        {
            if (input.ProfileId != default(int))
            {
                return _portfolioContext.Contacts
                .Where(x => x.ProfileId == input.ProfileId);
            }
            else
            {
                var result = new List<Contact>();
                var item = _portfolioContext.Contacts.Find(input.Id);
                if(item != null) result.Add(item);
                return result;
            }
        }

        public Contact Update(Contact search, ContactInfo input)
        {
             var m = _portfolioContext.Contacts.Find(search.Id);
            m.Info = input;
            var result = _portfolioContext.SaveChanges();
            return m;
        }
    }
}
