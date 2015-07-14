using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public class SimpleDirtyTracker
    {
      private Form _frmTracked;  
      private bool _isDirty;

      // property denoting whether the tracked form is clean or dirty
      public bool IsDirty
      {
          get { return _isDirty; }
          set { _isDirty = value; }
      }

      // methods to make dirty or clean
      public void SetAsDirty()
      {
          _isDirty = true;
      }

      public void SetAsClean()
      {
          _isDirty = false;
      }

      // initialize in the constructor by assigning event handlers
      public SimpleDirtyTracker(Form frm)
      {
          _frmTracked = frm;
          AssignHandlersForControlCollection(frm.Controls);
      }
        

      // recursive routine to inspect each control and assign handlers accordingly
      private void AssignHandlersForControlCollection(Control.ControlCollection coll)
      {
          foreach (Control c in coll)
          {
              if (c is TextBox)
                  (c as TextBox).TextChanged += new EventHandler(SimpleDirtyTracker_TextChanged);

              if (c is CheckBox)
                  (c as CheckBox).CheckedChanged += new EventHandler(SimpleDirtyTracker_CheckedChanged);

              // ... apply for other input types similarly ...

              // recurively apply to inner collections
              if (c.HasChildren)
                  AssignHandlersForControlCollection(c.Controls);
          }
      }

      // event handlers
      private void SimpleDirtyTracker_TextChanged(object sender, EventArgs e)
      {
          _isDirty = true;
      }

      private void SimpleDirtyTracker_CheckedChanged(object sender, EventArgs e)
      {
          _isDirty = true;
      }

    }
}
