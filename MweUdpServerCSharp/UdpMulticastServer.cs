using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MweUdpServerCSharp
{
    public sealed class UdpMulticastServer : IDisposable
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _remoteEndpoint;

        public UdpMulticastServer(IPAddress multicastAddress, int port, IPAddress localAddress = null)
        {
            _udpClient = new UdpClient();

            _udpClient.ExclusiveAddressUse = false;
            _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _udpClient.ExclusiveAddressUse = false;

            if (localAddress != null)
            {
                _udpClient.Client.Bind(new IPEndPoint(localAddress, port));
            }

            //_udpClient.JoinMulticastGroup(multicastAddress);
            _remoteEndpoint = new IPEndPoint(multicastAddress, port);
        }

        public void Send(string request)
        {
            Send(Encoding.ASCII.GetBytes(request));
        }

        public void Send(byte[] request)
        {
            _udpClient.Send(request, request.Length, _remoteEndpoint);
        }

        public void Dispose()
        {
            _udpClient.Close();
        }
    }
}