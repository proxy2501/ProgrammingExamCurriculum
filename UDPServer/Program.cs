using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPServer
{
    class Program
    {
        static int targetPort = 15000;

        static void Main(string[] args)
        {
            Console.Title = "UDP Server";

            Server server = new Server(targetPort);
            server.Start();
        }
    }
}
