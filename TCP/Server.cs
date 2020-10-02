using System;
using System.Net;
using System.Net.Sockets;

namespace TCP
{
    class Server
    {
        public const int maxConnection = 1000;
        private TcpListener serverSocket;
        public Clients[] clients = new Clients[maxConnection];
        public void InitializeNetwork()
        {
            serverSocket = new TcpListener(IPAddress.Any, 5555);

            serverSocket.Start();

            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }
      
        private void OnClientConnect(IAsyncResult result)
        {
            TcpClient client = serverSocket.EndAcceptTcpClient(result);
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
            for (int i = 0; i<maxConnection ;i++)
            {
                if(clients[i].socket == null)
                {
                    clients[i].socket = client;
                    clients[i].connectionID = i;
                    clients[i].ip = client.Client.RemoteEndPoint.ToString();
                    clients[i].Start();
                    Console.WriteLine("Connection received form {0}", clients[i].ip);
                }
            }

        }
    }
}
