﻿using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;


namespace AddressBook.Tests
{
    public class ContactService_Tests
    {


        /// <summary>
        /// Testing the function AddContactToList by creating a contact using string values firstname, lastname etc.
        /// It then checks if contact was added and not null.
        /// </summary>
        [Fact]
        public void AddContactToListShould_AddOneContactToContactList_ThenReturnTrue()
        {
            // Arrange
            IContactService contactService = new ContactService();
            Contacts Contact = new Contacts("Adam", "Adamsson", "Adam@test.se", "0701231234", "Storgatan 1", "Bengtsfors", "60011");

            // Act
            contactService.AddContactToList(Contact);

            // Assert
            var result = contactService.GetContactFromList();
            Assert.NotNull(result);
        }

    }

}
