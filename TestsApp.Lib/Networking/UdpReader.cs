using System.Net;
using System.Net.Sockets;
using Chat.Messaging;

namespace TestsApp.Lib.Networking
{
    /// <summary>
    /// Класс для получения сообщения
    /// </summary>
    /// <typeparam name="E"> Тип получаемого сообщения </typeparam>
    class UdpReader<E> : INetworkReader<E>
    {
        private IPEndPoint _sender;

        private readonly UdpClient _socket;
        public IPEndPoint Sender => _sender;

        public UdpReader(UdpClient client)
        {
            _socket = client;
        }

        /// <summary>
        /// Закрывает UDP-подключение
        /// </summary>
        public void Dispose()
        {
            _socket.Close();
        }

        /// <summary>
        /// Получает сообщение в виде потока байтов и преобразует его в объект
        /// </summary>
        /// <param name="timeousMS"> Промежуток времени, после которого истечет время ожидания сообщения </param>
        /// <returns> Объект заданного типа </returns>
        public E Read(int timeousMS = -1)
        {
            _socket.Client.ReceiveTimeout = timeousMS;
            byte[] data = _socket.Receive(ref _sender);
            return MessageFactory.Deserialize<E>(data);
        }
    }
}