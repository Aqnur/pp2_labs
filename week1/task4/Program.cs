using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= n; ++i)
            {
                for(int j = 1; j <= n; ++j)
                {
                    if(j > n - i)
                    {
                        Console.Write("[*]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
