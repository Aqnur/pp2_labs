using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class Employee
    {
        private string name;
        private string ID;
        private int salary;
        public string N
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string I
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public int S
        {
            get
            {
                return salary += 50000;
            }
            set
            {
                salary = value;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string ID = Console.ReadLine();
            int salary = Convert.ToInt32(Console.ReadLine());
            Employee x = new Employee{N = name, I = ID, S = salary};
            ser(x);
            deser(x);
        }
        static Employee deser(Employee c)
        {
            FileStream fs = new FileStream("employee.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));

            Employee e = xs.Deserialize(fs) as Employee;

            fs.Close();
            Console.WriteLine(e.N);
            Console.WriteLine(e.I);
            Console.WriteLine(e.S);
            return e;
        }

        private static void ser(Employee c)
        {
            FileStream fs = new FileStream("employee.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Employee));

            xs.Serialize(fs, c);

            fs.Close();
        }
    }
}
