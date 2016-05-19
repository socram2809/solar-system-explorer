/* 
        Abbas Majeed (i110273)
       
        Fast-Nu Isb Campus
 
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaSolar
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
            Application.Run(new MainForm());
        }
    }
}
