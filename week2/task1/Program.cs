using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            if (IsPalindrome(s))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static bool IsPalindrome(string s)
        {
            string str = s;
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            string ss = new string(c);
            if(str == ss)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
