﻿using System;
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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }



        #region EVENTS ########################################################
        // Main Form Closed ===================================================
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion ############################################################

    }
}
