using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASDPS0506ZAD3
{
    public class E
    {
        public int v1;
        public int v2;
        public int w;
        public E(int wierzcholek1, int wierzcholek2, int wagaKrawedzi)
        {
            v1 = wierzcholek1;
            v2 = wierzcholek2;
            w = wagaKrawedzi;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("In0303.txt"); //Otwarcie pliku z ktorego pobrane zostana dane
            string[] zalozenia = reader.ReadLine().Split(' '); //Wczytanie pierwszej linii z pliku
            int V = Int32.Parse(zalozenia[0]);//Ilość wierzchołków
            int E = Int32.Parse(zalozenia[1]);//Ilość krawędzi
            string[] numbers = new string[V];//Ilość krawedzi
            string[] read = new string[2*V]; //Zmienna pomocnicza do rozróżniania v2 i w
            var krawedzie = new List<E>();
            int counter = 0;//licznik do wczytania E krawedzi
            for (int i = 0; i < V; i++)
            {

                read = reader.ReadLine().Split(' ');
                counter += read.Length / 2;
                for (int j = 0; j < read.Length;j=j+2)
                {
                    krawedzie.Add(new E(i + 1, Int32.Parse(read[j]), Int32.Parse(read[j+1])));
                }
                if (counter == E)
                    break;
            }
            foreach( E krawedz in krawedzie)
            {
                Console.WriteLine("V1:"+krawedz.v1 + " V2: " + krawedz.v2 + " Waga: " + krawedz.w);
            }
            var sortedList = krawedzie.OrderBy(e => e.w).ToList();
            Console.WriteLine("Po posortowaniu");
            foreach (E krawedz in sortedList)
            {
                Console.WriteLine("V1:" + krawedz.v1 + " V2: " + krawedz.v2 + " Waga: " + krawedz.w);
            }
        }
    }

}
