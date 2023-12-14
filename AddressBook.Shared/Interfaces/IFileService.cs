namespace AddressBook.Shared.Interfaces
{
    /// <summary>
    /// Interface for FileService
    /// </summary>
    public interface IFileService
    {
        bool SaveContactToFile(string SavedContact);
        string GetContactFromFile();
    }
}
