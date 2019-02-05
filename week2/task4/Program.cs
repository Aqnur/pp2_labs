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
            bool flag = true;

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            else
            {
                flag = false;
                Console.WriteLine("This file is already exists \n You may cut it to another folder press 'c'");
                ConsoleKeyInfo press = Console.ReadKey(); 
                if (press.Key == ConsoleKey.C)
                {
                    moving(path, path1);
                }
                else
                {
                    Console.WriteLine("\nOk, Goodbye!");        
                }
            }
            if (flag == true)
            {
                Console.WriteLine("File was created if you want to cut it press 'c'");
                ConsoleKeyInfo press2 = Console.ReadKey();
                if (press2.Key == ConsoleKey.C)
                {
                    moving(path, path1);
                }
                else
                {
                    Console.WriteLine("\nOk, Goodbye!");
                }
            }
        }

        public static void moving(string path, string path1)
        {
            if (!File.Exists(path1))
            {
                File.Move(path, path1);
            }
            else
            {
                Console.WriteLine("File exists in path1");
            }
        }
    }
}
