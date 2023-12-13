using AddressBook.Interfaces;
using AddressBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class ContactService : IContactService
    {
        private List<Contacts> _contacts = new List<Contacts>();


        /// <summary>
        /// Creates a file path and saves contacts to json file.
        /// </summary>
        private readonly FileService _fileService = new FileService(Path.Combine(Environment.CurrentDirectory,@"..\..\..\SavedFiles\SavedContacts.json"));
        



        /// <summary>
        /// Adds contact to the list (if email is unique) and saves it to the file. If email is not unique user will be prompted a message saying contact already exist.
        /// </summary>
        public void AddContactToList(Contacts contacts)
        {
            try
            {
                if (!_contacts.Any(x => x.Email == contacts.Email))
                {
                    _contacts.Add(contacts);
                    _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));

                    Console.Clear();
                    Console.WriteLine("Contact added");
                    Console.ReadLine();

                }
                else
                {
                    throw new Exception("It looks like this contact has already been added");
                }
            }
            catch (Exception ex)
            { Debug.WriteLine(ex.Message); }

        }

        /// <summary>
        /// Removes contact from the list, if email is correct, and removes it from the file.
        /// </summary>
        public void RemoveContact(Contacts contact)
        {
            Console.WriteLine($"Confirm you want to delete {contact.FirstName} {contact.LastName} by entering the email address:");
            string confirmationEmail = Console.ReadLine()!;

            try
            {
                if (string.Equals(confirmationEmail, contact.Email, StringComparison.OrdinalIgnoreCase))
                {
                    _contacts.Remove(contact);
                    _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
                    Console.WriteLine();
                    Console.WriteLine("Contact deleted successfully.");
                    Console.ReadLine();

                }
                else
                {
                    throw new Exception("Confirmation email does not match. Contact was not deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine();
                Console.WriteLine("Try again by entering the email address");
                Console.ReadLine();
            }
        }


        /// <summary>
        /// Updates the details of the specific contact. Such as first name, last name etc and also saves the new details to the file.
        /// </summary>
        public void UpdateContactDetails(Contacts existingContact, string newFirstName, string newLastName, string newEmail, string newPhoneNumber, string newAddress, string newPostalCode, string newCity)
        {
            existingContact.FirstName = newFirstName;
            existingContact.LastName = newLastName;
            existingContact.Email = newEmail;
            existingContact.PhoneNumber = newPhoneNumber;
            existingContact.Address = newAddress;
            existingContact.PostalCode = newPostalCode;
            existingContact.City = newCity;

            _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
        }

        /// <summary>
        /// GET LIST FROM FILE
        /// </summary>
        public List<Contacts> GetContactFromList()
        {

            try
            {
                var contacts = _fileService.GetContactFromFile();
                if (!string.IsNullOrEmpty(contacts))
                {
                    _contacts = JsonConvert.DeserializeObject<List<Contacts>>(contacts)!;
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return _contacts;
        }
    }
}
