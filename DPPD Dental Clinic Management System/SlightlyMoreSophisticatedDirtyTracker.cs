using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public class SlightlyMoreSophisticatedDirtyTracker
    {
      private Form _frmTracked;
      private ControlDirtyTrackerCollection _controlsTracked;

      // property denoting whether the tracked form is clean or dirty;
      // used if the full list of dirty controls isn't necessary
      public bool IsDirty
      {
          get 
          {
              List<Control> dirtyControls
                  = _controlsTracked.GetListOfDirtyControls();

              return (dirtyControls.Count > 0);
          }
      }


      // public method for accessing the list of currently
      // "dirty" controls
      public List<Control> GetListOfDirtyControls()
      {
          return _controlsTracked.GetListOfDirtyControls();
      }

      
      // establish the form as "clean" with whatever current
      // control values exist
      public void MarkAsClean()
      {
          _controlsTracked.MarkAllControlsAsClean();
      }


      // initialize in the constructor by assigning controls to track
      public SlightlyMoreSophisticatedDirtyTracker(Form frm)
      {
          _frmTracked = frm;
          _controlsTracked = new ControlDirtyTrackerCollection(frm);
      }
        

    }
}
