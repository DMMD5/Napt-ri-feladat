using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

struct Esemeny
{
    public string Tulajdonos;
    public DateTime Idopont;
    public int Idotartam;
    public bool IsNew;
}

namespace Naptári_feladat
{
    internal class Program
    {
        static List<Esemeny> esemenyek = new List<Esemeny>();
        static Random rnd = new Random();

        const int EV = 2028;
        const int HONAP = 2;

        static void Main()
        {
            Esemenyek();

            while (true)
            {
                Console.WriteLine("\n--- Családi naptár ---");
                Console.WriteLine("1 - Naptár megjelenítése");
                Console.WriteLine("2 - Új esemény rögzítése");
                Console.WriteLine("3 - Legközelebbi esemény megjelenítése");
                Console.WriteLine("4 - Kilépés");
                Console.Write("Választás: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        Megjelenites();
                        break;
                    case "2":
                        UjEsemeny();
                        break;
                    case "3":
                        LegkozelebbiEsemeny();
                        break;
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
            foreach (string tulajdonos in new[] { "apa", "anya" })
            {
                for (int i = 0; i < 10; i++)
                {
                    int nap = rnd.Next(1, 29);
                    int ora = rnd.Next(8, 20);
                    int perc = rnd.Next(0, 2) * 30;

                    DateTime idopont = new DateTime(EV, HONAP, nap, ora, perc, 0);
                    int idotartam = rnd.Next(1, 5) * 30;

                    esemenyek.Add(new Esemeny
                    {
                        Tulajdonos = tulajdonos,
                        Idopont = idopont,
                        Idotartam = idotartam,
                        IsNew = false
                    });
                }
            }
        }

        static void Megjelenites()
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
                        Esemeny temp = esemenyek[i];
                        esemenyek[i] = esemenyek[j];
                        esemenyek[j] = temp;
                    }
                }
            }

            Console.WriteLine("\n--- Események listája ---");
            foreach (Esemeny e in esemenyek)
            {
                if (e.IsNew)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine($"{e.Tulajdonos.PadRight(5)} | {e.Idopont:yyyy-MM-dd HH:mm} | {e.Idotartam} perc");
            }
            Console.ResetColor();
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

            Console.Write("Dátum (YYYY-MM-DD): ");
            string datum = Console.ReadLine();

            Console.Write("Idő (HH:MM): ");
            string ido = Console.ReadLine();

            DateTime kezdes;
            if (!DateTime.TryParse(datum + " " + ido, out kezdes))
            {
                Console.WriteLine("Hibás dátum vagy idő!");
                return;
            }

            Console.Write("Időtartam (perc): ");
            int idotartam;
            if (!int.TryParse(Console.ReadLine(), out idotartam))
            {
                Console.WriteLine("Hibás időtartam!");
                return;
            }

            DateTime vege = kezdes.AddMinutes(idotartam);

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

            esemenyek.Add(new Esemeny
            {
                Tulajdonos = tulajdonos,
                Idopont = kezdes,
                Idotartam = idotartam,
                IsNew = true
            });

            Console.WriteLine("Esemény rögzítve (zölddel fog megjelenni a listában).");
        }

        static void LegkozelebbiEsemeny()
        {
            if (esemenyek.Count == 0) return;

            DateTime alapIdo = new DateTime(
                EV,
                HONAP,
                rnd.Next(1, 28),
                rnd.Next(8, 20),
                rnd.Next(0, 2) * 30,
                0
            );

            Console.WriteLine($"\nViszonyítási idő: {alapIdo:yyyy-MM-dd HH:mm}");

            Esemeny legkozelebbi = esemenyek[0];
            double minKul = Math.Abs((esemenyek[0].Idopont - alapIdo).TotalMinutes);

            foreach (Esemeny e in esemenyek)
            {
                double kul = Math.Abs((e.Idopont - alapIdo).TotalMinutes);
                if (kul < minKul)
                {
                    minKul = kul;
                    legkozelebbi = e;
                }
            }

            Console.WriteLine("Legközelebbi esemény:");
            Console.WriteLine($"{legkozelebbi.Tulajdonos} | {legkozelebbi.Idopont:yyyy-MM-dd HH:mm} | {legkozelebbi.Idotartam} perc");
        }
    }
}
