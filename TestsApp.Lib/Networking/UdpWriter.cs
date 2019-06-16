using System;
using System.Net.Sockets;
using Chat.Messaging;
using TestsApp.Lib.Networking;

namespace Chat.Networking
{
    /// <summary>
    /// Класс для отправки сообщения
    /// </summary>
    /// <typeparam name="E"> Тип отправляемого сообщения </typeparam>
    class UDPWriter<E> : INetworkWriter<E>
    {
        private UdpClient socket;
        public UDPWriter(UdpClient client)
        {
            socket = client;
        }
        
        /// <summary>
        /// Закрывает UDP-подключение
        /// </summary>
        public void Dispose() => socket.Close();
        
        /// <summary>
        /// Преобразует сообщение в поток байтов и отправляет его
        /// </summary>
        /// <param name="message"> Сообщение сервера </param>
        public void Write(E message)
        {
            byte[] data = message.Serialize();
            socket.Send(data, data.Length);
        }
    }
}