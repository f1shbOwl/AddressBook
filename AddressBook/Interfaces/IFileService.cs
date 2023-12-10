namespace AddressBook.Interfaces
{
    public interface IFileService
    {
        bool SaveContactToFile(string SavedContact);
        string GetContactFromFile();
    }
}