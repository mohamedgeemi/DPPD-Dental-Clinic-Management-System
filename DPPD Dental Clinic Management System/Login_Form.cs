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
    
    public partial class Login_Form : Form
    {
        public static DCEntities context;
        public static List<String> DiagnosisList, ProceduresList;
        public static DataTable DiagList, ProcList;
        Data_Validator ValidateData;
        ErrorProvider Error;
        public Login_Form()
        {
            InitializeComponent();
            context = new DCEntities();
            DiagnosisList = new List<String>();
            ProceduresList = new List<String>();
            DiagList = new DataTable();
            ProcList = new DataTable();
            ValidateData = new Data_Validator();
            Error = new ErrorProvider();
            PasswordtextBox.PasswordChar = '*';
            PasswordtextBox.MaxLength = 20;
           
        }

        // Show Create new Account Form
        private void newAccountButton_Click(object sender, EventArgs e)
        {
            Create_New_Account newAccount = new Create_New_Account();

            newAccount.Show();
        }

        // Get login Data 
        private void Login_button_Click(object sender, EventArgs e)
        {
            String Username, Password;
            bool LoginChecker;

            Username = UsernametextBox.Text;
            Password = PasswordtextBox.Text;

            LoginChecker = LoginCheck(Username, Password);

            if (LoginChecker == true)
            {
               // MessageBox.Show("Welcome to DC Management System");
                MainFormPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }


        }

        // Check the login Data
        private static bool LoginCheck(String username, String password)
        {
            foreach (var User in context.Logins)
            {
                if (User.Username.Replace(" ", "") == username && User.Password.Replace(" ", "") == password)
                {
                    return true;
                }
            }

            return false;
        }

        // Show Add new Patient Form
        private void AddnewPatientButton_Click(object sender, EventArgs e)
        {
            Add_new_Patient addNewPatient = new Add_new_Patient();

            addNewPatient.Show();
        }

        // View Specific Patient Profile
        private void View_Patient_Button_Click(object sender, EventArgs e)
        {
            if (!ValidateData.ValidateIDIsExist(IDtoview_textBox.Text))
            {
                Error.SetError(IDtoview_textBox, "Please Enter Valid ID"); 
                return;
            }
            Error.Clear();
                
            int ID = Int32.Parse(IDtoview_textBox.Text);
            Patient_Profile_Viewer ViewProfile = new Patient_Profile_Viewer(ID);
            ViewProfile.Show();

            IDtoview_textBox.Text = "";  
        }

        // View All DB
        private void ViewAll_DB_button_Click(object sender, EventArgs e)
        {
            Database_Browser browse = new Database_Browser();
            browse.Show();
        }

        // View Search Form
        private void SearchPatientsButton_Click(object sender, EventArgs e)
        {
            Search newSearch = new Search();
            newSearch.Show();
        }

        // Save DiagList and ProcList when closing
        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        // Close the form
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Delete some patients
        private void deleteSetOfPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Patients deletePatients = new Delete_Patients();
            deletePatients.Show();
        }

        // Get Stats
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics newState = new Statistics();
            newState.Show();

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mohamed Gamal, Freelance Software Engineer \n\nE-mail:   mohamedgeemi@gmail.com\n\nPhone Number:   01121313074 ");
        }
    }
}
