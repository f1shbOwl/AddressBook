namespace AddressBook.Shared.Interfaces
{
    /// <summary>
    /// Interface for contacts that is not really utilized right now.
    /// </summary>
    public interface IContacts
    {
        string Address { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string PostalCode { get; set; }
    }
}
