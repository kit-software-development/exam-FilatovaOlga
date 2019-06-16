using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Chat.Messaging
{
    public static class MessageFactory
    {
        private static BinaryFormatter Formatter { get; }
        
        static MessageFactory()
        {
            Formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Преобразует объект в поток байтов
        /// </summary>
        /// <param name="obj"> объект </param>
        /// <returns> Массив двоичных данных </returns>
        public static byte[] Serialize(this object obj)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Formatter.Serialize(memory, obj);
                memory.Flush();
                return memory.ToArray();
            }
        }

        /// <summary>
        /// Преобразует поток байтов в объект 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="data"> Массив двоичных данных </param>
        /// <returns> Объект </returns>
        public static E Deserialize<E>(byte[] data)
        {
            using (MemoryStream memory = new MemoryStream(data))
            {
                return (E)Formatter.Deserialize(memory);
            }
        }
    }
}