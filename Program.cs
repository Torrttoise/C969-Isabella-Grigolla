using C969_Isabella_Grigolla.Database_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Isabella_Grigolla
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ConnectionDatabase.startConnection();
            Application.Run(new Form1());
            ConnectionDatabase.closeConnection();
        }
    }
}
