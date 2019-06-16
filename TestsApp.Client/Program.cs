using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsApp.Client
{
    static class Program
    {
        static public StartForm StartForm;

        /// <summary>
        /// Вызов стартовой формы клиентского приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartForm = new StartForm();
            Application.Run(StartForm);
        }
    }
}
