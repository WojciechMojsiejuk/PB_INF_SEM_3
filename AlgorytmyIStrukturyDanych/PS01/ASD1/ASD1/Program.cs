using System;
using System.Linq;
using System.IO;
namespace ASD1{
	class MainClass
    {
        public static void Main(string[] args)
        {
			/*
			 *https://github.com/WojciechMojsiejuk/PB_INF_SEM_3/blob/master/AlgorytmyIStrukturyDanych/PS01/zlozonosc.ipynb 
			 * Link do objaśnienia złożoności programu
			 */

			//generator pliku z liczbami losowymi spelniajacymi to zalozenie musi otrzymać tylko w test_size ile danych ma wygenerować
			/*Random rnd = new Random();
			StreamWriter test = new StreamWriter("8.txt");
			int test_size = 10000;
			test.WriteLine(test_size);
			for (int o = 1; o <= test_size;o++)
			{
				test.WriteLine(rnd.Next(1,1000));
			}
			test.Close();
            */

			string[] lines = File.ReadAllLines("in.txt"); //otwarcie pliku z ktorego pobrane zostana dane
			int file_size = Int32.Parse(lines[0]); //odczytanie pierwszej linii w celu okreslenia rozmiaru tablicy
            int[] input_array = new int[file_size];
			int?[] tab = new int?[file_size]; //eng array used in second method; pln tablica z możliwością wstawienia nulla używa w alg. naiwnym
		    long optimal_operations = 0; //licznik operacji elementarnych dla algorytmu optymalnego
			long naive_operations = 0; //licznik operacji elementarnych dla algorytmu naiwnego
            /*pl
             * odczytanie pliku i zapisanie jego danych do tablicy, nie wliczane do złożoności, 
             * spreparowane dla dwóch algorytmów w celu ułatwienia działania
            */
			for (int i = 1; i <= file_size;i++) 
			{
				input_array[i - 1] = Int32.Parse(lines[i]);
				tab[i-1]=Int32.Parse(lines[i]);
			}

            /*eng
             * bool used to control while loop
             * it checks if any merging happened in current loop sesion
             * if not it means there is no more possibilities to merge
             * and algorithm should stop
             * pl
             * zmienne boolowskie odpowiadajace za obsluge algorytmu
             * sprawdzaja czy w danej petli wykonala sie operacja laczenia
             * oraz czy operacja ta wykonala sie w 2 polowie zbioru
             * co oznacza ze obszar poszukiwan musi byc zwiekszony
            */
			bool merge_in_current_loop = true;
			bool need_to_expand_search = false;
			int result_of_counting=0;
			int quotient = 0; //czesc calkowita
			int reminder = 0; //reszta z dzielenia
            /*eng
             * factor is used to reduce searching in counting_array
             * in first step we only need to go to max_value_of_input_array
             * in second step if there were at least two max_values we need to search
             * 2*max_value_of_input_array cells
             * and so on in every iteration
             * therefore factor is multiplied by 2 after leaving for loop
             * pln
             * wspolczynnik wykorzystywany do powiekszania obszarow przeszukiwan
            */
			int factor = 1;
			/*eng
			 * By pset specification there are n numbers where n<=10 000.
			 * Each number a<=1000
			 * Therefore sufficient size of counting array is
			 * max value of input array*8192
			 * 8192 because there are 2^13 divisions by 2 to get from 10000 to 1
			 * In worst case scenario where every number is 1000
			 * our counting array will have 1000*8192 cells
			 * containing int(32b)=4B
			 * Memory complexity O(32MB)
			 * pln
			 * pesymistyczny przypadek zlozonosci pamieciowej to 10000 liczb o wartosci 1000
			 * by dojsc z 10000 do 1 potrzeba 13 operacji dzielenia przez 2 stad 2^13*1000 moze sie zwiekszyc rozmiar 
			 * 1000*8192 komorek kazda po 4B to ok 32MB <- zlozonosc pamieciowa
            */
			int max_value_of_input_array = input_array.Max();//maks ze zbioru
			int[] counting_array = new int[8192*max_value_of_input_array];//rozmiar tablicy zliczajacej
         
			for (int i = 0; i < input_array.Length; i++) //wprowadzenie danych do tablicy zliczajacej, ilosc operacji n
            {
				counting_array[input_array[i]]++;
			    optimal_operations++;
            }
			while(merge_in_current_loop) //glowna czesc algorytmu, dopoki sa operacje w petli niech sie wykonuje
			{
				result_of_counting = 0; //zwraca ile pozostalo niezsumowanych liczb
				merge_in_current_loop = false;
				for (int i = 0; i <= max_value_of_input_array*factor;i++)//iteruje do maksymalnej liczby przemnozonej przez wspolczynnik
				{
				    optimal_operations++; //do szacowania zlozonosci
					if (counting_array[i] == 1) //jezeli jest 1 to znaczy ze nie da sie juz zsumowac
                        result_of_counting++;
					quotient = counting_array[i] / 2;
					reminder = counting_array[i] % 2;
					counting_array[2 * i] += quotient; //czesc calkowita wstaw o indeks dwa razy wiekszy
					counting_array[i] = reminder; //reszte wstaw w to samo miejsce
					if (quotient != 0)
					{
						merge_in_current_loop = true;
                        /*
                         * warunek jezeli operacja laczenia byla w 2 polowie 
                         * to nalezy zwiekszyc obszar poszukiwan
                         */
						if (i >= 0.5*max_value_of_input_array * factor)
							need_to_expand_search = true;
							
					}
				}
                /* eng
                 * Without this condition an exception can be raised
                 * because iterator is out of range
                 * There might be a problem if counting works great on big numbers tho
                 * pln
                 * warunek by nie przekroczyc rozmiaru tablicy zliczajacej
                */
				if (max_value_of_input_array * factor * 2 < counting_array.Length && need_to_expand_search)
					factor *= 2;
			}
			StreamWriter output_file = new StreamWriter("out.txt"); //zapis do pliku wyjsciowego
			output_file.WriteLine(result_of_counting);
			Console.WriteLine("Liczba operacji algorytmu optymalnego: "+optimal_operations); //pokazuje w terminalu liczbe operacji elementarnych

			StreamWriter optimal = new StreamWriter("optimal.txt", true);
            optimal.WriteLine(optimal_operations);
            optimal.Close();

			//Koniec rozwiazania optymalnego O=(k*n) gdzie k jest stałą powtarzalności
         
            //Gorszy sort algorytmow O=cn^2

			int k = 0;
			bool found_anything_in_this_loop = true;
			while(found_anything_in_this_loop)
			{
				
				found_anything_in_this_loop = false;
				for (int j = k; j < file_size; j++)
                {
				    naive_operations++;
                    if (tab[j] == null) //element pusty nie ma co sie nad nim zastanawiac
                        continue;
                    if (tab[k] == tab[j]&&k!=j) //jezeli k to nie j i wartosci sa takie same to je sumujemy
                    {
                        tab[k] *= 2; //k zwiekszamy dwukrotnie
                        tab[j] = null; //miejsce j ustawiamy na nulla
                        found_anything_in_this_loop = true;
						j = 0; //musimy zaczac poszukiwania od nowa
						k = 0;
						continue;
                    }
                }
				if(found_anything_in_this_loop==false&&k!=file_size-1)
				{
					k++;
					found_anything_in_this_loop = true; //jezeli nic nieznalezlismy ale k nie doszlo do konca to szukamy dalej
				}  				
			}
			int counter_of_not_nulls_in_array = 0;
			for (int l = 0; l < file_size;l++) //oddzielna tablica zliczajaca ile niepustych elementow sie w niej znajduje
			{
			    naive_operations++;
				//Console.WriteLine(tab[l]); 
				if (tab[l] != null)
					counter_of_not_nulls_in_array++;
			}    
			Console.WriteLine("Liczba operacji algorytmu naiwnego: "+naive_operations);    //pokazuje w terminalu liczbe operacji elementarnych     
			output_file.WriteLine(counter_of_not_nulls_in_array);
   			output_file.Close();
			StreamWriter naive = new StreamWriter("naive.txt",true);
            
			naive.WriteLine(naive_operations);
			naive.Close();
        }
    }
}
