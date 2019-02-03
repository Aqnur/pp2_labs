using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); //the length of array
            int[] a = new int[n]; //creating array with lenth n
            string s = Console.ReadLine(); //full fill the elements in array
            string[] arr = s.Split(); //split previous string to array

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); //converting string to array
                for(int j = 0; j < 2; j++) //double each element and output;
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
    }
}
