using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SerialPort comPort = new SerialPort();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
     
            EntryForm EntryForm = new EntryForm(comPort);
            EntryForm.Show();

            Application.Run();
        }
    }
}
