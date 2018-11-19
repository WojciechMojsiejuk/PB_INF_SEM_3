using System;
using System.IO;

namespace ASDPS0506ZAD2
{
    public class DPP
    {
        public int value;
        public int weight;
        public DPP(int x, int y)
        {
            value = x;
            weight = y;
        }

    }
    class MainClass
    {
        public static void Paths(int[,]searchingTab, DPP[] przedmioty, int y, int x)
        {

            if (searchingTab[y-1, x] == 0)
            {
                Console.WriteLine(y);
                return;
            }

            if (searchingTab[y, x] == searchingTab[y - 1, x])
            {
                Paths(searchingTab,przedmioty, y - 1, x);
            }
            if (x - przedmioty[y - 1].weight>0)
            {
                if (searchingTab[y, x] == searchingTab[y - 1, x - przedmioty[y - 1].weight] + przedmioty[y - 1].value)
                {
                    Console.Write(y + " ");
                    Paths(searchingTab, przedmioty, y - 1, x - przedmioty[y - 1].weight);
                }
            }
            else if(searchingTab[y, x] != searchingTab[y - 1, x])
            {
                Console.WriteLine(y);
                return;
            }

        }
        public static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("In0302.txt"); //Otwarcie pliku z ktorego pobrane zostana dane
            string[] zalozenia = reader.ReadLine().Split(' '); //Wczytanie pierwszej linii z pliku
            int n = Int32.Parse(zalozenia[0]);//Ilość możliwych przedmiotów
            int W = Int32.Parse(zalozenia[1]);//Ile można maksymalnie załadować
            string[] numbers = new string[2*n];//Pozostale dane z pliku
            string[] read = new string[2]; //Zmienna pomocnicza do rozróżniania wag i wartości
            for (int i = 0; i < 2*n;i=i+2)
            {

                read = reader.ReadLine().Split(' ');
                numbers[i]=read[0];
                numbers[i + 1] = read[1];
            }
           
            DPP[] przedmioty = new DPP[n];
            for (int i = 0;i<n;i++)
            {
                przedmioty[i] = new DPP(Int32.Parse(numbers[2*i]), Int32.Parse(numbers[2*i + 1]));
            }
            int[,] S= new int[n+1, W+1];//Tablica potrzebna do rozwiązania dyskretnego problemu plecakowego
            for (int i = 0; i < n;i++) //Pętla wyświetlająca dane wejściowe
            {
                Console.Write(przedmioty[i].value +" " + przedmioty[i].weight + "\n");
            }
            //Warunki brzegowe
            for (int i = 0; i <= W;i++)
            {
                S[0, i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                S[i, 0] = 0;
            }

            for (int i = 1; i <= n;i++)
            {
                for (int j = 0; j <= W;j++)
                {
                    //
                    Console.Clear();
                    if(j<przedmioty[i-1].weight)
                    {
                        S[i, j] = S[i-1, j];
                    }
                    else
                    {
                        S[i, j] = Math.Max(S[i-1, j], S[i - 1, j - przedmioty[i-1].weight] + przedmioty[i-1].value);
                    }
                }
            }
            //Do wyswietlania zmian obliczen w debug mode
            int x;
            int y;
            for (x = 0; x <= n; x++)
            {
                for (y = 0; y <= W; y++)
                {
                    Console.Write(S[x, y] + " ");
                }
                Console.Write("\n");
            }

            Paths(S, przedmioty, n, W);
        
        }
    }
}

