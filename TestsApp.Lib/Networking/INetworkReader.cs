using System;
using System.Net;

namespace TestsApp.Lib.Networking
{
    public interface INetworkReader<E> : IDisposable
    {
        IPEndPoint Sender { get; }

        E Read(int timeousMS = -1);
    }
}