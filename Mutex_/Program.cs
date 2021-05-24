using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mutex_
{
    class Program
    {
        private static int sharedResource;
        private static Mutex unnamedMutex = new Mutex(); // Unnamed mutex, exists on application level.
        private static Mutex namedMutex = new Mutex(false, "ApplicationMutex"); // Named mutex, exists on OS level.

        private static Thread threadA = new Thread(ThreadWork) { Name = "Thread A", IsBackground = true };
        private static Thread threadB = new Thread(ThreadWork) { Name = "Thread B", IsBackground = true };

        static void Main(string[] args)
        {
            if (namedMutex.WaitOne(1)) // Prevents other instances of this program from running.
            {
                try
                {
                    threadA.Start();
                    threadB.Start();

                    Console.ReadKey();
                }
                finally
                {
                    namedMutex.ReleaseMutex(); // Release mutex on program completion.
                }
            }
            else
            {
                Console.WriteLine("Another instance of this program is already running. Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void ThreadWork()
        {
            while (true)
            {
                unnamedMutex.WaitOne(); // Start of critical code region.

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
                    unnamedMutex.ReleaseMutex(); ; // End of critical code region.
                }

            }
        }
    }
}
