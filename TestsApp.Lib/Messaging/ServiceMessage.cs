using System;

namespace TestsApp.Lib.Messaging
{
    /// <summary>
    /// Перечисление команд, которые клиентское приложение может отправлять на сервер
    /// </summary>
    public enum Command
    {
        /// <summary>
        /// Получить следующий вопрос
        /// </summary>
        NextQuestion,
        /// <summary>
        /// Добавить вопрос в базу
        /// </summary>
        AddQuestion,
        /// <summary>
        /// Получить текущее количество вопросов, хранящихся в базе
        /// </summary>
        CountQuestions
    }

    /// <summary>
    /// Сообщение от клиента к серверу
    /// </summary>
    [Serializable]
    public class ServiceMessage
    {
        /// <summary>
        /// Команда от клиента к серверу
        /// </summary>
        public Command Command { get; }
        /// <summary>
        /// Экземляр вопроса, который необходимо добавить в базу
        /// </summary>
        public Question Question { get; }
        /// <summary>
        /// Порядковый номер вопроса в базе
        /// </summary>
        public int Num;

        /// <summary>
        /// Конструктор сообщения серверу для получения следующего вопроса
        /// </summary>
        /// <param name="command"> Команда NextQuestion </param>
        /// <param name="num"> Порядковый номер вопроса в базе</param>
        public ServiceMessage(Command command, int num)
        {
            Command = command;
            Num = num;
        }

        /// <summary>
        /// Конструктор сообщения серверу для добавления вопроса в базу
        /// </summary>
        /// <param name="question"> Вопрос </param>
        /// <param name="command"> Команда AddQuestion </param>
        public ServiceMessage(Question question, Command command)
        {
            Command = command;
            Question = question;
        }

        /// <summary>
        /// Конструктор сообщения серверу для получения количества вопросов, хранящихся в базе
        /// </summary>
        /// <param name="command"> Команда CountQuestions </param>
        public ServiceMessage(Command command)
        {
            Command = command;
        }
    }
}