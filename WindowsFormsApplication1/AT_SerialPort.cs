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
        public static bool AT_populateComPorts(ComboBox cBoxComPorts, SerialPort comPort) 
        {
            comPort.BaudRate    = 115200;
            comPort.DataBits    = 8;
            comPort.Parity      = Parity.None;
            comPort.StopBits    = StopBits.One;
            comPort.Handshake   = Handshake.None;
            comPort.NewLine     = "\r\n";
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
                    try
                    {
                        comPort.Open();
                        if (comPort.IsOpen)
                        {
                            comPort.WriteLine("ATE0");
                            System.Threading.Thread.Sleep(100);
                            comPort.WriteLine("AT");
                            while (!comPort.ReadLine().Equals("OK")) MessageBox.Show("modem OK");
                            comPort.Close();
                            return true;
                        }
                    }
                    catch(UnauthorizedAccessException error)
                    {
                        MessageBox.Show("UnauthorizedAccessException: " + error.Message);
                    }
                    catch(ArgumentOutOfRangeException error)
                    {
                        MessageBox.Show("ArgumentOutOfRangeException: " + error.Message);
                    }
                    catch (ArgumentException error)
                    {
                        MessageBox.Show("ArgumentException: " + error.Message);
                    }
                    catch (InvalidOperationException error)
                    {
                        MessageBox.Show("InvalidOperationException: " + error.Message);
                    }                 
                }
            }
            return false;
        }

        #endregion ############################################################

        #region EVENTS ########################################################
        //
        #endregion ############################################################

    }
}