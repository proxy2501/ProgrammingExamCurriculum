using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Semaphore_
{
    class Program
    {
        private static Random rnd = new Random();

        private static int totalThreads = 25;
        private static int waitingThreads = 0;
        private static int workingThreads = 0;
        private static int doneThreads = 0;

        private static Semaphore semaphore = new Semaphore(5, 5);

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < totalThreads; i++)
            {
                new Thread(ThreadWork) { IsBackground = true }.Start();
            }

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Waiting threads: " + waitingThreads + " "); // Extra space to cover the last digit .
                Console.WriteLine("Working threads: " + workingThreads);
                Console.WriteLine("Done threads: " + doneThreads + "/25");
            }
        }

        private static void ThreadWork()
        {
            waitingThreads++;
            semaphore.WaitOne();
            waitingThreads--;

            workingThreads++;
            Thread.Sleep(rnd.Next(1000, 4000));
            workingThreads--;

            semaphore.Release();
            doneThreads++;
        }
    }
}
