using System;

namespace TestsApp.Lib.Networking
{
    public interface INetworkWriter<E> : IDisposable
    {
        void Write(E message);
    }
}