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
        public static void AT_populateComPorts(ComboBox cBoxComPorts, SerialPort comPort) 
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
                    comPort.Open();
                    if (comPort.IsOpen)
                    {
                        comPort.WriteLine("ATE0");
                        System.Threading.Thread.Sleep(100);
                        comPort.WriteLine("AT");
                        while (!comPort.ReadLine().Equals("OK")) MessageBox.Show("modem OK");







                            //             if (comPort.ReadLine().Equals("OK")) MessageBox.Show("trafiony");

                            //             comPort.WriteLine("AT\r");







                            //        while (!comPort.ReadLine().Equals("OK")) comPort.DiscardInBuffer();
                            //       MessageBox.Show("got OK");

                            //answer = comPort.ReadLine();


                            /*      if (!comPort.ReadLine().Contains("\r\n"))
                                  {
                                      answer = comPort.ReadLine();
                                      MessageBox.Show(answer);
                                  }*/

                            // MessageBox.Show(comPort.ReadLine().ToString());
                            //     if (comPort.ReadLine().ToString().Equals("OK")) cBoxComPorts.Items.Add(ports);
                            //     if (comPort.ReadExisting().ToString().Equals("OK")) cBoxComPorts.Items.Add(ports);
                            //cBoxComPorts.Items.Add(ports);



                            comPort.Close();
                    }


                }
            }      
        }

        


        #endregion ############################################################

        #region EVENTS ########################################################
        //
        #endregion ############################################################

    }
}