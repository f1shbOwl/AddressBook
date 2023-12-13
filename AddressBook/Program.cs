using AddressBook.Services;


namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///<summary>
            /// Intro - Do i really want this here? hmmm....
            /// Tried to make it look better and with less code using printDelay but it wouldnt work the way i wanted.
            ///</summary>
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                             T");
            Thread.Sleep(100);
            Console.Write("H");
            Thread.Sleep(100);
            Console.Write("E");
            Thread.Sleep(100);
            Console.Write(" E");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("C");
            Thread.Sleep(100);
            Console.Write("H");
            Thread.Sleep(100);
            Console.Write("A");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("T");
            Thread.Sleep(100);
            Console.Write("E");
            Thread.Sleep(100);
            Console.Write("D");
            Thread.Sleep(100);
            Console.Write(" C");
            Thread.Sleep(100);
            Console.Write("O");
            Thread.Sleep(100);
            Console.Write("M");
            Thread.Sleep(100);
            Console.Write("P");
            Thread.Sleep(100);
            Console.Write("E");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("D");
            Thread.Sleep(100);
            Console.Write("I");
            Thread.Sleep(100);
            Console.Write("U");
            Thread.Sleep(100);
            Console.Write("M");
            Console.WriteLine();
            Console.Write("                                        O");
            Console.Write("F");
            Console.WriteLine();
            Console.Write("                                E");
            Thread.Sleep(100);
            Console.Write("L");
            Thread.Sleep(100);
            Console.Write("U");
            Thread.Sleep(100);
            Console.Write("S");
            Thread.Sleep(100);
            Console.Write("I");
            Thread.Sleep(100);
            Console.Write("V");
            Thread.Sleep(100);
            Console.Write("E");
            Thread.Sleep(100);
            Console.Write(" C");
            Thread.Sleep(100);
            Console.Write("O");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("E");
            Thread.Sleep(100);
            Console.Write("C");
            Thread.Sleep(100);
            Console.Write("T");
            Thread.Sleep(100);
            Console.Write("I");
            Thread.Sleep(100);
            Console.Write("O");
            Thread.Sleep(100);
            Console.Write("N");
            Thread.Sleep(100);
            Console.Write("S");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                                    B");
            Thread.Sleep(200);
            Console.Write("Y");
            Thread.Sleep(200);
            Console.Write(" B");
            Thread.Sleep(200);
            Console.Write("J");
            Thread.Sleep(200);
            Console.Write("Ö");
            Thread.Sleep(200);
            Console.Write("R");
            Thread.Sleep(200);
            Console.Write("N");
            Thread.Sleep(3000);



            ///<summary>
            /// Loading MainMenu
            ///</summary>
            var menuService = new MenuService();

            menuService.ShowMainMenu();

        }
    }
}
