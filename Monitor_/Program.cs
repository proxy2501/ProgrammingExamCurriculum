using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monitor_
{
    class Program
    {
        private static int sharedResource;
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
            while (true)
            {
                Monitor.Enter(lockObj) ; // Start of critical code region.

                try
                {
                    if (sharedResource == 0)
                    {
                        sharedResource++;

                        if (sharedResource != 1)
                        {
                            throw new Exception("Race condition in " + Thread.CurrentThread.Name);
                        }
                    }

                    sharedResource = 0;
                }
                finally
                {
                    Monitor.Exit(lockObj); // End of critical code region.
                }

            }
        }
    }
}
