using System;

namespace UDPClient
{
    class Program
    {
        static int clientPort = 15000;

        static void Main(string[] args)
        {
            Console.Title = "UDP Client";

            //Client client = new Client(clientPort, serverPort, serverAddress);
            Client client = new Client(clientPort);
            client.Start();
        }
    }
}
