using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPool_
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Create 2 threads "normally."
                for (int i = 0; i < 2; i++)
                {
                    new Thread(ThreadWork) { IsBackground = true }.Start();
                }

                // Invoke 2 threads from the Thread Pool.
                for (int i = 0; i < 2; i++)
                {
                    ThreadPool.QueueUserWorkItem(ThreadWork);
                }

                Thread.Sleep(5000);

                Console.WriteLine();
            }
        }

        private static void ThreadWork(object obj) // <- Must have object parameter, to match signature of the WaitCallBack delegate.
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine("Thread ID: " + thread.ManagedThreadId + ", from ThreadPool: " + thread.IsThreadPoolThread);
            Thread.Sleep(1000); // Simulate work.
        }
    }
}
