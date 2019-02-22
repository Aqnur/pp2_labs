using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task1
{
    [Serializable]
    public class ComplexNumber
    {
        public int a, b;

        public ComplexNumber()
        {
            a = 1;
            b = 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();
        }
        
        private static void F1()
        {
            ComplexNumber cn = new ComplexNumber();
            FileStream fs = new FileStream("complex.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));

            xs.Serialize(fs, cn);
            fs.Close();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));

            ComplexNumber t = xs.Deserialize(fs) as ComplexNumber;

            fs.Close();
        }
    }
}
