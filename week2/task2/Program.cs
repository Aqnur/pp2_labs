using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"C:\Aknur\test\input.txt");
            string[] ss = s.Split();
            int n = ss.Length;
            int[] a = new int[n];
            using (StreamWriter file = new StreamWriter(@"C:\Aknur\test\output.txt"))
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(ss[i]);
                    if (IsPrime(a[i]))
                    {
                        file.Write(a[i] + " ");
                    }
                }
            }
        }
        static bool IsPrime(int n)
        {
            if (n == 1) return false ;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
