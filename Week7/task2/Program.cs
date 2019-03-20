using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread();
            MyThread t2 = new MyThread();
            MyThread t3 = new MyThread();

            t1.startThread();
            t2.startThread();
            t3.startThread();
        }
    }
    class MyThread
    {
        public void threadField()
        {

        }
        public void startThread()
        {

        }
    }
}
