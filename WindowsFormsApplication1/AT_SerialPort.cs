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
        public static void AT_populateComPorts(ComboBox cBoxComPorts) 
        {
            foreach (string ports in SerialPort.GetPortNames())
            {
                cBoxComPorts.Items.Add(ports);
            }
        }

        


        #endregion ############################################################
    }
}
