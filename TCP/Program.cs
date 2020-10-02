using System;
using System.Threading.Tasks;
using System.Threading;

namespace TCP
{
    class Program
    {
        private static Thread threadConsole;
        private static General general = new General();

        static void Main(string[] args)
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();
            general.InitializeServer();
        }

        static void ConsoleThread()
        {
            string line;
            string[] parts;

            while (true)
            {

            }
        }

    }
}
