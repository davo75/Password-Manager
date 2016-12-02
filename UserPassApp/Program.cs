using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserPassMgrApp
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
            //create a new login form
            LoginForm fLogin = new LoginForm();
            //if login is successful then show the main form
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }           
        }
    }
}
