using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPServer
{
    public class Server
    {
        private UdpClient client;
        private IPEndPoint remoteEP;

        /// <summary>
        /// Creates a Server instance with an arbitrary local port,
        /// set up to broadcast to the specified target port.
        /// </summary>
        /// <param name="targetPort">The port to which messages should be broadcast.</param>
        public Server(int targetPort)
        {
            client = new UdpClient();
            remoteEP = new IPEndPoint(IPAddress.Broadcast, targetPort);
        }

        public void Start()
        {
            try
            {
                client.Connect(remoteEP); // Establish remoteEP as the target host.
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAttempt to establish remote endpoint resulted in the following exception:\n");
                Console.WriteLine(e.ToString() + "\n");
            }

            int messageNumber = 1;

            while (true)
            {
                try
                {
                    string data = $"This is message number {messageNumber} from server.";

                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    client.Send(dataBytes, dataBytes.Length);

                    Console.WriteLine("SENT: " + data);
                    Console.WriteLine($"TO ADDRESS: {remoteEP.Address}, PORT: {remoteEP.Port}\n");

                    messageNumber++;
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nAttempt to communicate with client resulted in the following exception:\n");
                    Console.WriteLine(e.ToString() + "\n");
                }
            }
        }
    }
}
