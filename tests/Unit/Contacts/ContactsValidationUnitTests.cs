using System;
using PortfolioApi.Core.Domains.Contacts.Validation;
using PortfolioApi.Models.Contacts;
using PortfolioApi.Models.Interfaces.Validators;
using Xunit;

namespace PortfolioApi.Tests.Unit.Contacts
{
    public class ContactsValidationUnitTests : IDisposable
    {
        IValidatorCreate<Contact> createValidator;
        IValidatorUpdate<Contact, ContactInfo> updateValidator;
        IValidatorDelete<Contact> deleteValidator;

        public ContactsValidationUnitTests()
        {
            createValidator = new ContactsCreateFluentValidator();
            updateValidator = new ContactsUpdateFluentValidator();
            deleteValidator = new ContactsDeleteSimpleValidator();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void Contacts_Create_EmptyInput_UnSuccessfulValidation()
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
            var result = createValidator.Validate(c);

            //Then
            Assert.False(result.IsValid, "Empty Info should be invalid");
        }

        [Fact]
        public void Contacts_Update_WrongInput_UnSuccesfulValidation()
        {
            //Given
            var cBadEmail = new Contact
            {
                Id = 1,
                ProfileId = 1,
                Info = new ContactInfo
                {
                    Email = "abc@",
                }
            };

            var cMissingReference = new Contact
            {
                Id = 0,
                ProfileId = 1,
                Info = new ContactInfo
                {
                    Email = "abc@hotmail.com",
                }
            };

            //When
            var resultForBadEmail = updateValidator.Validate(cBadEmail, cBadEmail.Info);
            var resultForMissingReference = updateValidator.Validate(cMissingReference, cMissingReference.Info);

            //Then
            Assert.False(resultForBadEmail.IsValid, "Email is not valid and should return unsuccessful");
            Assert.False(resultForMissingReference.IsValid, "Reference to item is missing and should return unsuccessful");
        }

        [Fact]
        public void Contacts_Delete_WrongInput_UnSuccesfulValidation()
        {
            //Given
            var c = new Contact
            {
                ProfileId = 1,
                Id = 0,
                AddDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            //When
            var result = deleteValidator.Validate(c);

            //Then
            Assert.False(result.IsValid, "Wrong input during delete");
        }

        [Fact]
        public void Contacts_CUD_CorrectInput_SuccesfulValidation()
        {
            //Given
            var c = new Contact
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

            //When
            var resultCreate = createValidator.Validate(c);
            var resultUpdate = updateValidator.Validate(c, c.Info);
            var resultDelete = deleteValidator.Validate(c);

            //Then
            Assert.True(resultCreate.IsValid);
            Assert.True(resultUpdate.IsValid);
            Assert.True(resultDelete.IsValid);

        }
    }
}
