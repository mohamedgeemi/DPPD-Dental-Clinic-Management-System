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
    public partial class Search_Result : Form
    {
        String sqlCommand;
        BindingSource BS;
        DataSourceConnection myDSC;
        public bool ShowForm;
        public Search_Result(String SQLCOMMAND)
        {
            InitializeComponent();
            sqlCommand = SQLCOMMAND;
            ShowForm = true;
            BS = new BindingSource();
            myDSC = new DataSourceConnection();
            ViewData();
        }

        // View the data of the result search
        public void ViewData()
        {
            // Automatically generate the DataGridView columns.
            DataTable Check = new DataTable();
            try
            {
                Search_Result_dataGridView.AutoGenerateColumns = true;
                Search_Result_dataGridView.AllowUserToResizeColumns = true;
                Search_Result_dataGridView.AllowUserToResizeRows = true;
                // Set up the data source.
                BS.DataSource = myDSC.GetData(sqlCommand);
                Check = myDSC.GetData(sqlCommand);

                if (Check.Rows.Count == 0)
                {
                    ShowForm = false;
                    MessageBox.Show("This Search key is not exist in the database\nPlease try again with different Search Key/s");
                    return;
                }
                Search_Result_dataGridView.DataSource = BS.DataSource;
                // Set the DataGridView control's border.
                Search_Result_dataGridView.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                Search_Result_dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
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

        // Close the form
        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open selected patient profile from the search result
        private void Search_Result_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String temp;
            int ID;
            if (e.ColumnIndex == 0)
            {
                temp = Search_Result_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                ID = Int32.Parse(temp);

                Patient_Profile_Viewer PatientProfile = new Patient_Profile_Viewer(ID);
                PatientProfile.Show();
            }
        }
    }
}
