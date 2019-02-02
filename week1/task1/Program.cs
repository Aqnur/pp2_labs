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
            int cnt = 0; //counter = 0
            int n = Convert.ToInt32(Console.ReadLine()); //the size of array
            string s = Console.ReadLine(); //writing the elements of array
            string[] ss = s.Split(); //split the elements to array
            int[] a = new int[n]; //create array with int
            for(int i = 0; i < n; i++)//loop to add elements
            {
                a[i] = int.Parse(ss[i]);//add splited array to another array
                if (IsPrime(a[i]))//checking is element is prime;
                {
                    cnt++;//if prime count it
                }
            }
            Console.WriteLine(cnt);//output nums of primes
            for (int i = 0; i < n; i++)//output primes
            {
                if (IsPrime(a[i]))
                {
                    Console.Write(a[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static bool IsPrime(int num) //bool function to find primes
        {
            if (num <= 1) return false; //if less or equal 1 not prime
            for (int i = 2; i <= Math.Sqrt(num); i++) //loop to find not prime numbers if it is divisible not for itself and 1 false 
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;//in other cases it is prime
        }
    }
}