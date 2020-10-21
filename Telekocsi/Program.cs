using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    class Program
    {
        static List<Auto> autok = new List<Auto>();
        static List<Igeny> igenyek = new List<Igeny>();

        


        static void BeolvasAutok()
        {
            StreamReader file = new StreamReader("autok.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                autok.Add(new Auto(file.ReadLine()));
            }
            file.Close();
        }

        static void BeolvasIgenyek()
        {
            StreamReader file = new StreamReader("igenyek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                igenyek.Add(new Igeny(file.ReadLine()));
            }
            file.Close();
        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine($"   {autok.Count} autos hirdet fuvart.");
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat");
            int ferohely = 0;
            for (int i = 0; i < autok.Count; i++)
            {
                if (autok[i].Indulas == "Budapest" && autok[i].Cel == "Miskolc")
                {
                    ferohely += autok[i].Ferohely;
                }
            }
            Console.WriteLine($"   Összesen {ferohely} férőhelyet hirdettek az autósok Budapestről Miskolcra.");
        }

        static void Feladat4()
        {
            #region Dictionary, foreach
            //Dictionary<string, int> utvonalak = new Dictionary<string, int>();

            //foreach (var a in autok)
            //{
            //    if (!utvonalak.ContainsKey(a.Utvonal))
            //    {
            //        utvonalak.Add(a.Utvonal, a.Ferohely);
            //    }
            //    else
            //    {
            //        utvonalak[a.Utvonal] = utvonalak[a.Utvonal] + a.Ferohely;
            //    }
            //}

            int max = 0;
            string utv = "";
            //foreach (var u in utvonalak)
            //{
            //    if (u.Value > max)
            //    {
            //        max = u.Value;
            //        utv = u.Key;
            //    }
            //} 
            #endregion

            var utvonalak = from a in autok
                            orderby a.Utvonal
                            group a by a.Utvonal into temp
                            select temp;

            foreach (var ut in utvonalak)
            {
                int fh = ut.Sum(x => x.Ferohely);
                if (max < fh)
                {
                    max = fh;
                    utv = ut.Key;
                }
                //Console.WriteLine($"{ut.Key} - {ut.Count()}");
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine($"{max} - {utv}");
        }

        static void Feladat5()
        {
            Console.WriteLine("5. feladat");
            foreach (var igeny in igenyek)
            {
                int i = 0;
                while (i < autok.Count &&
                    !(igeny.Indulas == autok[i].Indulas &&
                    igeny.Cel == autok[i].Cel &&
                    igeny.Szemelyek <= autok[i].Ferohely))
                {
                    i++;
                }

                if (i < autok.Count)
                {
                    Console.WriteLine($"{igeny.Azonosito} => {autok[i].Rendszam}");
                }
            }
        }

        static void Feladat6()
        {
            StreamWriter file = new StreamWriter("utasuzenetek.txt");

            foreach (var igeny in igenyek)
            {
                int i = 0;
                while (i < autok.Count &&
                    !(igeny.Indulas == autok[i].Indulas &&
                    igeny.Cel == autok[i].Cel &&
                    igeny.Szemelyek <= autok[i].Ferohely))
                {
                    i++;
                }

                if (i < autok.Count)
                {
                    file.WriteLine($"{igeny.Azonosito}: Rendszám: {autok[i].Rendszam}, Telefonszám: {autok[i].Telefon}");
                }
                else
                {
                    file.WriteLine($"{igeny.Azonosito}: Sajnos nem sikerült autót találni");
                }
            }

            file.Close();
        }

        static void Main(string[] args)
        {
            BeolvasAutok();
            BeolvasIgenyek();

            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();

            Console.ReadKey();
        }
    }
}
