using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        public static Random rnd = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            DrzewoPolskie p = new DrzewoPolskie();
            DrzewoAngielskie a = new DrzewoAngielskie();
            IOManager ioManager = new IOManager();
            ioManager.WczytajSlowa(a, p);
            string input;
            Stopwatch watch;
            bool exit = false;
            while (true)
            {
                Console.WriteLine("1. Wstaw -> Slowo_polskie");
                Console.WriteLine("2. Wstaw -> Slowo_angielskie");
                Console.WriteLine("3. Wyszukaj -> Slowo_polskie");
                Console.WriteLine("4. Wyszukaj -> Slowo_angielskie");
                Console.WriteLine("5. Usun -> Slowo_polskie");
                Console.WriteLine("6. Usun -> Slowo_angielskie");
                Console.WriteLine("7. Wypisz slownik w porządku KLP");
                Console.WriteLine("8. Dodaj 5 losowych słów do słownika");
                Console.WriteLine("0. Wyjdz i zapisz zmiany");
                input = Console.ReadLine();
                int d;
                if (!Int32.TryParse(input, out d))
                {
                    Console.WriteLine("Wybierz liczbe z przedzialu 0-6");
                    Console.ReadKey();
                }
                switch (d)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("Podaj slowo polskie");
                        string temp1 = Console.ReadLine();
                        Console.WriteLine("Podaj tlumaczenie");
                        string temp2 = Console.ReadLine();
                        Wezel temp1synonim = p.Wyszukaj(p.korzen, temp1);
                        Wezel temp2synonim = a.Wyszukaj(a.korzen, temp2);
                        if(temp1synonim == null && temp2synonim==null)
                        {
                            p.CzyWywazone = false;
                            Wezel temp = p.korzen;
                            bool rotacja = false;
                            watch = Stopwatch.StartNew();
                            try
                            {
                                p.WstawSlowo(ref temp, temp1, ref rotacja);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            p.korzen = temp;
                            watch.Stop();
                            Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            var pol = p.Wyszukaj(p.korzen, temp1);
                            Wezel temp2ang = a.korzen;
                            bool rotacja2 = false;
                            watch = Stopwatch.StartNew();
                            try
                            {
                                a.WstawSlowo(ref temp2ang, temp2, ref rotacja2);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            watch.Stop();
                            Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            a.korzen = temp2ang;
                            var ang = a.Wyszukaj(a.korzen, temp2);
                            ang.Tlumaczenie = pol;
                            pol.Tlumaczenie = ang;

                        }
                        else
                        {
                            if (temp1synonim == null)
                            {
                                Console.WriteLine("Słowo angielskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", temp2synonim.Slowo);
                                continue;
                            }
                            if (temp2synonim == null)
                            {
                                Console.WriteLine("Słowo polskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", temp1synonim.Slowo);
                                continue;
                            }
                            if (temp1synonim != null && temp2synonim != null)
                            {
                                Console.WriteLine("Słowo angielskie {0} i słowo polskie {1} znajdują sie juz w zbiorze, nie zostaną dodane", temp2synonim.Slowo, temp1synonim.Slowo);
                                continue;
                            }
                            throw new Exception("Fatal error");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Podaj slowo angielskie");
                        string temp3 = Console.ReadLine();
                        Console.WriteLine("Podaj tlumaczenie");
                        string temp4 = Console.ReadLine();
                        Wezel temp4synonim = p.Wyszukaj(p.korzen, temp4);
                        Wezel temp3synonim = a.Wyszukaj(a.korzen, temp3);
                        if (temp3synonim == null && temp4synonim == null)
                        {
                            a.CzyWywazone = false;
                            Wezel temp3ang = a.korzen;
                            bool rotacja3 = false;
                            watch = Stopwatch.StartNew();
                            try
                            {
                                a.WstawSlowo(ref temp3ang, temp3, ref rotacja3);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            a.korzen = temp3ang;
                            watch.Stop();
                            Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            var ang1 = a.Wyszukaj(a.korzen, temp3);
                            Wezel temp4pol = p.korzen;
                            bool rotacja4 = false;
                            watch = Stopwatch.StartNew();
                            try
                            {
                                p.WstawSlowo(ref temp4pol, temp4, ref rotacja4);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            watch.Stop();
                            Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            p.korzen = temp4pol;
                            var pol1 = p.Wyszukaj(p.korzen, temp4);
                            ang1.Tlumaczenie = pol1;
                            pol1.Tlumaczenie = ang1;

                        }
                        else
                        {
                            if (temp4synonim == null)
                            {
                                Console.WriteLine("Słowo angielskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", temp3synonim.Slowo);
                                continue;
                            }
                            if (temp3synonim == null)
                            {
                                Console.WriteLine("Słowo polskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", temp4synonim.Slowo);
                                continue;
                            }
                            if (temp3synonim != null && temp4synonim != null)
                            {
                                Console.WriteLine("Słowo angielskie {0} i słowo polskie {1} znajdują sie juz w zbiorze, nie zostaną dodane", temp3synonim.Slowo, temp4synonim.Slowo);
                                continue;
                            }
                            throw new Exception("Fatal error");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Podaj slowo angielskie");
                        input = Console.ReadLine();
                        watch = Stopwatch.StartNew();
                        var ang2 = a.Wyszukaj(a.korzen, input);
                        watch.Stop();
                        if (ang2 == null)
                        {
                            Console.WriteLine("Podane slowo angielskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wyszukano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            if (ang2.Tlumaczenie == null)
                            {
                                Console.WriteLine("Podane slowo nie ma tlumaczenia");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Tłumaczeniem: " + ang2.Slowo + " jest: " + ang2.Tlumaczenie.Slowo);
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Podaj slowo polskie");
                        input = Console.ReadLine();
                        watch = Stopwatch.StartNew();
                        var pol3 = p.Wyszukaj(p.korzen, input);
                        watch.Stop();
                        if (pol3 == null)
                        {
                            Console.WriteLine("Podane slowo polskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wyszukano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                            if (pol3.Tlumaczenie == null)
                            {
                                Console.WriteLine("Podane slowo nie ma tlumaczenia");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Tłumaczeniem: " + pol3.Slowo + " jest: " + pol3.Tlumaczenie.Slowo);
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj slowo polskie do usuniecia");
                        input = Console.ReadLine();
                        Wezel temp5 = p.korzen;
                        Wezel tlumaczenie = a.korzen;
                        bool znaleziony = false;
                        bool wywazone = false;
                        watch = Stopwatch.StartNew();
                        try
                        {
                            p.UsunSlowo(ref temp5, input, ref znaleziony, ref wywazone, ref tlumaczenie, a);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Usunieto wybrany element. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        p.korzen = temp5;
                        a.korzen = tlumaczenie;
                        break;
                    case 6:
                        Console.WriteLine("Podaj slowo angielskie do usuniecia");
                        input = Console.ReadLine();
                        Wezel temp6 = a.korzen;
                        Wezel tlumaczenie2 = p.korzen;
                        bool znaleziony2 = false;
                        bool wywazone2 = false;
                        watch = Stopwatch.StartNew();
                        try
                        {
                            a.UsunSlowo(ref temp6, input, ref znaleziony2, ref wywazone2, ref tlumaczenie2, p);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Usunieto wybrany element. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        a.korzen = temp6;
                        p.korzen = tlumaczenie2;
                        break;
                    case 7:
                        a.WypiszDrzewoKLP(a.korzen);
                        Console.WriteLine();
                        break;
                    case 8:
                        /*
                        Console.Clear();
                        for (int i = 0; i < 5; i++)
                        {
                            a.CzyWywazone = false;
                            p.CzyWywazone = false;
                            string rndAng = RandomString(2);
                            string rndPol = RandomString(2);
                            Console.WriteLine("\tWstawienie slowa {0}", rndAng);
                            Wezel temp8 = a.korzen;
                            bool rotacja8 = false;
                            try
                            {

                                a.WstawSlowo(ref temp8, rndAng, ref rotacja8);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message +" Słowo angielskie:  " + rndAng);
                                //break;
                            }
                            a.korzen = temp8;
                            var tempAng = a.Wyszukaj(a.korzen, rndAng);
                            Wezel temp9 = p.korzen;
                            bool rotacja9 = false;
                            try
                            {
                                p.WstawSlowo(ref temp9, rndPol, ref rotacja9);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + " Słowo polskie:  " + rndPol);
                                break;
                            }
                            p.korzen = temp9;
                            var tempPol = p.Wyszukaj(p.korzen, rndPol);
                            tempAng.Tlumaczenie = tempPol;
                            tempPol.Tlumaczenie = tempAng;
                            a.WypiszDrzewoKLP(a.korzen);
                            Console.WriteLine();
                        } */
                        Console.WriteLine("Ta usługa została wyłączona. Wykup AVL PREMIUM już dzisiaj !!!\n");
                        break;
                                              
                }
                if (exit)
                    break;
            }
            Console.WriteLine("\nSlownik angielski:");
            a.WypiszDrzewo(a.korzen);
            Console.WriteLine("\nSlownik polski:");
            p.WypiszDrzewo(p.korzen);
            ioManager.WypiszSlowa(a.korzen);
            ioManager.closeStreamWriter();
            Console.ReadKey();

        }
    }
}
