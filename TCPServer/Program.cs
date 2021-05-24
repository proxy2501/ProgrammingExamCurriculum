using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        static int serverPort = 15000;

        static void Main(string[] args)
        {
            Console.Title = "TCP Server";

            Server server = new Server(serverPort);
            server.Start();

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
