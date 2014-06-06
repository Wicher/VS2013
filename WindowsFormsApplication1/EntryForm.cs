using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
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

        private static string pModemCommand = "adb root && timeout 2 && adb remount && adb shell setprop persist.usb.eng 1 && adb shell setprop sys.usb.config mtp,adb && timeout 3";
        private static string pModemError = "adbd cannot run as root in production builds";

        private string pModemOutput;
        private int pModemExitCode;

        private static Process cmd_pModem = Process.Start("cmd", "/c" + pModemCommand);
         
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
        
        // TURN MODEM ON ######################################################
        private void btnModem_Click(object sender, EventArgs e)
        {
            DisableControl(btnConnect);

            cmd_pModem.StartInfo.RedirectStandardOutput = true;
            cmd_pModem.StartInfo.UseShellExecute = false;
            cmd_pModem.StartInfo.CreateNoWindow = false;
            cmd_pModem.OutputDataReceived += cmd_DataReceived;
            cmd_pModem.EnableRaisingEvents = true;
            
            bool state = cmd_pModem.Start();

            if (!state) 
            {
                cmd_pModem.BeginOutputReadLine();
            }
               
            cmd_pModem.WaitForExit();
          
            if (cmd_pModem.ExitCode.ToString() == "0")
                MessageBox.Show("Modem mounted successfully");
            else
                MessageBox.Show("Fail to mount modem. Error Code: " + cmd_pModem.ExitCode.ToString());
            cmd_pModem.OutputDataReceived -= cmd_DataReceived;
            cmd_pModem.Close();
            EnableControl(btnConnect);
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
        // Lock Control =======================================================
        private void DisableControl(dynamic control)
        {
            if (CheckProperty(control, "Enabled"))
                control.Enabled = false;
        }

        // Unlock Control =====================================================
        private void EnableControl(dynamic control)
        {
            if (CheckProperty(control, "Enabled"))
                control.Enabled = true;
        }

        // Check for property =================================================
        private bool CheckProperty(dynamic control, string property)
        {
            try
            {
                var prop = control.GetType().GetProperty(property);
                if (prop != null)
                    return true;
                else
                    return false;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException :" + e.Message);
                return false;
            }
            catch (AmbiguousMatchException e)
            {
                Console.WriteLine("AmbiguousMatchException :" + e.Message);
                return false;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Source : {0}", e.Source);
                Console.WriteLine("Message : {0}", e.Message);
                return false;
            }
        }

        #endregion ############################################################

        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            pModemOutput = e.Data;
            if (pModemOutput == pModemError)
            {
                cmd_pModem.OutputDataReceived -= cmd_DataReceived;
                cmd_pModem.CancelOutputRead();
                cmd_pModem.WaitForExit(100);
            }
        }

       
    }

}
