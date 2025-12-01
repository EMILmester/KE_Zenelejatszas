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
                Console.WriteLine("1. Keresés cím szerint");
                Console.WriteLine("2. Zene törlése");
                Console.WriteLine("3. Zene módosítása");
                Console.WriteLine("4. Új zene");
                Console.WriteLine("3,5 percnél hosszabbak");
                Console.WriteLine("Csak Pop zenék");
                Console.WriteLine("7. Zenék betöltése");
                string valasztas = Console.ReadLine();
                switch (valasztas)
                {
                    case "0": return;
                    case "1": string keresett = Console.ReadLine();
                        var talalatok = zenek
                            .Where(z => z.Cim.Contains(keresett, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                        if (talalatok.Count == 0)
                        {
                            Console.WriteLine("Nincs találat!");
                        }
                        else
                        {
                            foreach (var zene in talalatok)
                            {
                                Console.WriteLine(zene);
                            }
                        }

                        break;
                    case "2":
                        string keresettCim = Console.ReadLine();

                        // Keresés listaelemre
                        Zene torlendo = zenek
                            .FirstOrDefault(z => z.Cim.Equals(keresettCim, StringComparison.OrdinalIgnoreCase));

                        if (torlendo == null)
                        {
                            Console.WriteLine("Nincs ilyen című zene!");
                        }
                        else
                        {
                            // Eltávolítás a listából
                            zenek.Remove(torlendo);
                            Console.WriteLine("A zene törölve!");

                            // Visszaírás a fájlba
                            File.WriteAllLines("zene.txt",
                                zenek.Select(z => $"{z.Cim},{z.Eloado},{z.Mufaj},{z.HosszMp}"));
                        }
                        break;
                    case "3":
                        string modositando = Console.ReadLine();

                        // Keresés pontos címre
                        Zene modZene = zenek
                            .FirstOrDefault(z => z.Cim.Equals(modositando, StringComparison.OrdinalIgnoreCase));

                        if (modZene == null)
                        {
                            Console.WriteLine("Nincs ilyen című zene!");
                        }
                        else
                        {
                            Console.WriteLine("Add meg az új adatokat (ha nem akarsz módosítani, Enter-rel továbbléphetsz):");

                            Console.Write($"Új cím (régi: {modZene.Cim}): ");
                            string ujCim = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(ujCim))
                                modZene.Cim = ujCim;

                            Console.Write($"Új előadó (régi: {modZene.Eloado}): ");
                            string ujEloado = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(ujEloado))
                                modZene.Eloado = ujEloado;

                            Console.Write($"Új műfaj (régi: {modZene.Mufaj}): ");
                            string ujMufaj = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(ujMufaj))
                                modZene.Mufaj = ujMufaj;

                            Console.Write($"Új hossz mp-ben (régi: {modZene.HosszMp}): ");
                            string ujHosszTxt = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(ujHosszTxt))
                                modZene.HosszMp = int.Parse(ujHosszTxt);

                            // visszaírás a fájlba (fejléc megtartásával)
                            File.WriteAllLines("zene.txt",
                                new string[] { "Cim,Eloado,Mufaj,HosszMp" }
                                .Concat(zenek.Select(z => $"{z.Cim},{z.Eloado},{z.Mufaj},{z.HosszMp}"))
                            );

                            Console.WriteLine("A zene adatai sikeresen módosítva!");
                        }
                        break;
                    case "4":
                        Console.Write("Cím: ");
                        string ujCim = Console.ReadLine();

                        Console.Write("Előadó: ");
                        string ujEloado = Console.ReadLine();

                        Console.Write("Műfaj: ");
                        string ujMufaj = Console.ReadLine();

                        Console.Write("Hossz mp-ben: ");
                        int ujHossz = int.Parse(Console.ReadLine());

                        // Objektum létrehozása
                        Zene ujZene = new Zene(ujCim, ujEloado, ujMufaj, ujHossz);

                        // Hozzáadás a listához
                        zenek.Add(ujZene);

                        // Visszaírás a fájlba fejléc megtartásával
                        File.WriteAllLines("zene.txt",
                            new string[] { "Cim,Eloado,Mufaj,HosszMp" }
                            .Concat(zenek.Select(z => $"{z.Cim},{z.Eloado},{z.Mufaj},{z.HosszMp}"))
                        );

                        Console.WriteLine("Az új zene sikeresen hozzáadva!"); break;
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
