using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsApp.Client
{
    public partial class StartForm : Form
    {
        //требуется указать ip-адрес компьютера, на котором запущен сервер
        public string ipAddressString = "192.168.0.104";
        //private string ipAddressString = "127.0.0.1";

        public StartForm()
        {
            InitializeComponent();
        }

        //Обработка события нажатия на кнопку "Начать тест"
        //Вызываем форму для прохождения теста
        private void OnStartTest(object sender, EventArgs e)
        {
            QuestionForm QuestionForm = new QuestionForm(ipAddressString);
            QuestionForm.ShowDialog();
        }

        //Обработка события нажатия на кнопку "Добавить новый вопрос в базу"
        //Вызываем форму для добавления нового вопроса
        private void OnAddQuestion(object sender, EventArgs e)
        {
            AddQuestionForm AddQuestionForm = new AddQuestionForm(ipAddressString);
            AddQuestionForm.ShowDialog();
        }
    }
}
