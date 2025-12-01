namespace KE_Zenelejatszas
{
    class Zene
    {
        public string Cim;
        public string Eloado;
        public string Mufaj;
        public int HosszMp;

        public Zene(string cim, string eloado, string mufaj, int hosszMp)
        {
            Cim = cim;
            Eloado = eloado;
            Mufaj = mufaj;
            HosszMp = hosszMp;
        }

        public override string ToString()
        {
            return $"{Cim} - {Eloado} ({Mufaj}, {HosszMp} mp)";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fajlnev = "C:\\Users\\KoleszarE\\Desktop\\Zenék\\zene.txt";

            List<Zene> zenek = new List<Zene>();

            string[] sorok = File.ReadAllLines(fajlnev);

            // az első sor a fejléc → átugorjuk
            for (int i = 1; i < sorok.Length; i++)
            {
                string sor = sorok[i];
                string[] adat = sor.Split(',');

                string cim = adat[0];
                string eloado = adat[1];
                string mufaj = adat[2];
                int hossz = int.Parse(adat[3]);

                zenek.Add(new Zene(cim, eloado, mufaj, hossz));
            }
            while (true)
            {
                Console.WriteLine("0. Kilépés");
                Console.WriteLine("Keresés cím szerint");
                Console.WriteLine("Zene törlése");
                Console.WriteLine("Zene módosítása");
                Console.WriteLine("Új zene");
                Console.WriteLine("3,5 percnél hosszabbak");
                Console.WriteLine("Csak Pop zenék");
                Console.WriteLine("7. Zenék betöltése");
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
                    case "7":
                        Console.Clear();
                        int sorszam = 0;
                        foreach (var zene in zenek)
                        {
                            sorszam++;
                            Console.WriteLine($"{sorszam}. {zene}");
                        }
                        break;


                }
                Console.ReadKey();

            }
        }
    }
}
