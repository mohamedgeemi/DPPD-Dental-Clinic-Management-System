using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;


namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Database_Browser : Form
    { 
        DCEntities cont;
        DataSourceConnection myDSconnection;
        BindingSource newBS;
        int NumberOfPatients;
        
        public Database_Browser()
        {
            InitializeComponent();
            this.Text = "Database Browser";
            cont = new DCEntities();
            myDSconnection = new DataSourceConnection();
            newBS = new BindingSource();
            NumberOfPatients = (from P in Login_Form.context.Patient_info select P).Count();
            NormalConnection();
            DataSourceCon("SELECT * FROM Patient_info");
        }

        // Entity Data Viewer
        private void NormalConnection()
        {
            this.ProgressBar_timer.Start();

            NumOfPatients1.Text = NumberOfPatients.ToString();
            DB_dataGridView.AllowUserToResizeColumns = true;
            DB_dataGridView.AllowUserToResizeRows = true;

            try
            {
                var Query = from o in cont.Patient_info select o;
                var Patients = Query.ToArray();

                List<String> CurrentRow;
                foreach (var row in Patients)
                {
                    CurrentRow = new List<String>();
                    CurrentRow = ObjectToList(row);
                    DB_dataGridView.Rows.Add(CurrentRow.ToArray());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        // DB Viewer
        private void DataSourceCon(String cmd)
        {
            NumOfPatients2.Text = NumberOfPatients.ToString();

            // Automatically generate the DataGridView columns.
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;
           

            try
            {
                              // Set up the data source.
                newBS.DataSource = myDSconnection.GetData(cmd);
                dataGridView1.DataSource = newBS.DataSource;
                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string to a Your DB" +
                    " database accessible to your system.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        // Convert Patient Object into list
        public List<String> ObjectToList(Patient_info Patient)
        {
            //////////////////
            List<String> row = new List<String>();
            row.Add("Click Me");
            row.Add(Patient.Patient_ID.ToString());
            row.Add(Patient.Age.ToString());
            row.Add(Patient.Patient_name);
            row.Add( Patient.Home_number);
            row.Add( Patient.Phone_number);
            row.Add( Patient.Address);
            row.Add( Patient.Cheif_complaint);
            row.Add( Patient.Medical_alert);  
            row.Add( Patient.Visit_date.ToShortDateString());
            row.Add( Patient.Birth_date.ToShortDateString());
            row.Add(Patient.Sex);
            row.Add(Patient.Relative_marriage);
            row.Add(Patient.DMF.ToString());
            row.Add(Patient.C_dmf.ToString());
            row.Add(Patient.DEF.ToString());
            row.Add(Patient.Comments);

            return row;
        }

        // View Patient Profile
        private void DB_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String temp;
            int ID;
            if (e.ColumnIndex == 0)
            {
                temp = DB_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                ID = Int32.Parse(temp);

                Patient_Profile_Viewer PatientProfile = new Patient_Profile_Viewer(ID);
                PatientProfile.Show();
            }
        }
        // View Patient Profile
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String temp;
            int ID;
            if (e.ColumnIndex == 0)
            {
                temp = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ID = Int32.Parse(temp);

                Patient_Profile_Viewer PatientProfile = new Patient_Profile_Viewer(ID);
                PatientProfile.Show();
            }

        }
        // View DB tables 
        private void DB_Tables_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String table = DB_Tables_comboBox.Text;
            if (table != "Patient_info")
                VPColumn.Visible = false;
            else
                VPColumn.Visible = true;

            if (table == "X-ray images")
                table = "[X-ray_images]";

            DataSourceCon("SELECT * FROM " + table);
        }

        private void ProgressBar_timer_Tick(object sender, EventArgs e)
        {
            this.DB_browser_progressBar.Increment(3);
            this.ProgressBar_Percentage.Text = DB_browser_progressBar.Value.ToString();
            this.ProgressBar_Percentage.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
