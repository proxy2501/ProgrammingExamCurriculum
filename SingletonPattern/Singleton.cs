using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton
    {
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                return instance == null ? instance = new Singleton() : instance;
            }
        }

        private Singleton()
        {
            Console.WriteLine("Singleton's constructor was called.");
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton was asked to do something.");
        }
    }
}
