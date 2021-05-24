using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
{
    public class Server
    {
        private TcpListener listener;

        public Server(int serverPort)
        {
            listener = new TcpListener(IPAddress.Any, serverPort);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Server started.\n");

            while (true)
            {
                Console.WriteLine("Listening for connections...\n");

                TcpClient newClient = listener.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.IsBackground = true;
                t.Start(newClient);

                Console.WriteLine("Client connected!\n");
            }

        }

        private void HandleClient(object clientObject)
        {
            TcpClient client = (TcpClient)clientObject;
            NetworkStream stream = client.GetStream();

            while (client.Connected)
            {
                try
                {
                    // Read.
                    string message = ReadString(stream);
                    Console.WriteLine("RECEIVED: " + message);

                    // Write.
                    WriteString(stream, "Message received.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nClient thread " + Thread.CurrentThread.ManagedThreadId + " threw the following exception:\n");
                    Console.WriteLine(e.ToString() + "\n");
                }
            }

            Console.WriteLine("\nLost connection to client. Aborting client thread " + Thread.CurrentThread.ManagedThreadId + "\n");
            Thread.CurrentThread.Abort();
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
