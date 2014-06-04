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

        delegate void SetTextCallback(string text);

        #endregion ############################################################


        #region INITIALIZATION ################################################
        public EntryForm(SerialPort comPort)
        {
            InitializeComponent();
            this.comPort = comPort;
   //         comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }
        #endregion ############################################################

        #region BUTTONS #######################################################
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

        // REFRESH ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cBoxComPorts.Items.Clear();
            AT_SerialPort.AT_populateComPorts(cBoxComPorts, comPort);
        }

        #endregion ############################################################



  /*      private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string txt = comPort.ReadExisting().ToString();
            SetText(txt.ToString());
        }

        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        } */




        //private string DataReceivedHandler()
        //{
        //    return comPort.ReadExisting().ToString();
        //}
    }



























}
