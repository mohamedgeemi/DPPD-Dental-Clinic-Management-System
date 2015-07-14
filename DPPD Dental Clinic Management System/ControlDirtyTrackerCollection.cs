using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public class ControlDirtyTrackerCollection: List<ControlDirtyTracker>
    {

        // constructors
        public ControlDirtyTrackerCollection() : base() { }
        public ControlDirtyTrackerCollection(Form frm) : base() 
        { 
            // initialize to the controls on the passed in form
            AddControlsFromForm(frm); 
        }


        // utility method to add the controls from a Form to this collection
        public void AddControlsFromForm(Form frm)
        {
            AddControlsFromCollection(frm.Controls);
        }

        // recursive routine to inspect each control and add to the collection accordingly
        public void AddControlsFromCollection(Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                // if the control is supported for dirty tracking, add it
                if (ControlDirtyTracker.IsControlTypeSupported(c))
                    this.Add(new ControlDirtyTracker(c));

                // recurively apply to inner collections
                if (c.HasChildren)
                    AddControlsFromCollection(c.Controls);
            }
        }

        // loop through all controls and return a list of those that are dirty
        public List<Control> GetListOfDirtyControls()
        {
            List<Control> list = new List<Control>();

            foreach (ControlDirtyTracker c in this)
            {
                if (c.DetermineIfDirty())
                    list.Add(c.Control);
            }

            return list;
        }


        // mark all the tracked controls as clean
        public void MarkAllControlsAsClean()
        {
            foreach (ControlDirtyTracker c in this)
                c.EstablishValueAsClean();
        }

    }
}
