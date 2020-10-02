using System;
using System.Net.Sockets;

namespace Client
{
    class ClientTcp
    {
        public TcpClient clientScocket;
        private byte[] asyncBuffer;

        public void ConnectToServer()
        {
            clientScocket = new TcpClient();
            clientScocket.ReceiveBufferSize = 4096;
            clientScocket.SendBufferSize = 4096;
            asyncBuffer = new byte[8192];
            clientScocket.BeginConnect("127.0.0.1", 5555, new AsyncCallback(ConnectCallBack), clientScocket);
        }

        private void ConnectCallBack(IAsyncResult result)
        {
            try
            {
                clientScocket.EndConnect(result);
                if(clientScocket.Connected==false)
                {
                    Console.WriteLine("Server does not allow our connection.");
                    return;
                }
                else
                {
                    Console.WriteLine("Succesfully connected to the server!");
                }

            }
            catch(Exception)
            {
                Console.WriteLine("Cannot connect to the server!"); ;
            }
          
        }
    }
}
