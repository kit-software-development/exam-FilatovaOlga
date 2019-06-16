using System;

namespace TestsApp.Lib.Messaging
{
    /// <summary>
    /// Класс объекта "Вопрос"
    /// </summary>
    [Serializable]
    public class Question
    {
        public string Text { get; }

        public string Answer { get; }

        public string Var1 { get; }
        public string Var2 { get; }
        public string Var3 { get; }
        public string Var4 { get; }

        /// <summary>
        /// Конструктор объекта "Вопрос"
        /// </summary>
        /// <param name="text"> Текст вопроса </param>
        /// <param name="answer"> Правильный вариант ответа </param>
        /// <param name="var1"> Текст первого варианта ответа на вопрос </param>
        /// <param name="var2"> Текст второго варианта ответа на вопрос </param>
        /// <param name="var3"> Текст третьего варианта ответа на вопрос </param>
        /// <param name="var4"> Текст четвертого варианта ответа на вопрос </param>
        public Question(string text, string answer, string var1, string var2, string var3, string var4)
        {
            Text = text;
            Answer = answer;
            Var1 = var1;
            Var2 = var2;
            Var3 = var3;
            Var4 = var4;
        }
    }
}