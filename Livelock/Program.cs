using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Livelock
{
    class Program
    {
        private static object fork = new object();

        private static Thread descartes = new Thread(DescartesEat) { Name = "Descartes", IsBackground = true };
        private static Thread socrates = new Thread(SocratesEat) { Name = "Socrates", IsBackground = true };

        private static bool descartesHungry = true;
        private static bool socratesHungry = true;

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
                lock (fork)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ": I picked up the fork.");
                    Thread.Sleep(2000);

                    if (!socratesHungry)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": Spaghetti time!!");
                        Console.WriteLine(Thread.CurrentThread.Name + ": I am no longer hungry!");
                        descartesHungry = false;
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": I won't eat while Socrates is still hungry.");
                        Thread.Sleep(2000);
                    }
                }

                Console.WriteLine(Thread.CurrentThread.Name + ": I put down the fork.");
                Thread.Sleep(2000);
            }
        }

        private static void SocratesEat()
        {
            while (true)
            {
                lock (fork)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ": I picked up the fork.");
                    Thread.Sleep(2000);

                    if (!descartesHungry)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": Spaghetti time!!");
                        Console.WriteLine(Thread.CurrentThread.Name + ": I am no longer hungry!");
                        socratesHungry = false;
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": I won't eat while Descartes is still hungry.");
                        Thread.Sleep(2000);
                    }
                }

                Console.WriteLine(Thread.CurrentThread.Name + ": I put down the fork.");
                Thread.Sleep(2000);
            }
        }
    }
}
