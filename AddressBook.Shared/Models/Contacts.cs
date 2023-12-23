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
