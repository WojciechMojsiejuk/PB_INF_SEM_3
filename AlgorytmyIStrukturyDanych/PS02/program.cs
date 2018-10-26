using System;
using System.Linq;
using System.IO;

namespace ASD02
{
    class MainClass
    {
		public static int Wyznacz_Piwot(int[]tab,int pocz)
		{
			return tab[pocz];
		}
		public static int PARTITION(int[] tab, int pocz, int kon, int piwot)
		{
			int i = pocz;
			int j = kon;
			int temp = 0;
            while (true)
			{
				while (tab[i] < piwot)
					i++;
				while (tab[j] > piwot) 
					j--;
				if (i >= j) 
					return j;
				temp = tab[i];
				tab[i] = tab[j];
				tab[j] = temp;
				i++;
				j--;
			}
                
		}
		public static  QuickSort(int[] tab,int pocz, int kon)
		{
			int piwot = Wyznacz_Piwot(tab, pocz);
			int sr = PARTITION(tab, pocz, kon, piwot);
			QuickSort(tab, pocz, sr);
			QuickSort(tab, sr + 1, kon);
		}
        public static void Main(string[] args)
        {
			//generator plikow
			Random rnd = new Random();
            StreamWriter test = new StreamWriter("In0201.txt");
            int test_size = 5;
            test.Write(test_size);
			test.Write(" ");
            for (int o = 1; o <= test_size; o++)
            {
                test.Write(rnd.Next(-10000, 10000));
				test.Write(" ");
            }
            test.Close();


			StreamReader reader = new StreamReader("In0201.txt");
            string[] numbers = reader.ReadToEnd().Split(' '); //otwarcie pliku z ktorego pobrane zostana dane
			int file_size = Int32.Parse(numbers[0]);//odczytanie pierwszej linii w celu okreslenia rozmiaru tablicy
			int[] input_array = new int[file_size];
			for (int i = 1; i <= file_size; i++)
                {
                    input_array[i - 1] = Int32.Parse(numbers[i]);
                }            
			for (int i = 0; i < file_size; i++)
            {
                System.Console.WriteLine(input_array[i]);
            }
			QuickSort(input_array, 0, file_size - 1);

        }
    }
}
/*
 * tablica incydencji
*/
