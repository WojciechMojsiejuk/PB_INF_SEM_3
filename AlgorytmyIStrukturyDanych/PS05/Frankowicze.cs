using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ASDPS0708ZAD1
{
    public class V
    {
        public string nazwaBanku;
        public int numerBanku;
        public int d;
        public int f;
        public bool czyOdwiedzony = false;
        public V(int i)
        {
            nazwaBanku = "Bank" + i.ToString();
            numerBanku = i;
        }
        public V()
        {

        }
    }
    public class MainClass
    {
        static int time = 0;
        static List<V>[] transposedG;
        static List<V>[] G;
        static bool returnStronglyConnectedComponent = false;
        static List<List<V>> silnieskładowe;
        static List<V> temp;

        public static void Main(string[] args)
        {
            StreamReader input= new StreamReader("in0501.txt");
            string s = input.ReadLine();
            string[] substrings = s.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int n = Int32.Parse(substrings[0]); //liczba bankow
            int m = Int32.Parse(substrings[1]); //wspolczynnik bezpieczenstwa
            double CHF = Double.Parse(substrings[2],CultureInfo.InvariantCulture); //kurs franka
            double EURO = Double.Parse(substrings[3],CultureInfo.InvariantCulture); //kurs euro
            int k = Int32.Parse(substrings[4]); //indeks pierwszego banku
            int t = Int32.Parse(substrings[5]); ////indeks drugiego banku
            double[,] SR = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                s = input.ReadLine();
                substrings = s.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    SR[i, j] = double.Parse(substrings[j], CultureInfo.InvariantCulture);
                }
            }
            //Wyświetlenie załadowanych wartości stopnia ryzyka
            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(SR[i, j] + " ");
                }
                Console.Write("\n");
            }*/
            //utworzenie tablicy banków
            V[] tablicaBankow = new V[n];
            for (int i = 0; i < n; i++)
            {
                tablicaBankow[i] = new V(i+1);
            }
            //Wyswietlenie tablicy banków
            /*
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(tablicaBankow[i].nazwaBanku);
            }*/
            //utworzenie tablicy list incydencji
            G = new List<V>[n];
            //uzupełnienie listy incydencji
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(m*(1-SR[i,j])>CHF-EURO)
                    {
                        if (G[i] == null)
                            G[i] = new List<V>();
                        G[i].Add(tablicaBankow[j]);
                    }
                }
            }
            Console.WriteLine("\n Lista incydencji grafu:\n");
            //wyswietlenie listy incydencji
            for (int i = 0; i < n; i++)
            {
                Console.Write(tablicaBankow[i].nazwaBanku+":\t");
                foreach (var element in G[i])
                    Console.Write(element.nazwaBanku + " ");
                Console.Write("\n");
            }

            //pierwsze przeszukiwanie w głąb dokonane na grafie przed transpozycją
            for (int i = 0; i < n; i++)
            {
                DFS(tablicaBankow[i]);
            }
            Console.WriteLine("\n Etykiety czasowe po przeszukiwaniu w głąb:\n");
            //wyswietlenie etykiet czasowych dla odpowiednich wierzchołków
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(tablicaBankow[i].nazwaBanku+": "+ tablicaBankow[i].d.ToString()+"/"+ tablicaBankow[i].f.ToString());
            }

            //posortowanie tablicy banków względem f malejąco
            V[] posortowaneWierzcholki = tablicaBankow.OrderByDescending(c => c.f).ToArray();

            /*for (int i = 0; i < n; i++)
            {
                Console.WriteLine(posortowaneWierzcholki[i].nazwaBanku);
            }*/

            //transpozycja grafu
            transposedG = new List<V>[n];
            for (int i = 0; i < n; i++)
            {
                transposedG[i] = new List<V>();
            }
            for (int i = 0; i < n; i++)
            {
                foreach (var element in G[i])
                {
                    transposedG[element.numerBanku - 1].Add(tablicaBankow[i]);
                }
            }
            Console.WriteLine("\nLista incydencji grafu po transpozycji: \n");
            //wyswietlenie odwróconej listy incydencji i wyczyszczenie informacji
            for (int i = 0; i < n; i++)
            {
                Console.Write(tablicaBankow[i].nazwaBanku + ":\t");
                foreach (var element in transposedG[i])
                {
                    Console.Write(element.nazwaBanku + " ");
                }
                tablicaBankow[i].czyOdwiedzony = false;
                tablicaBankow[i].d = 0;
                tablicaBankow[i].f = 0;
                Console.Write("\n");
            }
            G = transposedG;
            time = 0;
            returnStronglyConnectedComponent = true;
            silnieskładowe = new List<List<V>>();
            //drugie przeszukiwanie w głąb dokonane na grafie przed transpozycją
            Console.WriteLine("\nSilnie spójne składowe :\n");
            for (int i = 0; i < n; i++)
            {
                if (posortowaneWierzcholki[i].czyOdwiedzony == false)
                {
                    temp = null;
                    DFS(posortowaneWierzcholki[i]);
                    silnieskładowe.Add(temp);
                    Console.Write("\n");
                }
            }
            var WzajemnePoreczenieZBankiemK = (from sublist in silnieskładowe
                           from item in sublist
                           where item.numerBanku == k
                           select sublist).FirstOrDefault();
            var WzajemnePoreczenieZBankiemT = (from sublist in silnieskładowe
                                               from item in sublist
                                               where item.numerBanku == t
                                               select sublist).FirstOrDefault();


            Console.WriteLine("\n Etykiety czasowe po przeszukiwaniu w głąb:\n");
            //wyswietlenie etykiet czasowych dla odpowiednich wierzchołków
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(posortowaneWierzcholki[i].nazwaBanku + ": " + posortowaneWierzcholki[i].d.ToString() + "/" + posortowaneWierzcholki[i].f.ToString());
            }
            StreamWriter writer = new StreamWriter("Out0501.txt");
            Console.WriteLine("\n Wzajemne poręczenie z bankiem Bk:\n");
            foreach(V bank in WzajemnePoreczenieZBankiemK)
            {
                Console.Write(bank.nazwaBanku+" ");
                writer.Write(bank.nazwaBanku + " ");
            }
            Console.WriteLine("\n\n Wzajemne poręczenie z bankiem Bt:\n");
            writer.Write("\n");
            foreach (V bank in WzajemnePoreczenieZBankiemT)
            {
                Console.Write(bank.nazwaBanku + " ");
                writer.Write(bank.nazwaBanku + " ");
            }
            Console.Write("\n");
            writer.Close();
            input.Close();

        }
        public static void DFS(V element)
        {
            if(element.czyOdwiedzony==false)
            {
                if (returnStronglyConnectedComponent == true)
                {
                    Console.Write(element.nazwaBanku + " ");
                    if (temp == null)
                        temp = new List<V>();
                    temp.Add(element);
                }
            element.d = ++time;
            element.czyOdwiedzony = true;
            var listaSasiadow = G[element.numerBanku - 1];
            foreach(var sasiad in listaSasiadow)
            {
                if(sasiad.czyOdwiedzony==false)
                {
                    DFS(sasiad);
                }
            }
            element.f = ++time;
            }
        }
    }
}
