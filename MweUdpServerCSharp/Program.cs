using System.Net;
using System.Threading;

namespace MweUdpServerCSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new UdpMulticastServer(IPAddress.Parse("235.1.1.1"), 8480);
            var i = 1;
            while (true)
            {
                server.Send("Test " + i);
                i++;
                Thread.Sleep(500);
            }
        }
    }
}