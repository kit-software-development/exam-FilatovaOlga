using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsApp.Lib.Messaging;
using TestsApp.Lib.Networking;
using TestsApp.Lib.Threading;

namespace TestsApp.Client
{
    /// <summary>
    /// Форма для прождения теста
    /// </summary>
    public partial class QuestionForm : Form
    {
        /// <summary>
        /// Порядковый номер текущего вопроса теста
        /// </summary>
        private int NumQuestion = 0;

        /// <summary>
        /// Общее количество вопросов, хранящихся в базе данных
        /// </summary>
        private int maxQuestionNumber = 0;

        /// <summary>
        /// Количество правильных ответов
        /// </summary>
        private int rightAnswer = 0;

        /// <summary>
        /// Номер правильного ответа
        /// </summary>
        private string _answer = "";

        static Random rnd = new Random();

        /// <summary>
        /// Массив для хранения последовательности появления вопросов в тесте
        /// </summary>
        int[] perm;

        
        private readonly UdpMessageListener<Question> _listener;
        private INetworkWriter<ServiceMessage> _server;

        /// <summary>
        /// Конструктор формы для прождения теста
        /// </summary>
        /// <param name="ipAddressString"> ip-адрес сервера </param>
        public QuestionForm(string ipAddressString)
        {
            _listener = new UdpMessageListener<Question>(9090);
            _listener.IncomingMessage += OnIncomingQuestion;
            _listener.Start();
            _server = NetworkingFactory.UdpWriter<ServiceMessage>(IPAddress.Parse(ipAddressString), 8080);

            InitializeComponent();

            //Отправляем на сервер запрос о количестве вопросов в базе данных
            ServiceMessage msg = new ServiceMessage(Command.CountQuestions);
            _server.Write(msg);
            
            bool flag = false;
            
            //Пытаемся получить ответ на запрос от сервера
            try
            {
                var reader = NetworkingFactory.UdpReader<Question>(9091);
                var Message = reader.Read(15000);
                var Sender = reader.Sender;

                int.TryParse(Message.Text, out maxQuestionNumber);
                flag = true;
                reader.Dispose();
            }
            catch (Exception e)
            {
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(e.Message, "Error Detected in Input", buttons);
            }

            //Если ответ от сервера не получен, показываем соответствующее сообщение для пользователя
            string caption = "Info";
            var message = "";
            if (!flag)
            {
                message = "Сервер не отвечает.";
            }
            else if (maxQuestionNumber == 0)
            {
                message = "В базе нет ни одного вопроса.";
            }

            if (message != "")
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            
            CountLabel.Text = "В базе " + maxQuestionNumber + " вопросов.";

            //Генерируем случайную последовательность вопросов
            perm = Enumerable.Range(1, maxQuestionNumber).ToArray();
            Random r = rnd; 
            for (int i = maxQuestionNumber-1; i >= 1; i--)
            {
                int j = r.Next(i + 1);

                int temp = perm[j];
                perm[j] = perm[i];
                perm[i] = temp;
            }

            //Отправляем на сервер запрос первого вопроса теста
            msg = new ServiceMessage(Command.NextQuestion, perm[NumQuestion]);
            _server.Write(msg);
        }
        
        //Обработка события нажатия на кнопку "Проверить"
        private void CheckQuestionButton_Click(object sender, EventArgs e)
        {
            string caption = "Info";
            bool right = false;
            
            //Проверяем соответствует ли выбранный ответ правильному
            switch(_answer)
            {
                case "1":
                    {
                        right = radioButton1.Checked;
                        break;
                    }
                case "2":
                    {
                        right = radioButton2.Checked;
                        break;
                    }
                case "3":
                    {
                        right = radioButton3.Checked;
                        break;
                    }
                case "4":
                    {
                        right = radioButton4.Checked;
                        break;
                    }
            }

            var message = right? "Ответ правильный" : "Ответ неверен";
            if (right) { rightAnswer++; }

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);

            //Если текущий вопрос не последний, то отправляем на сервер запрос следующего вопроса
            if (NumQuestion != maxQuestionNumber)
            {
                ServiceMessage msg = new ServiceMessage(Command.NextQuestion, perm[NumQuestion]);
                _server.Write(msg);
            }
            //Иначе завершаем тестирование и выводим результат для пользователя
            else
            {
                message = "Тест завершен. Правильных ответов " + rightAnswer;
                message += " из " + maxQuestionNumber + ".";
                MessageBox.Show(message, caption, buttons);
                _listener.Dispose();
                Close();
            }
        }

        //Обработка получения сообщения (вопроса) от сервера
        private void OnIncomingQuestion(object sender, IncommingMessageEventArgs<Question> e)
        {
            if (e.Message.Answer == null)
            {
                maxQuestionNumber = Convert.ToInt32(e.Message.Text);
            }
            SetQuestion(e);
        }

        /// <summary>
        /// Устанавливает параметры вопроса, пришедшего от сервера, в соответствующие поля формы
        /// </summary>
        /// <param name="e"> Сообщение типа "Вопрос" </param>
        private void SetQuestion(IncommingMessageEventArgs<Question> e)
        {
            if (this.QuestionTitleLabel.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate () {
                    SetQuestion(e);
                }));
            }
            else
            {
                NumQuestion++;
                NumLabel.Text = "Вопрос " + NumQuestion;

                QuestionTitleLabel.Text = e.Message.Text;
                _answer = e.Message.Answer;
                
                radioButton1.Text = e.Message.Var1;
                radioButton1.Checked = false;
                radioButton2.Text = e.Message.Var2;
                radioButton2.Checked = false;

                if (e.Message.Var3 == null || e.Message.Var3 == "")
                {
                    radioButton3.Visible = false;
                }
                else
                {
                    radioButton3.Visible = true;
                    radioButton3.Text = e.Message.Var3;
                    radioButton3.Checked = false;
                }

                if (e.Message.Var4 == null || e.Message.Var4 == "")
                {
                    radioButton4.Visible = false;
                }
                else
                {
                    radioButton4.Visible = true;
                    radioButton4.Text = e.Message.Var4;
                    radioButton4.Checked = false;
                }
            }
        }

        //Обработка закрытия формы
        private void OnClosingQuestionForm(object sender, FormClosingEventArgs e)
        {
            _listener.Dispose();
        }
    }
}
