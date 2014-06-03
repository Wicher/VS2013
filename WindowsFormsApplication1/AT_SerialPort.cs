﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    static class AT_SerialPort
    {
        #region METHODS #######################################################
        // POPULATE COM PORTS =================================================
        // + modem verification 
        public static void AT_populateComPorts(ComboBox cBoxComPorts, SerialPort comPort) 
        {
            comPort.BaudRate    = 115200;
            comPort.DataBits    = 8;
            comPort.Parity      = Parity.None;
            comPort.StopBits    = StopBits.One;
            comPort.Handshake   = Handshake.None;
            comPort.RtsEnable   = false;

            foreach (string ports in SerialPort.GetPortNames())
            {
                if(ports.Equals("COM1") || ports.Equals("COM2"))
                {
                    continue;
                }
                else
                {
                    comPort.PortName = ports;
                    comPort.Open();
                    if (comPort.IsOpen)
                    {
                        comPort.WriteLine("AT\r");
                       // MessageBox.Show(comPort.ReadLine().ToString());
                   //     if (comPort.ReadLine().ToString().Equals("OK")) cBoxComPorts.Items.Add(ports);
                        if (comPort.ReadExisting().ToString().Equals("OK")) cBoxComPorts.Items.Add(ports);
                        //cBoxComPorts.Items.Add(ports);
                        comPort.Close();
                    }




                    /*
                    #region Data Receive  
                    private void SetText(string text)
                    {
                        if (this.textB_Console.InvokeRequired)
                        {
                            SetTextCallback d = new SetTextCallback(SetText);
                            this.Invoke(d, new object[] { text });
                        }
                        else
                        {
                            this.textB_Console.AppendText(text);
                        }
                    }

                    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
                    {
                        string txt = _serialPort.ReadExisting().ToString();
                        SetText(txt.ToString());
                    }
                    #endregion
                    */
                      
                     
                    /* checking
                    comPort.PortName = "COM33";
                    comPort.Open();
                    comPort.WriteLine("AT");
                    MessageBox.Show(comPort.ReadLine().ToString());
                    comPort.Close();
                    */

                }
            }      
        }

        


        #endregion ############################################################

        #region EVENTS ########################################################

        #endregion ############################################################

    }
}