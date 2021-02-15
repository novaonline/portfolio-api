using System.Collections.Generic;
using System.Linq;
using PortfolioApi.Core.Domains.Contacts.Repository;
using PortfolioApi.Models;
using PortfolioApi.Models.Contacts;
using Xunit;

namespace PortfolioApi.Tests.Integration.Contacts
{
    public class ContactsCrudIntegrationTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;
		private readonly RequestContext requestContext;

		public ContactsCrudIntegrationTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            this.requestContext = new Models.RequestContext(
              new List<System.Security.Claims.Claim>() { new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "123") });
        }

        [Fact]
        public void Contacts_FullCrud_Succesful()
        {
            var contacts = new Contact
            {
                Id = 1,
                ProfileId = 1,
                Info = new ContactInfo
                {
                    AddressType = Models.Contacts.Addresses.AddressType.Permanent,
                    City = "Winnipeg",
                    Country = "Canada",
                    Email = "abc@hotmail.com",
                    PhoneNumber = "(000) 555 1234",
                    PhoneType = Models.Contacts.Phones.PhoneType.Cell,
                    Postal = "A1A 0B0",
                    State = "Manitoba",
                    StreetAddress = "123 Elm Street"
                }
            };

            var repo = new ContactsEntityRepository(fixture._portfolioContext);

            //When
            var contactWithJustId = new Contact { Id = 1 };
            var rCreate = repo.Create(contacts, requestContext);
            var rGetList = repo.Read(contactWithJustId, requestContext);
            var rGet = rGetList.First();
            var aboutMeUpdateExpected = "Brandon";
            rGet.Info.City = aboutMeUpdateExpected;
            var rUpdate = repo.Update(contactWithJustId, rGet.Info, requestContext);
            var rUpdateOutput = repo.Read(contactWithJustId, requestContext);
            var rDelete = repo.Delete(contactWithJustId, requestContext);
            var rDeleteOutput = repo.Read(contactWithJustId, requestContext);

            //Then
            Assert.Equal(contacts, rCreate);
            Assert.Equal(contacts, rGet);
            Assert.Equal(rUpdate.Info.City, aboutMeUpdateExpected);
            Assert.True(rUpdate.Info.City.Equals(rUpdateOutput.First().Info.City), "The property was updated succesfully");
            Assert.Empty(rDeleteOutput);

        }

    }
}
