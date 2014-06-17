using System;
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
        public static bool AT_populateComPorts(Button btnConnect, ComboBox cBoxComPorts, SerialPort comPort) 
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            string message;
            bool _continue = true;

            foreach (string ports in SerialPort.GetPortNames())
            {
                if (ports.Equals("COM1") || ports.Equals("COM2"))
                {
                    continue;
                }
                else
                {
                    comPort.PortName = ports;
                    try
                    {
                        comPort.Open();
                        if (comPort.IsOpen)
                        {
                            comPort.WriteLine("ATE0");
                            while (!comPort.ReadLine().Equals("OK")) ;
                            comPort.WriteLine("AT");
                            while (_continue)
                            {
                                try
                                {
                                    message = comPort.ReadLine();
                                    if (stringComparer.Equals("OK", message))
                                    {
                                        _continue = false;
                                        cBoxComPorts.Items.Add(ports);
                                        if (cBoxComPorts.Items.Count != 0)
                                            cBoxComPorts.SelectedItem = ports;
                                        comPort.Close();
                                        Utility.EnableControl(btnConnect);
                                        return true;
                                    }
                                }
                                catch (TimeoutException error)
                                {
                                    MessageBox.Show("TimeoutException :" + error.Message);
                                    comPort.Close();
                                }
                            }
                            comPort.Close();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Exception :" + error.Message);
                    }                 
                }
            }
            Utility.DisableControl(btnConnect);
            return false;
        }

        // CONNECT TO MODEM ===================================================
        public static bool AT_Connect(ComboBox cBoxComPorts, SerialPort comPort, TextBox textBox1)
        {
           // MessageBox.Show(cBoxComPorts.SelectedItem.ToString());
            string message;
            var counter = 0;
            
            comPort.PortName = cBoxComPorts.SelectedItem.ToString();
            try
            {
                comPort.Open();
                if(comPort.IsOpen)
                {
                    comPort.WriteLine("AT*");
                    comPort.ReadLine();
                    while(true)
                    {
                        message = comPort.ReadLine();
                        if (message.Equals(""))
                            break;
                        textBox1.AppendText(message + "\n");
                        counter++;
                    }
                    textBox1.AppendText(counter.ToString() + "\n");
                    comPort.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Exception: " + error.Message);
            }
            return true;
        }

        // CONFIGURE COM PORT =================================================
        public static void ConfigureComPort(SerialPort comPort)
        {
            comPort.BaudRate = 115200;
            comPort.DataBits = 8;
            comPort.Parity = Parity.None;
            comPort.StopBits = StopBits.One;
            comPort.Handshake = Handshake.None;
            comPort.NewLine = "\r\n";
            comPort.RtsEnable = false;
            comPort.ReadTimeout = 500;
            comPort.WriteTimeout = 500;
        }
        #endregion ############################################################

        #region EVENTS ########################################################
        //
        #endregion ############################################################

    }
}