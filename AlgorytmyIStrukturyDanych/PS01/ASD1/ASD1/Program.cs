using System;
using System.Linq;
using System.IO;
namespace ASD1{
	class MainClass
    {
        public static void Main(string[] args)
        {
			/*
			 * StreamWriter test = new StreamWriter("8.txt");
			test.WriteLine(1000);
			for (int o = 1; o <= 1000;o++)
			{
				test.WriteLine(o % 10000);
			}
			test.Close();*/

			string[] lines = File.ReadAllLines("in.txt");
			int file_size = Int32.Parse(lines[0]);
            int[] input_array = new int[file_size];
			int?[] tab = new int?[file_size]; //array used in second method
		    long optimal_operations = 0;
		    long naive_operations = 0;
			for (int i = 1; i <= file_size;i++)
			{
				input_array[i - 1] = Int32.Parse(lines[i]);
				tab[i-1]=Int32.Parse(lines[i]);
			}

            /*
             * bool used to control while loop
             * it checks if any merging happened in current loop sesion
             * if not it means there is no more possibilities to merge
             * and algorithm should stop
            */
			bool merge_in_current_loop = true;
			bool need_to_expand_search = false;
			int result_of_counting=0;
			int quotient = 0;
			int reminder = 0;
            /*
             * factor is used to reduce searching in counting_array
             * in first step we only need to go to max_value_of_input_array
             * in second step if there were at least two max_values we need to search
             * 2*max_value_of_input_array cells
             * and so on in every iteration
             * therefore factor is multiplied by 2 after leaving for loop
            */
			int factor = 1;
			/*
			 * By pset specification there are n numbers where n<=10 000.
			 * Each number a<=1000
			 * Therefore sufficient size of counting array is
			 * max value of input array*8128
			 * 8128 because there are 2^13 divisions by 2 to get from 10000 to 1
			 * In worst case scenario where every number is 1000
			 * our counting array will have 1000*8128 cells
			 * containing int(32b)=4B
			 * Memory complexity O(2MB)
            */
			int max_value_of_input_array = input_array.Max();
			int[] counting_array = new int[8128*max_value_of_input_array];
         
			for (int i = 0; i < input_array.Length; i++)
            {
				counting_array[input_array[i]]++;
			    optimal_operations++;
            }
			while(merge_in_current_loop)
			{
				result_of_counting = 0;
				merge_in_current_loop = false;
				for (int i = 0; i <= max_value_of_input_array*factor;i++)
				{
				    optimal_operations++;
					if (counting_array[i] == 1)
                        result_of_counting++;
					quotient = counting_array[i] / 2;
					reminder = counting_array[i] % 2;
					counting_array[2 * i] += quotient;
					counting_array[i] = reminder;
					if (quotient != 0)
					{
						merge_in_current_loop = true;
						if (i >= 0.5*max_value_of_input_array * factor) //not sure if this work
							need_to_expand_search = true;
							
					}
				}
                /* 
                 * Without this condition an exception can be raised
                 * because iterator is out of range
                 * There might be a problem if counting works great on big numbers tho
                */
				if (max_value_of_input_array * factor * 2 < counting_array.Length && need_to_expand_search)
					factor *= 2;
			}
			StreamWriter output_file = new StreamWriter("out.txt");
			output_file.WriteLine(result_of_counting);
			Console.WriteLine("Liczba operacji algorytmu optymalnego: "+optimal_operations); //gdy dane sa powtarzalne
			//Koniec rozwiazania optymalnego O=k*n gdzie k jest stałą powtarzalności
            //Gorszy sort algorytmow O=cn^2
			int k = 0;
			bool found_anything_in_this_loop = true;
			while(found_anything_in_this_loop)
			{
				
				found_anything_in_this_loop = false;
				for (int j = k; j < file_size; j++)
                {
				    naive_operations++;
                    if (tab[j] == null)
                        continue;
                    if (tab[k] == tab[j]&&k!=j)
                    {
                        tab[k] *= 2;
                        tab[j] = null;
                        found_anything_in_this_loop = true;
						j = 0;
						k = 0;
						continue;
                    }
                }
				if(found_anything_in_this_loop==false&&k!=file_size-1)
				{
					k++;
					found_anything_in_this_loop = true;
				}  				
			}
			int counter_of_not_nulls_in_array = 0;
			for (int l = 0; l < file_size;l++)
			{
			    naive_operations++;
				//Console.WriteLine(tab[l]); 
				if (tab[l] != null)
					counter_of_not_nulls_in_array++;
			}    
			Console.WriteLine("Liczba operacji algorytmu naiwnego: "+naive_operations);    //gdy dane sa unikatowe       
			output_file.WriteLine(counter_of_not_nulls_in_array);
			output_file.Close();
        }
    }
}
