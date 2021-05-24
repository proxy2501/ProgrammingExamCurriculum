using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClient
{
    public class Client
    {
        private UdpClient client;
        private IPEndPoint remoteEP;

        public Client(int clientPort)
        {
            client = new UdpClient(clientPort);
            remoteEP = new IPEndPoint(IPAddress.Any, 0); // Set up to accept from any endpoint.
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    byte[] dataBytes = client.Receive(ref remoteEP);

                    string data = Encoding.UTF8.GetString(dataBytes);

                    Console.WriteLine($"RECEIVED: {data}");
                    Console.WriteLine($"FROM ADDRESS: {remoteEP.Address}, PORT: {remoteEP.Port}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nAttempt to communicate with server resulted in the following exception:\n");
                    Console.WriteLine(e.ToString() + "\n");
                }
            }
        }
    }
}
