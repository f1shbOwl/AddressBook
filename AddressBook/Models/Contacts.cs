using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Interfaces;

namespace AddressBook.Models
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
