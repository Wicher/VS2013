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
        SerialPort comPort = new SerialPort();



        public EntryForm()
        {
            InitializeComponent();
            comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        #region BUTTONS #######################################################
        // CONNECT ============================================================
        private void btnConnect_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        // EXIT ===============================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // REFRESH ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cBoxComPorts.Items.Clear();
            AT_SerialPort.AT_populateComPorts(cBoxComPorts, comPort);

        }

        #endregion ############################################################



        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedHandler();
        }

        private string DataReceivedHandler()
        {
            return comPort.ReadExisting().ToString();
        }
    }



























}
