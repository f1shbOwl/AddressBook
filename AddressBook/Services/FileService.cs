using AddressBook.Interfaces;
using System.Diagnostics;

namespace AddressBook.Services
{
    internal class FileService(string filePath) : IFileService
    {
        private readonly string _filePath = filePath;

        public bool SaveContactToFile(string SavedContact)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(SavedContact);
                }
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;

        }

        public string GetContactFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath);
                    return sr.ReadToEnd();
                }
                 
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
            
        }


    }
}
