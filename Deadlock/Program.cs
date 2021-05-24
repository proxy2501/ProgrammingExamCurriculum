using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Deadlock
{
    class Program
    {
        private static object forkA = new object();
        private static object forkB = new object();

        private static Thread descartes = new Thread(DescartesEat) { Name = "Descartes", IsBackground = true };
        private static Thread socrates = new Thread(SocratesEat) { Name = "Socrates", IsBackground = true };

    static void Main(string[] args)
        {
            descartes.Start();
            socrates.Start();

            Console.ReadKey();
        }

        private static void DescartesEat()
        {
            while (true)
            {
                lock (forkA)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ": \"I took fork A.\"");

                    lock (forkB)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": \"I took fork B.\"");
                        Console.WriteLine(Thread.CurrentThread.Name + ": \"Spaghetti time!!\"");
                        Thread.Sleep(3000);
                    }

                    Console.WriteLine(Thread.CurrentThread.Name + ": \"I released fork B.\"");
                }

                Console.WriteLine(Thread.CurrentThread.Name + ": \"I released fork A.\"");
            }
        }

        private static void SocratesEat()
        {
            while (true)
            {
                lock (forkB)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ": \"I took fork B.\"");

                    lock (forkA)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": \"I took fork A.\"");
                        Console.WriteLine(Thread.CurrentThread.Name + ": \"Spaghetti time!!\"");
                        Thread.Sleep(3000);
                    }

                    Console.WriteLine(Thread.CurrentThread.Name + ": \"I released fork A.\"");
                }

                Console.WriteLine(Thread.CurrentThread.Name + ": \"I released fork B.\"");
            }
        }
    }
}
