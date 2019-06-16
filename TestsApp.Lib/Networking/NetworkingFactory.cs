using System.Net;
using System.Net.Sockets;
using Chat.Networking;

namespace TestsApp.Lib.Networking
{
    public static class NetworkingFactory
    {
        public static INetworkReader<TE> UdpReader<TE>(int port)
        {
            UdpClient client = new UdpClient(port);
            return new UdpReader<TE>(client);
        }

        public static INetworkWriter<TE> UdpWriter<TE>(IPAddress address, int port)
        {
            UdpClient client = new UdpClient();
            client.Connect(address, port);
            return new UDPWriter<TE>(client);
        }
    }
}