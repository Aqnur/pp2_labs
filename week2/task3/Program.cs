using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\aknur\Desktop\pp2");
            Director(dirInfo, cnt);
        }

        public static void Director(DirectoryInfo dir, int tab)
        {
            foreach (DirectoryInfo y in dir.GetDirectories())
            {
                tabul(tab);
                Console.WriteLine(y.Name);
                Director(y, tab + 1);
            }
            foreach (FileInfo x in dir.GetFiles())
            {
                tabul(tab);
                Console.WriteLine(x.Name);
            }
        }

        public static void tabul(int tab)
        {
            for(int i = 0; i < tab; i++)
            {
                Console.Write("     ");
            }
        }
    }
}
