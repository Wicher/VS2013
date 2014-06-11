using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    sealed class Utility
    {
        #region VARIABLES #####################################################

        private static string controlPropertyEnabled = "Enabled";

        #endregion ############################################################

        #region PUBLIC METHODS ################################################
        // Lock Control =======================================================
        public void DisableControl(dynamic control)
        {
            if (CheckProperty(control, controlPropertyEnabled))
            {
                if(control.Enabled == true)
                    control.Enabled = false;
            }
                
        }

        // Unlock Control =====================================================
        public void EnableControl(dynamic control)
        {
            if (CheckProperty(control, controlPropertyEnabled))
            {
                if(control.Enabled != true)
                    control.Enabled = true;
            }
                
        }
        
        // Toggle Control =====================================================
        public void ToggleControl(dynamic control)
        {
            if (CheckProperty(control, controlPropertyEnabled))
                control.Enabled = !control.Enabled; 
        }

        #endregion ############################################################

        #region PRIVATE METHODS ###############################################
        // Check for property =================================================
        private bool CheckProperty(dynamic control, string property)
        {
            try
            {
                var prop = control.GetType().GetProperty(property);
                if (prop != null)
                    return true;
                else
                    return false;
            }
            catch (ArgumentNullException error)
            {
                MessageBox.Show("ArgumentNullException :" + error.Message);
                return false;
            }
            catch (AmbiguousMatchException error)
            {
                Console.WriteLine("AmbiguousMatchException :" + error.Message);
                return false;
            }
            catch (NullReferenceException error)
            {
                Console.WriteLine("Source : {0}", error.Source);
                Console.WriteLine("Message : {0}", error.Message);
                return false;
            }
        }

        #endregion ############################################################
    }
}
