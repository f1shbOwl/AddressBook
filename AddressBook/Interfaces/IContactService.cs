﻿using AddressBook.Models;

namespace AddressBook.Interfaces
{

    /// <summary>
    /// Interface for ContactService
    /// </summary>
    public interface IContactService
    {
        void AddContactToList(Contacts contacts);
        List<Contacts> GetContactFromList();
        void RemoveContact(Contacts contact);
        void UpdateContactDetails(Contacts existingContact, string newFirstName, string newLastName, string newEmail, string newPhoneNumber, string newAddress, string newPostalCode, string newCity);
    }
}