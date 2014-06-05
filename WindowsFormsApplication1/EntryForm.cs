using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class EntryForm : Form
    {
        #region VARIABLES #####################################################
        
        private SerialPort comPort;

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
            // INSERT COMMAND
            // adb root && timeout 2 && adb remount && adb shell setprop persist.usb.eng 1 && adb shell setprop sys.usb.config mtp,adb && timeout 3
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
    }



























}
