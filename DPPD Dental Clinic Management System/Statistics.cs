using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Statistics : Form
    {
        Data_Validator ValidateData;
        DCEntities Stats;
        ErrorProvider Error;
        BindingSource BS;
        DataSourceConnection con;
        private SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        public Statistics()
        {
            InitializeComponent();
            ValidateData = new Data_Validator();
            Stats = new DCEntities();
            Error = new ErrorProvider();
            BS = new BindingSource();
            con = new DataSourceConnection();
            IntializeComboboxes();
        }

        private void IntializeComboboxes()
        {
            String SqlCommand = "SELECT DISTINCT Procedures FROM ProcedureList";
            BS.DataSource = con.GetData(SqlCommand);
            if (Login_Form.ProcList.Rows.Count != 0)
            {
                Procedures_comboBox.DataSource = Login_Form.ProcList;
            }
            else
                Procedures_comboBox.DataSource = BS;

            Procedures_comboBox.DisplayMember = "Procedures";
            Procedures_comboBox.SelectedIndex = -1;
        }

        private void Get_Number_Visits_button_Click(object sender, EventArgs e)
        {
            String From, To, FromV, ToV;

            From = Visits_from_textBox.Text;
            To = Visits_to_textBox.Text;

            if (!ValidateData.ValidateDate(From))
            {
                MessageBox.Show("Please enter a valid visit date, ex: 1/1/2016 ");
                Error.SetError(Visits_from_textBox, "sdgd");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateDate(To))
            {
                MessageBox.Show("Please enter a valid visit date, ex: 1/1/2016 ");
                Error.SetError(Visits_to_textBox, "sdgd");
                return;
            }
            Error.Clear();

            try
            {

                DateTime Key1 = DateTime.Parse(From);
                FromV = Key1.ToString("yyyy-MM-dd");

                DateTime Key2 = DateTime.Parse(To);
                ToV = Key2.ToString("yyyy-MM-dd");


                var NumberOfVisits = (from V in Stats.Patient_info.Where(V => V.Visit_date >= Key1 && V.Visit_date <= Key2) select V).Count();


                MessageBox.Show("The number of patients is: " + NumberOfVisits.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Get_BirthDate_Button_Click(object sender, EventArgs e)
        {
            String From, To, FromV, ToV;

            From = BirthDate_from_textBox.Text;
            To = Birth_date_to_textBox.Text;

            if (!ValidateData.ValidateDate(From))
            {
                MessageBox.Show("Please enter a valid Birth date, ex: 1/1/2016 ");
                Error.SetError(BirthDate_from_textBox, "sdgd");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateDate(To))
            {
                MessageBox.Show("Please enter a valid Birth date, ex: 1/1/2016 ");
                Error.SetError(Birth_date_to_textBox, "sdgd");
                return;
            }
            Error.Clear();

            try
            {

                DateTime Key1 = DateTime.Parse(From);
                FromV = Key1.ToString("yyyy-MM-dd");

                DateTime Key2 = DateTime.Parse(To);
                ToV = Key2.ToString("yyyy-MM-dd");


                var NumberOfPatients = (from V in Stats.Patient_info.Where(V => V.Birth_date >= Key1 && V.Birth_date <= Key2) select V).Count();

                MessageBox.Show("The number of patients is: " + NumberOfPatients.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private void Get_Proc_Number_Button_Click(object sender, EventArgs e)
        {
            String Choise = Procedures_comboBox.Text;
            List<String> ComboBoxItems = new List<String>();

            for (int i = 0; i < Procedures_comboBox.Items.Count; i++)
            {
                ComboBoxItems.Add( Procedures_comboBox.GetItemText(Procedures_comboBox.Items[i]) );
            }

            if (!ValidateData.ValidateComboBoxItem(Choise, ComboBoxItems))
            {
                Error.SetError(Procedures_comboBox, "shdf");
                return;
            }
            Error.Clear();

            try
            {

                var NumOftimes = (from P in Stats.Dates.Where(P => P.Procedures == Choise) select P).Count();

                if(NumOftimes == 0)
                    MessageBox.Show(Choise + " Procedure was NOT performed at all");
                else if (NumOftimes == 1)
                    MessageBox.Show(Choise + " Procedure was performed " + NumOftimes.ToString() + " time.");
                else
                    MessageBox.Show(Choise + " Procedure was performed " + NumOftimes.ToString() + " times.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            // in the Load event initialize our tracking object
            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker(this);
            _dirtyTracker.MarkAsClean();

        }

        private void Statistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            // simulate closing the window; if the form is "dirty" (changed since the last save)
            // then prompt the user to save.

            //string message = "Would you like to save changes before closing?";
            //string caption = "Warning";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            //MessageBoxIcon icon = MessageBoxIcon.Warning;
            //DialogResult result;

            //// Displays the MessageBox.

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
