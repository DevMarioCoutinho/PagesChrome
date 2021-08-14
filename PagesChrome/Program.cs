using System;
using System.Windows.Forms;

namespace PagesChrome
{
    static class Program
    {
        #region Inicio do Programa
        [STAThread]
        static void Main()
        {
            Application.Run(new OptionsForm());
        }
        #endregion
    }
}
