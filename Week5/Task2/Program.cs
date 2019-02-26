using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    [Serializable]
    public class Mark
    {
        public int n;
        public Mark()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);
            mark(n);
        }
        static void mark(int n)
        {
            if (n >= 0 && n <= 49)
            {
                Console.WriteLine("F");
            }
            else if (n >= 50 && n <= 74)
            {
                Console.WriteLine("C");
            }
            else if (n >= 75 && n <= 89)
            {
                Console.WriteLine("B");
            }
            else if (n >= 90 && n <= 100)
            {
                Console.WriteLine("A");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
