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
        public EntryForm()
        {
            InitializeComponent();
            AT_SerialPort.AT_populateComPorts(cBoxComPorts);

         /*   foreach (string ports in SerialPort.GetPortNames())
            {
                cBoxComPorts.Items.Add(ports);
            } 
         */
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
            foreach (string ports in SerialPort.GetPortNames())
            {
                cBoxComPorts.Items.Add(ports);
            }
        }

        #endregion ############################################################

    }



























}
