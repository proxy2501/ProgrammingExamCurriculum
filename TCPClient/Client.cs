using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPClient
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;

        public Client()
        {
            IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Any, 0); // Any address, any port for local socket.
            client = new TcpClient(localEndpoint); // Bind client to socket.
        }

        public void Connect(string serverAddress, int serverPort)
        {
            while (!client.Connected)
            {
                try
                {
                    client.Connect(serverAddress, serverPort);
                    stream = client.GetStream();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Connection attempt failed with the following exception:\n");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("\nRetrying connection in 5 seconds...\n");

                    Thread.Sleep(5000);
                }
            }

            Console.Clear();
            Console.WriteLine("Connected with server!\n");
            int i = 1;

            while (client.Connected)
            {
                try
                {
                    // Write.
                    WriteString(stream, "Message number " + i);
                    i++;

                    // Read.
                    Console.WriteLine("RECEIVED: " + ReadString(stream));

                    // Sleep.
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nAttempt to communicate with server resulted in the following exception:\n");
                    Console.WriteLine(e.ToString() + "\n");
                }
            }

            Console.WriteLine("\nLost connection to server.\n");
        }

        private void WriteInt(NetworkStream stream, int data)
        {
            byte[] dataBytes = BitConverter.GetBytes(data);
            stream.Write(dataBytes, 0, dataBytes.Length);
        }

        private int ReadInt(NetworkStream stream)
        {
            byte[] dataBytes = new byte[4];
            stream.Read(dataBytes, 0, dataBytes.Length);

            return BitConverter.ToInt32(dataBytes, 0);
        }

        private void WriteString(NetworkStream stream, string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] lengthBytes = BitConverter.GetBytes(dataBytes.Length);

            stream.Write(lengthBytes, 0, lengthBytes.Length);
            stream.Write(dataBytes, 0, dataBytes.Length);
        }

        private string ReadString(NetworkStream stream)
        {
            byte[] lengthBytes = new byte[4];
            stream.Read(lengthBytes, 0, lengthBytes.Length);
            int length = BitConverter.ToInt32(lengthBytes, 0);

            byte[] dataBytes = new byte[length];
            stream.Read(dataBytes, 0, length);

            return Encoding.UTF8.GetString(dataBytes);
        }
    }
}
