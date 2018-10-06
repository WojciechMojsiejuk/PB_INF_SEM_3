using System;
using System.Collections.Generic;
using System.Linq;
namespace ASD1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int[] input_array = new int[] { 2, 3, 4, 4, 5, 1, 3, 2, 5, 4 };//example array
            /*
             * bool used to control while loop
             * it checks if any merging happened in current loop sesion
             * if not it means there is no more possibilities to merge
             * and algorithm should stop
            */
			bool merge_in_current_loop = true;
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
			 * max value of input array*5000
			 * 5000 because we count pairs
			 * In worst case scenario where every number is 1000
			 * our counting array will have 1000*5000=50000000 cells
			 * containing int(32b)=4B
			 * Memory complexity O(20MB)
            */
			int max_value_of_input_array = input_array.Max();
			int[] counting_array = new int[50];//example value which needs to be changed to 5000*max_value_of_input_array
         
			for (int i = 0; i < input_array.Length; i++)
            {
				counting_array[input_array[i]]++;
            }
			while(merge_in_current_loop)
			{
				result_of_counting = 0;
				merge_in_current_loop = false;
				for (int i = 0; i < input_array.Length*factor;i++)
				{
					quotient = counting_array[i] / 2;
					reminder = counting_array[i] % 2;
					counting_array[2 * i] += quotient / 2;
					counting_array[i] = reminder;

					if (quotient == 0)
					{
						merge_in_current_loop = false;
						result_of_counting++;
					}
					else
					{
						merge_in_current_loop = true;
					}
				}
				factor *= 2;
			}
			Console.WriteLine(result_of_counting);
        }
    }
}
