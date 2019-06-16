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
    /// Форма для отправки нового вопроса в базу данных
    /// </summary>
    public partial class AddQuestionForm : Form
    {
        private INetworkWriter<ServiceMessage> _server;

        /// <summary>
        /// Конструктор формы для отправки нового вопроса в базу данных
        /// </summary>
        /// <param name="ipAddressString"> ip-адрес сервера </param>
        public AddQuestionForm(string ipAddressString)
        {
            _server = NetworkingFactory.UdpWriter<ServiceMessage>(IPAddress.Parse(ipAddressString), 8080);

            InitializeComponent();

            VarComboBox.Items.AddRange(new string[] { "1", "2"});

        }

        //Обработка нажатия на кнопку "Добавить вопрос в базу"
        private void OnAddButton(object sender, EventArgs e)
        {
            string caption = "Info";
            var message = "";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            
            //Проверяем, что введенных данных достаточно для добавления вопроса в базу
            if (QTextBox.Text == null ||
            TextVar1.Text == null ||
            TextVar2.Text == null ||
            VarComboBox.SelectedItem == null ||
            (TextVar3.Text == null && TextVar4.Text != null))
            {
                message = "Вопрос не может быть добавлен. Недостаточно данных.";
            }
            else if ((VarComboBox.SelectedItem.ToString() == "3" && TextVar3.Text == null) ||
                (VarComboBox.SelectedItem.ToString() == "4" && TextVar4.Text == null))
            {
                message = "Вопрос не может быть добавлен. Вариант, выбранный в качестве правильного, пуст.";
            }

            if (message != "")
            {
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                //Создаем объет "Вопрос" и инициализируем его введенными в поля формы данными
                var question = new Question(QTextBox.Text,
                                            Convert.ToString(VarComboBox.SelectedItem),
                                            TextVar1.Text, TextVar2.Text, TextVar3.Text, TextVar4.Text);
                //Отправляем сообщение на сервер
                ServiceMessage msg = new ServiceMessage(question, Command.AddQuestion);
                _server.Write(msg);

                message = "Вопрос успешно добавлен в базу.";
                MessageBox.Show(message, caption, buttons);

                //Закрываем форму
                this.Close();
            }
        }
        
        private void OnChangeVar2(object sender, EventArgs e)
        {
            TextVar3.Enabled = true;
        }

        private void OnChangeVar3(object sender, EventArgs e)
        {
            TextVar4.Enabled = true;
            VarComboBox.Items.Clear();
            VarComboBox.Items.AddRange(new string[] { "1", "2", "3"});
        }

        private void OnChangeVar4(object sender, EventArgs e)
        {
            VarComboBox.Items.Clear();
            VarComboBox.Items.AddRange(new string[] { "1", "2", "3", "4" });
        }
    }
}
