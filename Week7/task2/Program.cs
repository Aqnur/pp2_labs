using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");

            t1.startThread();
            t2.startThread();
            t3.startThread();
        }
    }
    class MyThread
    {
        Thread threadField;
        string s;

        public MyThread(string _s)
        {
            s = _s;
        }
        public void startThread()
        {
            threadField = new Thread(Display);
            threadField.Start();
        }
        public void Display()
        {
            int i = 0;
            while(i != 4)
            {
                i++;
                Console.WriteLine((s + " выводит " + i).ToString());
            }
            if(i == 4)
            {
                Console.WriteLine(s + " завершилася");
            }
        }
    }
}
