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
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string s = Console.ReadLine();
            string[] arr = s.Split();

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]);
                for(int j = 0; j < 2; j++)
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
    }
}
