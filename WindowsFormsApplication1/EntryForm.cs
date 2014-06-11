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
        #region INSTANCES #####################################################

        private SerialPort comPort;
        private static Process cmd_pModem = new Process();


        #endregion ############################################################

        #region VARIABLES #####################################################

        private static string pModemCommand = "adb root && timeout 2 && adb remount && adb shell setprop persist.usb.eng 1 && adb shell setprop sys.usb.config mtp,adb && timeout 3";

        // private static string pModemError = "adbd cannot run as root in production builds";
        // private static string pModemCheck = "adb shell getprop persist.usb.eng";
        
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
            Refresh(this);
        }
        
        // TURN MODEM ON ======================================================
        private void btnModem_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls) Utility.DisableControl(control);

            cmd_pModem.StartInfo.RedirectStandardOutput = true;
            cmd_pModem.StartInfo.UseShellExecute = false;
            cmd_pModem.StartInfo.CreateNoWindow = true;

            cmd_pModem.EnableRaisingEvents = false;

            try
            {
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
            catch (Exception error)
            {
                MessageBox.Show("Exception :" + error.Message);
            }
        }
       
        // CONNECT ============================================================
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //AT_SerialPort.Connect();
            MainForm MainForm = new MainForm(comPort);
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
        // REFRESH ============================================================
        private static void Refresh(EntryForm Form)
        {
            Form.cBoxComPorts.Items.Clear();
            if (!AT_SerialPort.AT_populateComPorts(Form.btnConnect, Form.cBoxComPorts, Form.comPort))
                MessageBox.Show("No valid modem found");
        }

        // 



        #endregion ############################################################

        #region EVENTS ########################################################
        //
        #endregion ############################################################
    }

}
