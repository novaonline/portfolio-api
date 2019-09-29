using System;
using PortfolioApi.Models.Contacts;
using Xunit;

namespace PortfolioApi.Tests.Unit.Contacts
{
    public class ContactsValidationUnitTests
    {
        [Fact]
        public void Contacts_HappyPathInput_SuccessfulValidation()
        {
            //Given
            var c = new Contact 
            {
                ProfileId = 1,
                Id = 1,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow

            };
            //When

            //Then
        }
    }
}
