using AddressBook.Shared.Interfaces;



namespace AddressBook.Shared.Models
{
    public class Contacts : IContacts
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        /// <summary>
        /// En tom konstruktor som jag behövde för att kunna använda den i min WPF-app. (Går kanske att göra på ett snyggare sätt, men det här får funka så länge.)
        /// </summary>
        public Contacts() 
        {
        }

        public Contacts(string firstname, string lastname, string email, string phonenumber, string address, string city, string postalcode)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            Address = address;
            City = city;
            PostalCode = postalcode;
        }

    }
}
