using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"C:\Aknur\test\input.txt"); //reading all element in the file
            if (IsPalindrome(s)) //using the function IsPalindrome
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static bool IsPalindrome(string s) //function checking is palindrome
        {
            string str = s; //give s to str 
            char[] c = s.ToCharArray(); //converting s to array of char
            Array.Reverse(c); //reversing the array of char
            string ss = new string(c); // again convert to string 
            if(str == ss) //check if the element of s and str equal
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
