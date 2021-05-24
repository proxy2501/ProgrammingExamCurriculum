using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        private static Invoker invoker = new Invoker();
        private static Receiver carl = new Receiver("Carl");
        private static Receiver brian = new Receiver("Brian") { IsMute = true };

        static void Main(string[] args)
        {
            invoker.ExecuteCommands(carl);
            invoker.ExecuteCommands(brian);

            Console.ReadKey(); // Wait.
        }
    }
}
