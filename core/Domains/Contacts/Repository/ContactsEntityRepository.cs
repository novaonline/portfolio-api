using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Common;
using PortfolioApi.Models;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Interfaces.Repos;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Core.Domains.Contacts.Repository
{
    /// <summary>
    /// Repository Implementation to access Contact Information
    /// </summary>
    public class ContactsEntityRepository : BaseRepo<Contact, ContactInfo>
    {
        private readonly PortfolioContext _portfolioContext;

        public ContactsEntityRepository(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public override Contact Create(Contact input, RequestContext requestContext)
        {
            input.OwnerUserId = requestContext.RequestedUserId;
            var changeTracking = _portfolioContext.Contacts.Add(input);
            var result = _portfolioContext.SaveChanges();
            return input;
        }

        public override Contact Delete(Contact input, RequestContext requestContext)
        {
            var model = _portfolioContext.Contacts.Find(input.Id);
            OwnershipPrecondition(model, requestContext);
            _portfolioContext.Remove(model);
            _portfolioContext.SaveChanges();
            return model;
        }

        public override IEnumerable<Contact> Read(Contact input, RequestContext requestContext)
        {
            if (input.ProfileId != default)
            {
                return _portfolioContext.Contacts
                .Where(x => x.OwnerUserId.Equals(requestContext.RequestedUserId) && x.ProfileId == input.ProfileId);
            }
            else
            {
                var result = new List<Contact>();
                var item = _portfolioContext.Contacts.Find(input.Id);
                OwnershipPrecondition(item, requestContext);
                if (item != null) result.Add(item);
                return result;
            }
        }

        public override Contact Update(Contact search, ContactInfo input, RequestContext requestContext)
        {
            var m = _portfolioContext.Contacts.Find(search.Id);
            OwnershipPrecondition(m, requestContext);
            m.Info = input;
            var result = _portfolioContext.SaveChanges();
            return m;
        }
    }
}
