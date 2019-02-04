using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string NewPath = @"C:\Users\aknur\Desktop\path\";
            string extention = ".txt";
            string path = NewPath + name + extention;
            string NewPath1 = @"C:\Users\aknur\Desktop\path1\";
            string path1 = NewPath1 + name + extention;

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                Console.WriteLine("This file is already exists \n You may cut it to another folder");
                ConsoleKeyInfo press = Console.ReadKey(); 
                if (press.Key == ConsoleKey.C)
                {
                    File.Move(path, path1);
                }
                else
                {
                    Console.WriteLine("\nOk, Goodbye!");        
                }
            }
            //File.Move(path, path1);
        }
    }
}
