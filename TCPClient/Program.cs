using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {
        static string serverAddress = "127.0.0.1";
        static int serverPort = 15000;

        static void Main(string[] args)
        {
            Console.Title = "TCP Client";

            Client client = new Client();
            client.Connect(serverAddress, serverPort);

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
