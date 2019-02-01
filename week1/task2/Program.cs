using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Student
    {
        public string name;
        public string id;
        public string yearOfStudy;

        public Student(string name, string id, string yearOfStudy)
        {
            this.name = name;
            this.id = id;
            this.yearOfStudy = yearOfStudy;
        }

        public Student()
        {
            name = Console.ReadLine();
            id = Console.ReadLine();
            yearOfStudy = Console.ReadLine();
        }

        public void PrintInfo()
        {
            Console.WriteLine(name);
            Console.WriteLine(id);
            Console.WriteLine(yearOfStudy);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.PrintInfo();
        }
    }
}
