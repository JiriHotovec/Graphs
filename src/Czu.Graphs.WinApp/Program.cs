using Czu.Graphs.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Czu.Graphs.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new FormMain());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            switch (e.Exception.GetType().Name)
            {
                case nameof(ModelException):
                    MessageBox.Show(e.Exception.Message, "Validation message");
                    break;
                default:
                    MessageBox.Show(e.Exception.Message, "Error");
                    break;
            }
        }
    }
}