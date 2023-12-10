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
    internal class ContactService
    {
        private List<Contacts> _contacts = new List<Contacts>();

        private readonly FileService _fileService = new FileService(@"F:\Education\ec-projects\SavedToFile\SavedContacts.json");



        //Add contact
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

        //Remove contact
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
    

        //Update contact details
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

        //List contacts
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
