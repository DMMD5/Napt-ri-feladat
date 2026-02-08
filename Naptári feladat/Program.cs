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
                Console.WriteLine("\nnaptár");
                Console.WriteLine("1 - Megjelenítése");
                Console.WriteLine("2 - Új esemény");
                Console.WriteLine("3 - Legközelebbi esemény");
                Console.WriteLine("4 - Kilépés");
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
    }
}
