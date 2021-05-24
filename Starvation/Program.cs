using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Starvation
{
    class Program
    {
        private static object lockObj = new object();

        private static Thread threadA = new Thread(ThreadWork) { Name = "Thread A", IsBackground = true };
        private static Thread threadB = new Thread(ThreadWork) { Name = "Thread B", IsBackground = true };

        static void Main(string[] args)
        {
            threadA.Start();
            threadB.Start();

            Console.ReadKey();
        }

        private static void ThreadWork()
        {
            lock (lockObj)
            {
                while (true) // Keep lock forever...
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Doing work.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
