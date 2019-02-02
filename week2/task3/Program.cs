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
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Aknur\test");
            var x = dirInfo.GetFileSystemInfos();
            foreach(var y in x)
            {
                Console.WriteLine(y.Name);
            }
        }
    }
}
