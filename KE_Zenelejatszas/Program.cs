namespace KE_Zenelejatszas
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while (true) {
                Console.WriteLine("Keresés cím szerint");
                Console.WriteLine("Zene törlése");
                Console.WriteLine("Zene módosítása");
                Console.WriteLine("Új zene");
                Console.WriteLine("3,5 percnél hosszabbak");
                Console.WriteLine("Csak Pop zenék");
                Console.WriteLine("Zenék betöltése");
                string valasztas = Console.ReadLine();
                switch (valasztas)
                {
                    case "0": return;
                    case "1": break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "6": break;
                    case "7": break;
                }

                }
        }
}
