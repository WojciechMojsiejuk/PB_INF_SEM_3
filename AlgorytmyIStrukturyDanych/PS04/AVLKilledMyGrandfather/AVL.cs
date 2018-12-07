using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ASD0901ZAD1
{


    class Wezel
    {
        public string slowo;
        public int waga;
        public Wezel lewy;
        public Wezel prawy;
    }

    class WezelPolski:Wezel
    {
       public WezelAngielski tlumaczeniePolAng;
       
    }
    class WezelAngielski:Wezel
    {
        public WezelPolski tlumaczenieAngPol;

    }
    class AVLException:Exception
    {
       public AVLException(string message) : base(message) { }
    }
    class SlownikAVL
    {

        public void RotacjaLL(ref Wezel root)
        {
            //zmiana pozycji
            Wezel A = root;
            root = A.prawy;
            Wezel II = root.lewy;
            root.lewy = A;
            root.lewy.prawy = II;
        }

        public void RotacjaRL(ref Wezel root)
        {
            throw new NotImplementedException();
        }

        public void RotacjaLR(ref Wezel root)
        {
            throw new NotImplementedException();
        }

        public void RotacjaRR(ref Wezel root)
        {
            //zmiana pozycji
            Wezel A = root;
            root = A.lewy;
            Wezel II = root.prawy;
            root.prawy = A;
            root.prawy.lewy = II;
        }

        public void Wypisz(Wezel root)
        {
            if (root == null)
            {
                throw new NotImplementedException();
            }

            Wypisz(root.lewy);
            Wypisz(root.prawy);
        }
    }
    class SlownikPolskiAVL:SlownikAVL
    {
        public WezelPolski WstawSlowo(ref WezelPolski root, string slowoPolskie)
        {
            if (root == null) //gdy dotrze do końca drzewa, tworzy nowy element
            {
                root = new WezelPolski
                {
                    slowo = slowoPolskie
                };

            }
            else if (string.Compare(slowoPolskie, root.slowo)<0)
            {
                WezelPolski lewy = (WezelPolski)root.lewy;
                root.lewy=WstawSlowo(ref lewy, slowoPolskie);
                root.waga++;
            }
            else if (string.Compare(slowoPolskie, root.slowo) > 0)
            {
                WezelPolski prawy = (WezelPolski)root.prawy;
                root.prawy = WstawSlowo(ref prawy, slowoPolskie);
                root.waga--;
            }
            else
            {
                throw new AVLException("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
            }
            //sprawdzanie wag
            /*if (root.waga == 0)
                //w jaki sposób można przerwać rekurencje?
                throw new NotImplementedException();
            */
            if (root.waga==2)
            {
                if (root.lewy.waga == 1)
                {
                    Wezel wezel = root;
                    RotacjaRR(ref wezel);
                    root = (WezelPolski)wezel;
                    //ustawianie nowych wag
                    root.waga = 0;
                    root.prawy.waga = 0;
                }
                else
                {
                    Wezel C = root.lewy.prawy;
                    Wezel wezel = root.lewy;
                    RotacjaLL(ref wezel);
                    root.lewy = (WezelPolski)wezel;
                    wezel = root;
                    RotacjaRR(ref wezel);
                    root = (WezelPolski)wezel;
                    //ustawianie nowych wag
                    root.waga = 0;
                    switch (C.waga)
                    {
                        case (1):

                            root.prawy.waga = 0;
                            root.lewy.waga = -1;
                            break;
                        case (0):

                            root.prawy.waga = 0;
                            root.lewy.waga = 0;
                            break;
                        case (-1):
                            root.prawy.waga = 0;
                            root.lewy.waga = 1;
                            break;

                    }
                }
            }
            if(root.waga==-2)
            {

                if (root.prawy.waga == 1)
                {
                    Wezel C = root.prawy.lewy;
                    Wezel wezel = root.prawy;
                    RotacjaRR(ref wezel);
                    root.prawy = (WezelPolski)wezel;
                    wezel = root;
                    RotacjaLL(ref wezel);
                    root = (WezelPolski)wezel;
                    //ustawianie nowych wag
                    root.waga = 0;
                    switch (C.waga)
                    {
                        case(1):

                            root.prawy.waga = 0;
                            root.lewy.waga = -1;
                            break;
                        case(0):

                            root.prawy.waga = 0;
                            root.lewy.waga = 0;
                            break;
                        case(-1):
                            root.prawy.waga = 0;
                            root.lewy.waga = 1;
                            break;

                    }

                }
                else
                {
                    Wezel wezel = root;
                    RotacjaLL(ref wezel);
                    root = (WezelPolski)wezel;
                    //ustawianie nowych wag
                    root.waga = 0;
                    root.prawy.waga = 0;
                }
                    
            }
            return root;
        }
       
    }
    class IOManager
    {
        StreamReader sr = new StreamReader("InOut0401.txt");
        StreamWriter wr;
        public void WczytajSlowa(SlownikPolskiAVL a, SlownikPolskiAVL p) //dodać ANGIELSKI!!!!
        {
            string s = sr.ReadToEnd();
            string[] substrings = s.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < substrings.Count(); i++)
            {
                //parzyste - angielskie
                if (i % 2 == 0)
                {
               //    a.WstawSlowo(new WezelAngielski(substrings[i]));
                }
                //polskie
                else
                {
                 //   p.WstawSlowo(new WezelPolski(substrings[i]));
                }
            }
            sr.Close();
        }
    }

    class MainCLass
    {
        static void Main(string[] args)
        {
            WezelPolski root = null;

            SlownikPolskiAVL bst = new SlownikPolskiAVL();

            bst.WstawSlowo(ref root, "Anna");
            bst.WstawSlowo(ref root, "Balbina");
            bst.WstawSlowo(ref root, "Czeslaw");
            bst.WstawSlowo(ref root, "Darek");
            bst.WstawSlowo(ref root, "Eugeniusz");
            bst.WstawSlowo(ref root, "Filip");
            bst.WstawSlowo(ref root, "Kasia");
            bst.WstawSlowo(ref root, "Jan");
            bst.WstawSlowo(ref root, "Ludmila");
            bst.WstawSlowo(ref root, "Adam");


            /*int SIZE = 2000000;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

            Random random = new Random();

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                a[i] = random.Next(10000);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, a[i]);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.traverse(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();

            Console.ReadKey();
            */
        }
    }
}
