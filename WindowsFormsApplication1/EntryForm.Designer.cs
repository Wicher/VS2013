namespace WindowsFormsApplication1
{
    partial class EntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cBoxComPorts = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbCOMPort = new System.Windows.Forms.GroupBox();
            this.btnModem = new System.Windows.Forms.Button();
            this.gbModem = new System.Windows.Forms.GroupBox();
            this.gbCOMPort.SuspendLayout();
            this.gbModem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(10, 141);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(99, 141);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cBoxComPorts
            // 
            this.cBoxComPorts.BackColor = System.Drawing.SystemColors.Window;
            this.cBoxComPorts.FormattingEnabled = true;
            this.cBoxComPorts.Location = new System.Drawing.Point(8, 21);
            this.cBoxComPorts.Margin = new System.Windows.Forms.Padding(5);
            this.cBoxComPorts.Name = "cBoxComPorts";
            this.cBoxComPorts.Size = new System.Drawing.Size(160, 21);
            this.cBoxComPorts.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(8, 52);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 21);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbCOMPort
            // 
            this.gbCOMPort.Controls.Add(this.cBoxComPorts);
            this.gbCOMPort.Controls.Add(this.btnRefresh);
            this.gbCOMPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCOMPort.Location = new System.Drawing.Point(5, 5);
            this.gbCOMPort.Name = "gbCOMPort";
            this.gbCOMPort.Size = new System.Drawing.Size(174, 77);
            this.gbCOMPort.TabIndex = 4;
            this.gbCOMPort.TabStop = false;
            this.gbCOMPort.Text = "COM Port";
            // 
            // btnModem
            // 
            this.btnModem.Location = new System.Drawing.Point(8, 21);
            this.btnModem.Margin = new System.Windows.Forms.Padding(5);
            this.btnModem.Name = "btnModem";
            this.btnModem.Size = new System.Drawing.Size(160, 21);
            this.btnModem.TabIndex = 4;
            this.btnModem.Text = "Turn Modem ON";
            this.btnModem.UseVisualStyleBackColor = true;
            this.btnModem.Click += new System.EventHandler(this.btnModem_Click);
            // 
            // gbModem
            // 
            this.gbModem.Controls.Add(this.btnModem);
            this.gbModem.Location = new System.Drawing.Point(5, 87);
            this.gbModem.Name = "gbModem";
            this.gbModem.Size = new System.Drawing.Size(174, 46);
            this.gbModem.TabIndex = 5;
            this.gbModem.TabStop = false;
            this.gbModem.Text = "Modem";
            // 
            // EntryForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(184, 170);
            this.ControlBox = false;
            this.Controls.Add(this.gbModem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gbCOMPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EntryForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "AT Commander";
            this.gbCOMPort.ResumeLayout(false);
            this.gbModem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbCOMPort;
        private System.Windows.Forms.Button btnModem;
        private System.Windows.Forms.GroupBox gbModem;
        private System.Windows.Forms.ComboBox cBoxComPorts;

    }
}