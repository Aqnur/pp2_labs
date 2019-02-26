using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2
{
    [Serializable]
    public class Mark
    {
        public string mark;
        public int n;
        public Mark(){}
        public Mark(int n)
        {
            this.n = n;
            mark = nToMark(n);
        }
        public static string nToMark(int n)
        {
            string mark = "";
            if (n >= 0 && n <= 49)
            {
                mark = "F";
            }
            else if (n >= 50 && n <= 74)
            {
                mark = "C";
            }
            else if (n >= 75 && n <= 89)
            {
                mark = "B";
            }
            else if (n >= 90 && n <= 100)
            {
                mark = "A";
            }
            else
            {
                Console.WriteLine("error");
            }
            return mark;
        }
        public override string ToString()
        {
            return string.Format("{0} = {1}",n, mark);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
            fs.Close();

            foreach(var x in marks)
            {
                Console.WriteLine(x.ToString());
            }
        }

        private static void F1()
        {
            Mark calc = new Mark(23);
            Mark phyl = new Mark(73);
            Mark termex = new Mark(97);

            List<Mark> marks = new List<Mark>();
            marks.Add(calc);
            marks.Add(phyl);
            marks.Add(termex);

            FileStream fs = new FileStream("Marks.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            xs.Serialize(fs, marks);

            fs.Close();
        }
    }
}
