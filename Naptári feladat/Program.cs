using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
struct Esemeny
{
    public string Tulajdonos;
    public DateTime Idopont;
    public int Idotartam;
}

namespace Naptári_feladat
{
    internal class Program
    {
        static List<Esemeny> esemenyek = new List<Esemeny>();
        static Random rnd = new Random();
        const int EV = 2028;
        const int HONAP = 2;
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n naptár");
                Console.WriteLine("1-Megjelenítése");
                Console.WriteLine("2-Új esemény");
                Console.WriteLine("3-Legközelebbi esemény");
                Console.WriteLine("4-Kilépés");
                Console.Write("Választás: ");

                string menu = Console.ReadLine();


                switch (menu)
                {
                    case "1":
                        return;
                    case "2":
                        return;
                    case "3":
                        return;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás!");
                        break;
                }

            }

        }
        static void Esemenyek()
        {


            foreach  (string tulajdonos in new[] { "apa", "anya" })
            {

                for (int i = 0; i < 10; i++)
                {
                    int nap = rnd.Next(1, 30);
                    int ora = rnd.Next(8, 20);

                    DateTime idopont = new DateTime(EV, HONAP, nap, ora, perc, 0);
                    int idotartam = rnd.Next(1, 5) * 30;

                }
            }
        }

        static void Kiiras()
        {
            if (esemenyek.Count == 0)
            {
                Console.WriteLine("Nincs esemény.");
                return;
            }
            for (int i = 0; i < esemenyek.Count - 1; i++)
            {
                for (int j = i + 1; j < esemenyek.Count; j++)
                {
                    if (esemenyek[i].Idopont > esemenyek[j].Idopont)
                    {
                    }
                }
            }
          
        }

        static void UjEsemeny()
        {
            Console.Write("Tulajdonos (apa/anya): ");
            string tulajdonos = Console.ReadLine().ToLower();

            if (tulajdonos != "apa" && tulajdonos != "anya")
            {
                Console.WriteLine("Hibás tulajdonos!");
                return;
            }

            DateTime kezdes;
            if (!DateTime.TryParse(datum + " " + ido, out kezdes))
            {
            }

            DateTime vege = kezdes.AddMinutes();

            foreach (Esemeny e in esemenyek)
            {
                if (e.Tulajdonos == tulajdonos)
                {
                    DateTime regiVege = e.Idopont.AddMinutes(e.Idotartam);

                    if (kezdes < regiVege && vege > e.Idopont)
                    {
                        Console.WriteLine("Nem vehető fel, mert ebben az időben már van esemény!");
                        return;
                    }
                }
            }
        }
    }
}
