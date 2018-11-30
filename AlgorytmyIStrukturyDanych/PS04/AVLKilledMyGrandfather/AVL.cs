using System;
using System.Diagnostics;
using System.IO;

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
    class AVLExceltion:Exception
    {
       public AVLExceltion(string message) : base(message) { }
    }
    class SlownikPolskiAVL
    {
        public WezelPolski WstawSlowo(WezelPolski root, string slowoPolskie)
        {
            if (root == null) //gdy drzewo jeszcze nie jest utworzone
            {
                root = new WezelPolski
                {
                    slowo = slowoPolskie
                };
            }
            else if (string.Compare(slowoPolskie, root.slowo)<0)
            {
                root.lewy = WstawSlowo((WezelPolski)root.lewy, slowoPolskie);
                root.waga++;
            }
            else if (string.Compare(slowoPolskie, root.slowo) > 0)
            {
                root.prawy = WstawSlowo((WezelPolski)root.prawy, slowoPolskie);
                root.waga--;
            }
            else
            {
                throw new AVLExceltion("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
            }
            //sprawdzanie wag
            if(root.waga>=2)
            {
                if (root.lewy.waga == 1)
                    RotacjaRR();
                else
                    RotacjaLR();
            }
            if(root.waga<=-2)
            {

                if (root.prawy.waga == 1)
                    RotacjaRL();
                else
                    RotacjaLL();
            }
            return root;
        }

        private void RotacjaLL()
        {
            throw new NotImplementedException();
        }

        private void RotacjaRL()
        {
            throw new NotImplementedException();
        }

        private void RotacjaLR()
        {
            throw new NotImplementedException();
        }

        private void RotacjaRR()
        {
            throw new NotImplementedException();
        }

        public void traverse(WezelPolski root)
        {
            if (root == null)
            {
                return;
            }

            traverse((WezelPolski)root.lewy);
            traverse((WezelPolski)root.prawy);
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
                    a.WstawSlowo(new WezelAngielski(substrings[i]));
                }
                //polskie
                else
                {
                    p.WstawSlowo(new WezelPolski(substrings[i]));
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
            root = bst.WstawSlowo(root, "Kasia");
            root =bst.WstawSlowo(root, "Jan");
            root = bst.WstawSlowo(root, "Ludmila");
            root = bst.WstawSlowo(root, "Adam");

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
