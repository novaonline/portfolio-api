using System.Linq;
using PortfolioApi.Core.Domains.Contacts.Repository;
using PortfolioApi.Models.Contacts;
using Xunit;

namespace PortfolioApi.Tests.Integration.Contacts
{
    public class ContactsCrudIntegrationTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public ContactsCrudIntegrationTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
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
            var rCreate = repo.Create(contacts);
            var rGetList = repo.Read(contactWithJustId);
            var rGet = rGetList.First();
            var aboutMeUpdateExpected = "Brandon";
            rGet.Info.City = aboutMeUpdateExpected;
            var rUpdate = repo.Update(contactWithJustId, rGet.Info);
            var rUpdateOutput = repo.Read(contactWithJustId);
            var rDelete = repo.Delete(contactWithJustId);
            var rDeleteOutput = repo.Read(contactWithJustId);

            //Then
            Assert.Equal(contacts, rCreate);
            Assert.Equal(contacts, rGet);
            Assert.Equal(rUpdate.Info.City, aboutMeUpdateExpected);
            Assert.True(rUpdate.Info.City.Equals(rUpdateOutput.First().Info.City), "The property was updated succesfully");
            Assert.Empty(rDeleteOutput);

        }

    }
}
