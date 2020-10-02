using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class General
    {
        public Server server = new Server();
        public int GetTickCount()
        {
            return Environment.TickCount;
        }
        public void InitializeServer()
        {
            int startTime = 0;
            int endTime = 0;

            startTime = GetTickCount();

            Console.WriteLine("Initializing Server ....");

            for(int i = 0; i< Server.maxConnection;i++)
            {
                server.clients[i] = new Clients();
            }

            Console.WriteLine("Initializing Network ...");

            server.InitializeNetwork();

            endTime = GetTickCount();

            Console.WriteLine("Initialization complete. Server loaded in {0} ms.", (endTime - startTime));
        }

    }
}
