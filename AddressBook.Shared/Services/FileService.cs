using AddressBook.Shared.Interfaces;
using System.Diagnostics;



namespace AddressBook.Shared.Services
{
    /// <summary>
    /// Implementing interface IFileservice and handles saving the contact details to file.
    /// Tries to save a contact o json and if successful returns true. 
    /// </summary>
    /// 
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



        /// <summary>
        /// Using StreamReader to try and read the json file _filePath.
        /// </summary>
        /// <returns>
        /// If not successful it logs error message and returns null
        /// </returns>
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
