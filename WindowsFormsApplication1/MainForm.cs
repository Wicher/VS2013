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
    public partial class MainForm : Form
    {
        #region INSTANCES #####################################################

        private SerialPort comPort;

        #endregion ############################################################

        #region INITIALIZATION ################################################
        public MainForm(SerialPort comPort)
        {
            InitializeComponent();
            this.Enabled = true;
            this.BringToFront();
            this.CenterToParent();
            this.TopMost = true;

            this.comPort = comPort;
        }
        #endregion ############################################################

        #region EVENTS ########################################################
        // MAIN FORM CLOSED ===================================================
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion ############################################################
    }
}
