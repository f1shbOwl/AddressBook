using AddressBook.Shared.Models;
using AddressBook.Shared.Services;


namespace AddressBook.Services
{
    internal class MenuService
    {
        

        private readonly ContactService _ContactService = new ContactService();


        /// <summary>
        /// MAIN MENU - Add new contact - Show all contacts - Exit program
        /// </summary>
        public void ShowMainMenu()
        {
            while (true)
                
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("_________________________");
                Console.WriteLine();
                Console.WriteLine("     Address Book    ");
                Console.WriteLine("_________________________");
                Console.WriteLine();
                Console.WriteLine("     ###  MENU  ###");
                Console.WriteLine();
                Console.WriteLine("  1. Add new contact");
                Console.WriteLine("  2. Show all contacts");
                Console.WriteLine("  3. Exit");
                Console.WriteLine("_________________________");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowAddMenu();
                        break;

                    case "2":
                        ShowAllMenu();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine(" Invalid option, please try again");
                        Console.ReadLine();
                        break;

                }
            }
        }


        /// <summary>
        /// MENU FOR ADDING NEW CONTACTS
        /// </summary>
        private void ShowAddMenu()
        {
            var contacts = new Contacts("FirstName", "LastName", "Email", "PhoneNumber", "Address", "City", "PostalCode");

            Console.Clear();
            Console.Write(" First name: ");
            contacts.FirstName = Console.ReadLine()!;

            Console.Write(" Last name: ");
            contacts.LastName = Console.ReadLine()!;

            Console.Write(" Email: ");
            contacts.Email = Console.ReadLine()!;

            Console.Write(" Phone number: ");
            contacts.PhoneNumber = Console.ReadLine()!;

            Console.Write(" Address: ");
            contacts.Address = Console.ReadLine()!;

            Console.Write(" Postal code: ");
            contacts.PostalCode = Console.ReadLine()!;

            Console.Write(" City: ");
            contacts.City = Console.ReadLine()!;


            _ContactService.AddContactToList(contacts);

            Console.Clear();
        }


        /// <summary>
        ///  MENU SHOWING ALL CONTACTS by firstname and lastname. Numered. User can pick a contact to view a detail menu by picking the contacts corresponding number.
        /// Do I want contacts.email here? it looks cleaner with only names and i want a better way then "-20" because they are not aligned.
        /// But it is better if two people have the same name, email is unique.
        /// </summary>
        private void ShowAllMenu()
        {
            var Contacts = _ContactService.GetContactFromList();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("  Press the corresponding contact number to see details");
            Console.WriteLine("  Press any key to back to main menu");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine();

            int contactNumber = 1;

            foreach (var contacts in Contacts)
            {
                
                Console.WriteLine($"    {contactNumber}. {contacts.FirstName} {contacts.LastName, -20} [{contacts.Email}]");
                contactNumber++;
                
            }

            string userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int selectedContactIndex) && selectedContactIndex > 0 && selectedContactIndex <= Contacts.Count)
            {
                ShowDetailMenu(Contacts[selectedContactIndex - 1]);
            }


        }


        /// <summary>
        /// DETAILED VIEW MENU - with options to change the selected contacts details, delete the selected contact or go back to main menu
        /// Changing contact details maybe should have been a loop because now after two faulty tries to delete contact it just goes back to main menu.
        /// Maybe also should have been its own menu as now there is no option so change a specific detail, user have to change or atleast rewrite everything. 
        /// </summary>
        private void ShowDetailMenu(Contacts selectedContact)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine();
                Console.WriteLine(" Contact Details");
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine();
                Console.WriteLine($" Name:       {selectedContact.FirstName} {selectedContact.LastName}");
                Console.WriteLine($" Email:      {selectedContact.Email}");
                Console.WriteLine($" Phone:      {selectedContact.PhoneNumber}");
                Console.WriteLine($" Address:    {selectedContact.Address}, {selectedContact.PostalCode} {selectedContact.City}");
                Console.WriteLine();
                Console.WriteLine("  1. Change contact details");
                Console.WriteLine("  2. Delete Contact");
                Console.WriteLine("  3. Go Back to Main Menu");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine();
                        Console.Write("First name: ");
                        string newFirstName = Console.ReadLine()!;

                        Console.Write("Last name: ");
                        string newLastName = Console.ReadLine()!;

                        Console.Write("Email: ");
                        string newEmail = Console.ReadLine()!;

                        Console.Write("Phone number ");
                        string newPhoneNumber = Console.ReadLine()!;

                        Console.Write("Address: ");
                        string newAddress = Console.ReadLine()!;

                        Console.Write("Postal code: ");
                        string newPostalCode = Console.ReadLine()!;

                        Console.Write("City: ");
                        string newCity = Console.ReadLine()!;
                        Console.WriteLine();

                        _ContactService.UpdateContactDetails(selectedContact, newFirstName, newLastName, newEmail, newPhoneNumber, newAddress, newPostalCode, newCity);
                        Console.Clear();
                        Console.WriteLine(" Details changed, press any key to return to main menu");
                        Console.ReadLine();
                        return;

                    case "2":
                        Console.WriteLine();
                        _ContactService.RemoveContact(selectedContact);
                        return;

                    case "3":
                        return;

                    default:
                        Console.WriteLine(" Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
