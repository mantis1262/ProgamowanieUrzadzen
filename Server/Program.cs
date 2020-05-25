using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer webSocketServer = new WebSocketServer();
            webSocketServer.Start("http://localhost:80/sklep/");
            Console.ReadKey();
        }
    }
}
