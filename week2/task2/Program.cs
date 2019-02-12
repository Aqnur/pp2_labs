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
            string s = File.ReadAllText(@"C:\Aknur\test\input.txt"); //read all element in the file
            string[] ss = s.Split(); //split elemtns of string
            int n = ss.Length; //give to n length of ss
            int[] a = new int[n]; //create an array of n length
            using (StreamWriter file = new StreamWriter(@"C:\Aknur\test\output.txt")) //here we write everything to another file
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(ss[i]); //convert elements to integer
                    if (IsPrime(a[i])) //use the function is prime
                    {
                        file.Write(a[i] + " "); //write in file
                    }
                }
            }
        }
        static bool IsPrime(int n) // function is prime
        {
            if (n == 1) return false ; //if it is 1 false
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
