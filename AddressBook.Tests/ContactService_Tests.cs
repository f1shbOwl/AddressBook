using AddressBook.Interfaces;
using AddressBook.Models;
using AddressBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Tests
{
    public class ContactService_Tests
    {

        [Fact]
        public void AddContactToListShould_AddOneContactToContactList_ThenReturnTrue()
        {
            // Arrange
            IContactService contactService = new ContactService();
            Contacts contact = new Contacts("FirstName", "LastName", "Email", "Phonenumber", "Address", "City", "PostalCode");

            // Act
            contactService.AddContactToList(contact);

            // Assert
            var result = contactService.GetContactFromList();
            Assert.NotNull(result);
        }

    }

}
