using AddressBook.Shared.Models;

namespace AddressBook.Shared.Interfaces
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

        void RemoveContactInWpf(string confirmationEmail);
    }
}
