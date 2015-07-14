using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public class ControlDirtyTracker
    {
        private Control _control;
        private string _cleanValue;

        // read only properties
        public Control Control { get { return _control; } }
        public string CleanValue { get { return _cleanValue; } }              

        // constructor establishes the control and uses its current value as "clean"
        public ControlDirtyTracker(Control ctl)
        {            
            // if the control type is not one that is supported, throw an exception
            if (ControlDirtyTracker.IsControlTypeSupported(ctl))
                _control = ctl;            
            else
                throw new NotSupportedException(
                    string.Format("The control type for '{0}' is not supported by the ControlDirtyTracker class."
                      , ctl.Name)
                    );
                    
        }


        // method to establish the the current control value as "clean"
        public void EstablishValueAsClean()
        {
            _cleanValue = GetControlCurrentValue();
        }


        // determine if the current control value is considered "dirty"; 
        // i.e. if the current control value is different than the one
        // remembered as "clean"
        public bool DetermineIfDirty()
        {
            // compare the remembered "clean value" to the current value;
            // if they are the same, the control is still clean;
            // if they are different, the control is considered dirty.
            return (string.Compare(_cleanValue, GetControlCurrentValue(), false) != 0);
        }



        //////////////////////////////////////////////////////////////////////////////////////
        // developers may modify the following two methods to extend support for other types
        //////////////////////////////////////////////////////////////////////////////////////
        
        // static class utility method; return whether or not the control type 
        // of the given control is supported by this class;
        // developers may modify this to extend support for other types
        public static bool IsControlTypeSupported(Control ctl)
        {
            // list of types supported
            if (ctl is TextBox) return true;
            if (ctl is CheckBox) return true;
            if (ctl is ComboBox) return true;
            if (ctl is ListBox) return true;

            // ... add additional types as desired ...                       

            // not a supported type
            return false;
        }
        

        // private method to determine the current value (as a string) of the control;
        // if the control is not supported, return a NotSupported exception
        // developers may modify this to extend support for other types
        private string GetControlCurrentValue()
        {
            if (_control is TextBox)
                return (_control as TextBox).Text;

            if (_control is CheckBox)
                return (_control as CheckBox).Checked.ToString();

            if (_control is ComboBox)
                return (_control as ComboBox).Text;

            if (_control is ListBox)
            {
                // for a listbox, create a list of the selected indexes
                StringBuilder val = new StringBuilder();
                ListBox lb = (_control as ListBox);
                ListBox.SelectedIndexCollection coll = lb.SelectedIndices;
                for (int i = 0; i < coll.Count; i++)
                    val.AppendFormat("{0};", coll[i]);
                
                return val.ToString();                
            }

            // ... add additional types as desired ...

            return "";
        }

    }
}
