using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TCP
{
    class Clients
    {
        public int connectionID;
        public string ip;
        public TcpClient socket;
        public NetworkStream myStream;
        private byte[] readBuff;

        public void Start()
        {
            socket.SendBufferSize = 4096;
            socket.ReceiveBufferSize = 4096;
            myStream = socket.GetStream();
            readBuff = new byte[4096];
            myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);
        }

        private void OnReceiveData(IAsyncResult result)
        {
            try
            {
                int readbytes = myStream.EndRead(result);
                if(readbytes<=0)
                {
                    CloseSocket();
                    return;
                }
                byte[] newBytes = new byte[readbytes];
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readbytes);

                myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);

            }
            catch(Exception)
            {
                CloseSocket();
            }
        }
        public void CloseSocket()
        {
            Console.WriteLine("Connection from {0} has been terninated", ip);
            socket.Close();
            socket = null;
        }
    }
}
