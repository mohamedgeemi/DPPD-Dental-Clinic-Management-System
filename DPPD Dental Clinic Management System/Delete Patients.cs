using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Delete_Patients : Form
    {
        Data_Validator ValidateData;
        ErrorProvider Error;
        DCEntities Delete;
        private SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        public Delete_Patients()
        {
            InitializeComponent();
            ValidateData = new Data_Validator();
            Error = new ErrorProvider();
            Delete = new DCEntities();
        }

        // Delete Set of patients
        private void Delete_patients_button_Click(object sender, EventArgs e)
        {
            String From, To;
            int FromID, ToID;

            From = Delete_from_textBox.Text;
            To = Delete_to_textBox.Text;

            if (!ValidateData.ValidateIDField(From))
            {
                Error.SetError(Delete_from_textBox, "sdgd");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateIDField(To))
            {
                Error.SetError(Delete_to_textBox, "sdgd");
                return;
            }
            Error.Clear();

            FromID = Int32.Parse(From);
            ToID = Int32.Parse(To);

            //------------------------------------
            string message = "Are you sure you want to delete these patients?";
            string caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon Icon = MessageBoxIcon.Warning;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons, Icon);
            if (result == DialogResult.Yes)
            {           
                Delete.Database.ExecuteSqlCommand("DELETE FROM Diagnosis WHERE Patient_ID BETWEEN {0} AND {1} ", FromID, ToID );
                Delete.Database.ExecuteSqlCommand("DELETE FROM Dates WHERE Patient_ID BETWEEN {0} AND {1} ", FromID, ToID);
                Delete.Database.ExecuteSqlCommand("DELETE FROM [X-ray_images] WHERE Patient_ID BETWEEN {0} AND {1} ", FromID, ToID);
                int Number_of_rows_Affected = Delete.Database.ExecuteSqlCommand("DELETE FROM Patient_info WHERE Patient_ID BETWEEN {0} AND {1} ", FromID, ToID);

                Delete.SaveChanges();

                MessageBox.Show(Number_of_rows_Affected +" Patients was deleted.\n Please check your DB browser");

                if (Number_of_rows_Affected != 0)
                {
                    ValidateData.ReorderXray_table();
                    ValidateData.ReorderDiagnosis_table();
                    ValidateData.ReorderDates_table();
                }
                Delete_from_textBox.Text = "";
                Delete_to_textBox.Text = "";
            }
            
        }

        private void Delete_Patients_Load(object sender, EventArgs e)
        {
            // in the Load event initialize our tracking object
            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker(this);
            _dirtyTracker.MarkAsClean();
        }

        private void Delete_Patients_FormClosing(object sender, FormClosingEventArgs e)
        {
            // simulate closing the window; if the form is "dirty" (changed since the last save)
            // then prompt the user to save.

            //string message = "Would you like to save changes before closing?";
            //string caption = "Warning";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            //MessageBoxIcon icon = MessageBoxIcon.Warning;
            //DialogResult result;

            // Displays the MessageBox.

            //if (_dirtyTracker.IsDirty)
            //{
            //    result = MessageBox.Show(message, caption, buttons, icon);
            //    if (result == DialogResult.Yes)
            //    {
            //        _dirtyTracker.MarkAsClean();
            //        MessageBox.Show("You filled some fields without saving");
            //        e.Cancel = true;
            //    }
            //    else if (result == DialogResult.No)
            //    {
            //        e.Cancel = false;
            //    }
            //    else
            //        e.Cancel = true;
            //}
        }
    }
}
