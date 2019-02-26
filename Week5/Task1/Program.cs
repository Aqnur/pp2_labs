using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public ComplexNumber(int _realNum = 1, int _ImageNum = 1)
        {
            a = _realNum;
            b = _ImageNum;
        }
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            ComplexNumber c3 = new ComplexNumber();
            c3.b = lcm(c1.b, c1.b);
            c3.a = ((c3.b / c1.b) * c1.a) + (c2.a * (c3.b / c2.b));
            int Gcd = gcd(c3.a, c3.b);
            c3.a /= Gcd;
            c3.b /= Gcd;
            return c3;
        }
        public override string ToString()
        {
            return Convert.ToString(a) + '/' + Convert.ToString(b);
        }
        public static int lcm(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }
        public static int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
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
