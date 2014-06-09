using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class EntryForm : Form
    {
        #region VARIABLES #####################################################
        
        private SerialPort comPort;
        private static Utility Utility = new Utility();
        private static Process cmd_pModem = new Process();
        
        private static string pModemCommand = "adb root && timeout 2 && adb remount && adb shell setprop persist.usb.eng 1 && adb shell setprop sys.usb.config mtp,adb && timeout 3";

        /* for future use
        private static string pModemError = "adbd cannot run as root in production builds";
        private static string pModemCheck = "adb shell getprop persist.usb.eng";

        private string pModemOutput; 
        */
                 
        #endregion ############################################################

        #region INITIALIZATION ################################################
        public EntryForm(SerialPort comPort)
        {
            InitializeComponent();
            this.comPort = comPort;
        }
        #endregion ############################################################

        #region BUTTONS #######################################################
        // REFRESH ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cBoxComPorts.Items.Clear();
            AT_SerialPort.AT_populateComPorts(cBoxComPorts, comPort);
        }
        
        // TURN MODEM ON ======================================================
        private void btnModem_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls) Utility.DisableControl(control);

            cmd_pModem.StartInfo.RedirectStandardOutput = true;
            cmd_pModem.StartInfo.UseShellExecute = false;
            cmd_pModem.StartInfo.CreateNoWindow = true;

            cmd_pModem.EnableRaisingEvents = false;

            cmd_pModem = Process.Start("cmd", "/c" + pModemCommand);
            
            cmd_pModem.WaitForExit();
            
            if (cmd_pModem.ExitCode.ToString() == "0")
            {
                MessageBox.Show("Modem mounted successfully");
                foreach (Control control in this.Controls) Utility.EnableControl(control);
                Utility.DisableControl(btnModem);
            }
            else
            {
                MessageBox.Show("Fail to mount modem. Error Code: " + cmd_pModem.ExitCode.ToString());
                foreach (Control control in this.Controls) Utility.EnableControl(control);
            }
            cmd_pModem.Close();
        }
       
        // CONNECT ============================================================
        private void btnConnect_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.Show();
            this.Close();
        }

        // EXIT ===============================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion ############################################################

        #region METHODS #######################################################
        //
        #endregion ############################################################

        #region EVENTS ########################################################
        //
        #endregion ############################################################
    }

}
