using AddressBook.Services;



namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///<summary>
            /// Loading MainMenu
            ///</summary>
            var menuService = new MenuService();

            menuService.ShowMainMenu();

        }
    }
}
