using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Search : Form
    {
        DCEntities SearchContext;
        Patient_info Patient;
        Diagnosis Diagnose;
        Date Date;
        DataSourceConnection con;
        BindingSource BS;
        Data_Validator ValidateData;
        ErrorProvider Error;
        Dictionary<String, String> TableNames;
        List<String> SearchOptions;
        private SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        public Search()
        {
            InitializeComponent();
            SearchContext = new DCEntities();
            Patient = new Patient_info();
            Diagnose = new Diagnosis();
            Date = new Date();
            con = new DataSourceConnection();
            BS = new BindingSource();
            ValidateData = new Data_Validator();
            Error = new ErrorProvider();
            TableNames = new Dictionary<String, String>();
            SearchOptions = new List<String>();
            
            IntializeLists();
        }

        // Intialize DiagList And ProcList
        private void IntializeLists()
        {
            
            string SqlCommand = "SELECT DISTINCT Diagnose FROM DiagnosisList";
            BS.DataSource = con.GetData(SqlCommand);
            if (Login_Form.DiagList.Rows.Count != 0)
            {
                Set_Search_Diagnosis_comboBox.DataSource = Login_Form.DiagList;
                SetK_P1_Diagnosis_comboBox.DataSource = Login_Form.DiagList;
                SetK_P2_Diagnosis_comboBox.DataSource = Login_Form.DiagList;
            }
            else
            {
                Set_Search_Diagnosis_comboBox.DataSource = BS.DataSource;
                SetK_P1_Diagnosis_comboBox.DataSource = BS.DataSource;
                SetK_P2_Diagnosis_comboBox.DataSource = BS.DataSource;
            }
               
            Set_Search_Diagnosis_comboBox.DisplayMember = "Diagnose";
            Set_Search_Diagnosis_comboBox.SelectedIndex = -1;
            SetK_P1_Diagnosis_comboBox.DisplayMember = "Diagnose";
            SetK_P1_Diagnosis_comboBox.SelectedIndex = -1;
            SetK_P2_Diagnosis_comboBox.DisplayMember = "Diagnose";
            SetK_P2_Diagnosis_comboBox.SelectedIndex = -1;

            SqlCommand = "SELECT DISTINCT Procedures FROM ProcedureList";
            BS.DataSource = con.GetData(SqlCommand);
            if (Login_Form.ProcList.Rows.Count != 0)
            {
                Set_Search_Procedures_comboBox.DataSource = Login_Form.ProcList;
                SetK_P1_DAP_comboBox.DataSource = Login_Form.ProcList;
                SetK_P2_DAP_comboBox.DataSource = Login_Form.ProcList;
            }

            else
            {
                Set_Search_Procedures_comboBox.DataSource = BS.DataSource;
                SetK_P1_DAP_comboBox.DataSource = BS.DataSource;
                SetK_P2_DAP_comboBox.DataSource = BS.DataSource;
 
            }
                
            Set_Search_Procedures_comboBox.DisplayMember = "Procedures";
            Set_Search_Procedures_comboBox.SelectedIndex = -1;
            SetK_P1_DAP_comboBox.DisplayMember = "Procedures";
            SetK_P1_DAP_comboBox.SelectedIndex = -1;
            SetK_P2_DAP_comboBox.DisplayMember = "Procedures";
            SetK_P2_DAP_comboBox.SelectedIndex = -1;

            //---------------------
            TableNames.Add("Diagnose", "Diagnosis");
            TableNames.Add("Procedures", "Dates");
            TableNames.Add("Visit_date", "Patient_info");
            TableNames.Add("Sex", "Patient_info");
            TableNames.Add("Relative_marriage", "Patient_info");
            TableNames.Add("Patient_name", "Patient_info");
            TableNames.Add("Age", "Patient_info");
            TableNames.Add("Doctor_name", "Dates");
            //---------------------------------
            SearchOptions.Add("Diagnose");
            SearchOptions.Add("Procedures");
            SearchOptions.Add("Visit_date");
            SearchOptions.Add("Sex");
            SearchOptions.Add("Relative_marriage");
            SearchOptions.Add("Patient_name");
            SearchOptions.Add("Age");
            SearchOptions.Add("Doctor_name");
        }

        // Search for specific person
        private void Search_for_Patient_Click(object sender, EventArgs e)
        {
            String Option = Inv_Search_options_comboBox.Text;
            String SearchKey = indv_Search_key_textBox.Text;
            int ID;

            if (!ValidateData.ValidateComboBoxItem(Option, new List<String> { "ID", "Home Number", "Mobile Number" }))
            {
                Error.SetError(Inv_Search_options_comboBox, "Please enter validate search option");
                return;
            }
            Error.Clear();
                
            if (!ValidateData.ValidateIntSearchKey(SearchKey))
            {
                Error.SetError(indv_Search_key_textBox, "Please enter validate search key");
                return;

            }
            Error.Clear();

            if (Option == "ID")
            {
                ID = Int32.Parse(SearchKey);
            }
            else
            {
                if (CheckIfExist(Option, SearchKey) == false)
                    return;

                ID = GetID(Option, SearchKey);
            }

            Patient_Profile_Viewer ViewPatient = new Patient_Profile_Viewer(ID);

            if(ViewPatient.CheckBoxIfExist())
               ViewPatient.Show();

            Inv_Search_options_comboBox.Text = "";
            indv_Search_key_textBox.Text = "";

        }

        // Check if search key is exist
        private bool CheckIfExist(String Option, String Choise)
        {
            if (Option == "Home Number")
            {
                if (!SearchContext.Patient_info.Any(i => i.Home_number == Choise))
                {
                    MessageBox.Show("This Home number is not exist on your database");
                    return false;
                }
                
            }
            else if (Option == "Mobile Number")
            {
                if (!SearchContext.Patient_info.Any(i => i.Phone_number == Choise))
                {
                    MessageBox.Show("This Moblie number is not exist on your database");
                    return false;
                }
            }

            return true;
        }

        // Get the ID of the choise
        private int GetID(String Option, String Choise)
        {
            int ID = 0;
            
            if (Option == "Home Number")
            {
                Patient = SearchContext.Patient_info.Where(i => i.Home_number == Choise).First();
                ID = Patient.Patient_ID;
            }
            else if (Option == "Mobile Number")
            {
                Patient = SearchContext.Patient_info.Where(i => i.Phone_number == Choise).FirstOrDefault();
                ID = Patient.Patient_ID;
            }

            return ID;
        }

        // Select Control to be visible accourding to the selected Item
        private void Set_Search_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Choise = Set_Search_comboBox.SelectedItem.ToString();

            if (Choise == "Diagnose")
            {
                Set_Search_Diagnosis_comboBox.Visible = true;
                Set_Search_Key_textBox.Visible = false;
                Set_Search_Procedures_comboBox.Visible = false;
                Set_Search_Sex_comboBox.Visible = false;
                Set_Search_RealativeM_comboBox.Visible = false;
            }
            else if (Choise == "Procedures")
            {
                Set_Search_Diagnosis_comboBox.Visible = false;
                Set_Search_Key_textBox.Visible = false;
                Set_Search_Procedures_comboBox.Visible = true;
                Set_Search_Sex_comboBox.Visible = false;
                Set_Search_RealativeM_comboBox.Visible = false;
            }
            else if (Choise == "Sex")
            {
                Set_Search_Sex_comboBox.Visible = true;
                Set_Search_RealativeM_comboBox.Visible = false;
                Set_Search_Diagnosis_comboBox.Visible = false;
                Set_Search_Key_textBox.Visible = false;
                Set_Search_Procedures_comboBox.Visible = false;
            }
            else if (Choise == "Relative_marriage")
            {
                Set_Search_Sex_comboBox.Visible = false;
                Set_Search_RealativeM_comboBox.Visible = true;
                Set_Search_Diagnosis_comboBox.Visible = false;
                Set_Search_Key_textBox.Visible = false;
                Set_Search_Procedures_comboBox.Visible = false;
            }
            else
            {
                Set_Search_Sex_comboBox.Visible = false;
                Set_Search_RealativeM_comboBox.Visible = false;
                Set_Search_Diagnosis_comboBox.Visible = false;
                Set_Search_Key_textBox.Visible = true;
                Set_Search_Procedures_comboBox.Visible = false;
            }
        }

        // Search for set of people
        private void Set_Search_button_Click(object sender, EventArgs e)
        {
            String Option = Set_Search_comboBox.Text;
            String SearchKey, SQLcommand;

            if (!ValidateData.ValidateComboBoxItem(Option, SearchOptions))
            {
                Error.SetError(Set_Search_comboBox, "Please");
                return;
            }
            Error.Clear();    

            if (Option == "Diagnose")
                SearchKey = Set_Search_Diagnosis_comboBox.Text;
            else if (Option == "Procedures")
                SearchKey = Set_Search_Procedures_comboBox.Text;
            else if (Option == "Sex")
                SearchKey = Set_Search_Sex_comboBox.Text;
            else if (Option == "Relative_marriage")
                SearchKey = Set_Search_RealativeM_comboBox.Text;
            else
                SearchKey = Set_Search_Key_textBox.Text;

            if (!ValidateData.ValidateSetSearchKey(Option, SearchKey) || !Check_IfExist(Option, SearchKey))
            {
                if (Option == "Diagnose")
                    Error.SetError(Set_Search_Diagnosis_comboBox, "Please enter valid data");
                else if (Option == "Procedures")
                    Error.SetError(Set_Search_Procedures_comboBox, "Please enter valid data");
                else if (Option == "Sex")
                     Error.SetError(Set_Search_Sex_comboBox, "Please enter valid data");
                else if (Option == "Relative_marriage")
                     Error.SetError(Set_Search_RealativeM_comboBox, "Please enter valid data");
                else
                    Error.SetError(Set_Search_Key_textBox, "Please enter valid data");
                return;
            }
            Error.Clear();
       
            ////////////////////////////////////////////////////////

            SQLcommand = Get_Set_Search_SQLcommand(Option, SearchKey);

            if (SQLcommand.Length != 0)
            {
                Search_Result newResult = new Search_Result(SQLcommand);

                if (newResult.ShowForm == true)
                    newResult.Show();
                else
                {
                    Error.SetError(Set_Search_2P_Button, "Search keys is not exist in your database");
                    return;
                }

            }
            else
            {
                MessageBox.Show("SQL COMMAND STRING IS EMPTY");
            }
            Error.Clear();
        }

        // Check if Search key is exist
        private bool Check_IfExist(String Option, String SearchKey)
        {
            DataSourceConnection Check = new DataSourceConnection();
            DataTable _Check = new DataTable();
            if (Option == "Diagnose")
            {

                _Check = Check.GetData("Select Diagnose from Diagnosis where Diagnose LIKE '%" + SearchKey + "%'");
                
                if (_Check.Rows.Count == 0)
                {
                    MessageBox.Show("This Diagnose is not exist on your database");
                    return false;
                }

            }
            else if (Option == "Procedures")
            {
                _Check = Check.GetData("Select Procedures from Dates where Procedures LIKE '%" + SearchKey + "%'");
                if (_Check.Rows.Count == 0)
                {
                    MessageBox.Show("This Procedure is not exist on your database");
                    return false;
                }
            }
            if (Option == "Visit_date")
            {
                DateTime temp = DateTime.Parse(SearchKey);
                if (!SearchContext.Patient_info.Any(i => i.Visit_date == temp))
                {
                    MessageBox.Show("This Visit date is not exist on your database");
                    return false;
                }
            }
            else if (Option == "Doctor_name")
            {
                _Check = Check.GetData("Select Doctor_name from Dates where Doctor_name LIKE '%" + SearchKey + "%'");
                if (_Check.Rows.Count == 0)
                {
                    MessageBox.Show("This Doctor Name is not exist on your database");
                    return false;
                }
            }
            else if (Option == "Sex")
            {
                if (!SearchContext.Patient_info.Any(i => i.Sex == SearchKey))
                {
                    MessageBox.Show("This Sex is not exist on your database");
                    return false;
                }
            }
            else if (Option == "Relative_marriage")
            {
                if (!SearchContext.Patient_info.Any(i => i.Relative_marriage == SearchKey))
                {
                    MessageBox.Show("This Relative Marriage is not exist on your database");
                    return false;
                }
            }
            else if (Option == "Patient_name")
            {
                _Check = Check.GetData("Select Patient_name from Patient_info where Patient_name LIKE '%" + SearchKey + "%'");
                if (_Check.Rows.Count == 0)
                {
                    MessageBox.Show("This Patient Name is not exist on your database");
                    return false;
                }
            }
            else if (Option == "Age")
            {
                int temp = Int32.Parse(SearchKey);
                if (!SearchContext.Patient_info.Any(i => i.Age == temp))
                {
                    MessageBox.Show("This Age is not exist on your database");
                    return false;
                }
            }
            return true;

        }

        // Get the SQL Command for the Set Search
        private String Get_Set_Search_SQLcommand(String Option, String SearchKey)
        {
            String SQLcommand = "";
            if (TableNames[Option] == "Patient_info")
            {
                if (Option == "Visit_date")
                {
                    DateTime Key = DateTime.Parse(SearchKey);
                    String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                    SQLcommand = "SELECT * FROM " + TableNames[Option] + " WHERE " + Option + " = '" + FormatedSearchKey + "'";

                }
                else if (Option == "Patient_name")
                    SQLcommand = "SELECT * FROM " + TableNames[Option] + " WHERE "+ Option +" LIKE '%" + SearchKey + "%'";
                else
                    SQLcommand = "SELECT * FROM " + TableNames[Option] + " WHERE " + Option + " = '" + SearchKey + "'";
            }
            else
            SQLcommand = "SELECT * FROM Patient_info AS P , " + TableNames[Option] + " AS D WHERE P.Patient_ID = D.Patient_ID AND D." + Option + " LIKE '%" + SearchKey + "%'";
            return SQLcommand;

            //if (Option == "Diagnosis")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info AS P , Diagnosis AS D WHERE P.Patient_ID = D.Patient_ID AND D.Diagnose LIKE '%"+SearchKey+"%'";
            //}
            //else if (Option == "Procedure")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info AS P , Dates AS D WHERE P.Patient_ID = D.Dates_Patient_ID AND D.Procedures LIKE '%" + SearchKey + "%'";
            //}
            //else if (Option == "Visit Date")
            //{
            //    DateTime Key = DateTime.Parse(SearchKey);
            //    String FormatedSearchKey = Key.ToString("yyyy-MM-dd");

            //    SQLcommand = "SELECT * FROM Patient_info WHERE Visit_date = '" + FormatedSearchKey + "'";
                
            //}
            //else if (Option == "Doctor Name")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info AS P , Dates AS D WHERE P.Patient_ID = D.Dates_Patient_ID AND D.Doctor_name LIKE '%" + SearchKey + "%'";
            //}
            //else if (Option == "Sex")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info WHERE Sex = '" + SearchKey + "'";
            //}
            //else if (Option == "Relative Marriage")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info WHERE Relative_marriage = '" + SearchKey + "'";
            //}
            //else if (Option == "Name")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info WHERE Patient_name LIKE '%" + SearchKey + "%'";
            //}
            //else if (Option == "Age")
            //{
            //    SQLcommand = "SELECT * FROM Patient_info WHERE Age = '" + SearchKey + "'";
            //}
 

    
        }

        // Search for set of people with two parameters
        private void Set_Search_2P_Button_Click(object sender, EventArgs e)
        {
            String Option1 = Set_S_P1_comboBox.Text;
            String Option2 = Set_S_P2_comboBox.Text;
            String SearchKey1, SearchKey2, SQLcommand;

            #region Data Validation
            //Validate Options
            if (!ValidateData.ValidateComboBoxItem(Option1, SearchOptions))
            {
                Error.SetError(Set_S_P1_comboBox, "Please");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateComboBoxItem(Option2, SearchOptions))
            {
                Error.SetError(Set_S_P2_comboBox, "Please");
                return;
            }
            Error.Clear();

            if (Option1 == Option2)
            {
                MessageBox.Show("Please choose different Search Parameters");
                Error.SetError(Set_S_P1_comboBox, "plz");
                Error.SetError(Set_S_P2_comboBox, "plz");
                return;
            }
            Error.Clear();

            // Get Search Keys Data
            if (Option1 == "Diagnose")
                SearchKey1 = SetK_P1_Diagnosis_comboBox.Text;
            else if (Option1 == "Procedures")
                SearchKey1 = SetK_P1_DAP_comboBox.Text;
            else if (Option1 == "Sex")
                SearchKey1 = SetK_P1_Sex_comboBox.Text;
            else if (Option1 == "Relative_marriage")
                SearchKey1 = SetK_P1_RM_comboBox.Text;
            else
                SearchKey1 = SetK_P1_textBox.Text;
            // ----------------------------------------
            if (Option2 == "Diagnose")
                SearchKey2 = SetK_P2_Diagnosis_comboBox.Text;
            else if (Option2 == "Procedures")
                SearchKey2 = SetK_P2_DAP_comboBox.Text;
            else if (Option2 == "Sex")
                SearchKey2 = SetK_P2_Sex_comboBox.Text;
            else if (Option2 == "Relative_marriage")
                SearchKey2 = SetK_P2_RM_comboBox.Text;
            else
                SearchKey2 = SetK_P2_textBox.Text;
            // -------------------------------------
            // Validate Search Keys
            if (!ValidateData.ValidateSetSearchKey(Option1, SearchKey1) || !Check_IfExist(Option1, SearchKey1))
            {
                if (Option1 == "Diagnose")
                    Error.SetError(SetK_P1_Diagnosis_comboBox, "Please enter valid data");
                else if (Option1 == "Procedures")
                    Error.SetError(SetK_P1_DAP_comboBox, "Please enter valid data");
                else if (Option1 == "Sex")
                    Error.SetError(SetK_P1_Sex_comboBox, "Please enter valid data");
                else if (Option1 == "Relative_marriage")
                    Error.SetError(SetK_P1_RM_comboBox, "Please enter valid data");
                else
                    Error.SetError(SetK_P1_textBox, "Please enter valid data");
                return;
            }
            Error.Clear();
            // ---------------------------------------
            if (!ValidateData.ValidateSetSearchKey(Option2, SearchKey2) || !Check_IfExist(Option2, SearchKey2))
            {
                if (Option2 == "Diagnose")
                    Error.SetError(SetK_P2_Diagnosis_comboBox, "Please enter valid data");
                else if (Option2 == "Procedures")
                    Error.SetError(SetK_P2_DAP_comboBox, "Please enter valid data");
                else if (Option2 == "Sex")
                    Error.SetError(SetK_P2_Sex_comboBox, "Please enter valid data");
                else if (Option2 == "Relative_marriage")
                    Error.SetError(SetK_P2_RM_comboBox, "Please enter valid data");
                else
                    Error.SetError(SetK_P2_textBox, "Please enter valid data");
                return;
            }
            Error.Clear();

            #endregion



            //--------------------------------------------------
            // Fetch data using SQL Commands

            SQLcommand = Get_Set_Search_2P_SQLcommand(Option1, Option2, SearchKey1, SearchKey2);

            if (SQLcommand.Length != 0)
            {
                Search_Result newResult = new Search_Result(SQLcommand);

                if (newResult.ShowForm == true)
                    newResult.Show();
                else
                {
                    Error.SetError(Set_Search_2P_Button, "Search keys is not exist in your database");
                    return;
                }
                    
            }
            else
            {
                MessageBox.Show("SQL COMMAND STRING IS EMPTY");
            }
            Error.Clear();



        }

        // Select Control to be visible according to the selected Item
        private void Set_S_P1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Choise = Set_S_P1_comboBox.SelectedItem.ToString();
            
            if (Choise == "Diagnose")
            {
                SetK_P1_Diagnosis_comboBox.Visible = true;
                SetK_P1_textBox.Visible = false;
                SetK_P1_DAP_comboBox.Visible = false;
                SetK_P1_Sex_comboBox.Visible = false;
                SetK_P1_RM_comboBox.Visible = false;
            }
            else if (Choise == "Procedures")
            {
                SetK_P1_Diagnosis_comboBox.Visible = false;
                SetK_P1_textBox.Visible = false;
                SetK_P1_DAP_comboBox.Visible = true;
                SetK_P1_Sex_comboBox.Visible = false;
                SetK_P1_RM_comboBox.Visible = false;
            }
            else if (Choise == "Sex")
            {
                SetK_P1_Diagnosis_comboBox.Visible = false;
                SetK_P1_textBox.Visible = false;
                SetK_P1_DAP_comboBox.Visible = false;
                SetK_P1_Sex_comboBox.Visible = true;
                SetK_P1_RM_comboBox.Visible = false;
            }
            else if (Choise == "Relative_marriage")
            {
                SetK_P1_Diagnosis_comboBox.Visible = false;
                SetK_P1_textBox.Visible = false;
                SetK_P1_DAP_comboBox.Visible = false;
                SetK_P1_Sex_comboBox.Visible = false;
                SetK_P1_RM_comboBox.Visible = true;
            }
            else
            {
                SetK_P1_Diagnosis_comboBox.Visible = false;
                SetK_P1_textBox.Visible = true;
                SetK_P1_DAP_comboBox.Visible = false;
                SetK_P1_Sex_comboBox.Visible = false;
                SetK_P1_RM_comboBox.Visible = false;
            }

        }

        // Select Control to be visible according to the selected Item
        private void Set_S_P2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Choise = Set_S_P2_comboBox.SelectedItem.ToString();

            if (Choise == "Diagnose")
            {
                SetK_P2_Diagnosis_comboBox.Visible = true;
                SetK_P2_textBox.Visible = false;
                SetK_P2_DAP_comboBox.Visible = false;
                SetK_P2_Sex_comboBox.Visible = false;
                SetK_P2_RM_comboBox.Visible = false;
            }
            else if (Choise == "Procedures")
            {
                SetK_P2_Diagnosis_comboBox.Visible = false;
                SetK_P2_textBox.Visible = false;
                SetK_P2_DAP_comboBox.Visible = true;
                SetK_P2_Sex_comboBox.Visible = false;
                SetK_P2_RM_comboBox.Visible = false;
            }
            else if (Choise == "Sex")
            {
                SetK_P2_Diagnosis_comboBox.Visible = false;
                SetK_P2_textBox.Visible = false;
                SetK_P2_DAP_comboBox.Visible = false;
                SetK_P2_Sex_comboBox.Visible = true;
                SetK_P2_RM_comboBox.Visible = false;
            }
            else if (Choise == "Relative_marriage")
            {
                SetK_P2_Diagnosis_comboBox.Visible = false;
                SetK_P2_textBox.Visible = false;
                SetK_P2_DAP_comboBox.Visible = false;
                SetK_P2_Sex_comboBox.Visible = false;
                SetK_P2_RM_comboBox.Visible = true;
            }
            else
            {
                SetK_P2_Diagnosis_comboBox.Visible = false;
                SetK_P2_textBox.Visible = true;
                SetK_P2_DAP_comboBox.Visible = false;
                SetK_P2_Sex_comboBox.Visible = false;
                SetK_P2_RM_comboBox.Visible = false;
            }
        }

        // Get the SQL command for 2 parameters search
        private String Get_Set_Search_2P_SQLcommand(String Option1, String Option2, String SearchKey1, String SearchKey2)
        {
            String SQLcommand = "";

            if (Option1 == "Visit_date")
            {
                DateTime Key = DateTime.Parse(SearchKey1);
                String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKey1 = FormatedSearchKey;
            }
            if (Option2 == "Visit_date")
            {
                DateTime Key = DateTime.Parse(SearchKey2);
                String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKey2 = FormatedSearchKey;
            }

            if (TableNames[Option1] == "Patient_info" && TableNames[Option2] == "Patient_info")
            {
                if (Option1 == "Patient_name")
                    SQLcommand = SQLcommand = "SELECT * FROM Patient_info WHERE " + Option1 + " LIKE '%" + SearchKey1 + "%' AND " + Option2 + " = '" + SearchKey2 + "'";
                else if (Option2 == "Patient_name")
                    SQLcommand = SQLcommand = "SELECT * FROM Patient_info WHERE " + Option1 + " = '" + SearchKey1 + "' AND " + Option2 + " LIKE '%" + SearchKey2 + "%' ";
                else
                    SQLcommand = "SELECT * FROM Patient_info WHERE " + Option1 + " = '" + SearchKey1 + "' AND " + Option2 + " = '" + SearchKey2 + "'";
            }
            else if (TableNames[Option1] == "Patient_info" && TableNames[Option2] != "Patient_info")
            {
                if(Option1 == "Patient_name")
                    SQLcommand = "SELECT * FROM Patient_info AS P , " + TableNames[Option2] + " AS D WHERE P.Patient_ID = D.Patient_ID AND P." + Option1+ " LIKE '%" + SearchKey1 + "%' AND  D." + Option2 + " LIKE '%" + SearchKey2 + "%'";
                else
                    SQLcommand = "SELECT * FROM Patient_info AS P , " + TableNames[Option2] + " AS D WHERE P.Patient_ID = D.Patient_ID AND P." + Option1 + " = '" + SearchKey1 + "' AND  D." + Option2 + " LIKE '%" + SearchKey2 + "%'";
            }
            else if (TableNames[Option1] != "Patient_info" && TableNames[Option2] == "Patient_info")
            {
                if(Option2 == "Patient_name")
                    SQLcommand = "SELECT * FROM Patient_info AS D , " + TableNames[Option1] + " AS P WHERE P.Patient_ID = D.Patient_ID AND P." + Option1 + " LIKE '%" + SearchKey1 + "%' AND  D." + Option2 + " LIKE '%" + SearchKey2 + "%'";
                else if (Option1 == "Doctor_name")
                    SQLcommand = "SELECT * FROM Patient_info AS D , " + TableNames[Option1] + " AS P WHERE P.Patient_ID = D.Patient_ID AND P." + Option1 + " LIKE '%" + SearchKey1 + "%' AND  D." + Option2 + " = '" + SearchKey2 + "'";
                else
                    SQLcommand = "SELECT * FROM Patient_info AS D , " + TableNames[Option1] + " AS P WHERE P.Patient_ID = D.Patient_ID AND P." + Option1 + " = '" + SearchKey1 + "' AND  D." + Option2 + " LIKE '%" + SearchKey2 + "%'";
            }
            else
            {
                    SQLcommand = "SELECT * FROM Patient_info AS P , " + TableNames[Option1] + " AS D , " + TableNames[Option2] + " AS DD WHERE P.Patient_ID = D.Patient_ID AND P.Patient_ID = DD.Patient_ID AND D." + Option1 + " LIKE '%" + SearchKey1 + "%' AND  DD." + Option2 + " LIKE '%" + SearchKey2 + "%'";
            }

            return SQLcommand;           
        }

        // Search In ranges
        private void Search_In_Range_button_Click(object sender, EventArgs e)
        {
            String Option = Search_In_Range_comboBox.Text;
            String SearchKeyFROM, SearchKeyTO, SQLcommand;

            #region Data Validation
            if (!ValidateData.ValidateComboBoxItem(Option, new List<String> { "Patient_ID", "Age", "Visit_date", "Birth_date", "DMF", "_dmf", "DEF" }))
            {
                Error.SetError(Search_In_Range_comboBox, "Please");
                return;
            }
            Error.Clear();

            SearchKeyFROM = Search_IR_from_textBox.Text;
            SearchKeyTO = Search_IR_to_textBox.Text;

            if (Option == "Patient_ID" && (!ValidateData.ValidateIDField(SearchKeyFROM) || !ValidateData.ValidateIDField(SearchKeyTO)))
            {
                Error.SetError(SIR_SK_Label, "Enter valid ID");
                return;
            }
            else if (Option == "Age" && (!ValidateData.ValidateAge(SearchKeyFROM) || !ValidateData.ValidateAge(SearchKeyTO)))
            {
                Error.SetError(SIR_SK_Label, "Enter Valid age");
                return;
            }
            else if (Option == "Visit_date" && (!ValidateData.ValidateDate(SearchKeyFROM) || !ValidateData.ValidateDate(SearchKeyTO)))
            {
                MessageBox.Show("Please enter valid Visit date, ex: 1/2/2002 ");
                Error.SetError(SIR_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option == "Birth_date" && (!ValidateData.ValidateDate(SearchKeyFROM) || !ValidateData.ValidateDate(SearchKeyTO)))
            {
                MessageBox.Show("Please enter valid Birth date, ex: 1/2/2002 ");
                Error.SetError(SIR_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option == "DMF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO)))
            {
                MessageBox.Show("Please enter valid DMF values");
                Error.SetError(SIR_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option == "_dmf" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO)))
            {
                MessageBox.Show("Please enter valid dmf values");
                Error.SetError(SIR_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option == "DEF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO)))
            {
                MessageBox.Show("Please enter valid DEF values");
                Error.SetError(SIR_SK_Label, "Enter valid DEF values");
                return;
            }
            Error.Clear();
            #endregion

            /////////////////////////////////////
            // Fetch Data from DB

            SQLcommand = Get_Search_InRange_SQLcommand(Option, SearchKeyFROM, SearchKeyTO);

            if (SQLcommand.Length != 0)
            {
                Search_Result newResult = new Search_Result(SQLcommand);

                if (newResult.ShowForm == true)
                    newResult.Show();
                else
                {
                    Error.SetError(Set_Search_2P_Button, "Search keys is not exist in your database");
                    return;
                }

            }
            else
            {
                MessageBox.Show("SQL COMMAND STRING IS EMPTY");
            }
            Error.Clear();
        }

        // Get SQL commands for search in ranges
        private String Get_Search_InRange_SQLcommand(String Option, String SearchKeyFROM, String SearchKeyTO)
        {
            String sqlCommand = "";
            if(Option == "Visit_date" || Option == "Birth_date")
            {
                DateTime Key = DateTime.Parse(SearchKeyFROM);
                String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyFROM = FormatedSearchKey;

                Key = DateTime.Parse(SearchKeyTO);
                FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyTO = FormatedSearchKey;

            }

            sqlCommand = "SELECT * FROM Patient_info WHERE "+Option+" BETWEEN '" + SearchKeyFROM + "' AND '" + SearchKeyTO + "' "; 

            return sqlCommand;
        }

        // Search in range with two parameters
        private void Search_In_Range_2P_button_Click(object sender, EventArgs e)
        {
            String Option1 = Search_In_Range_2P_P1_comboBox.Text;
            String Option2 = Search_In_Range_2P_P2_comboBox.Text;
            String SearchKeyFROM1, SearchKeyTO1, SearchKeyFROM2, SearchKeyTO2, SQLcommand;

            #region Data Validation
            if (!ValidateData.ValidateComboBoxItem(Option1, new List<String> { "Patient_ID", "Age", "Visit_date", "Birth_date", "DMF", "_dmf", "DEF" }))
            {
                Error.SetError(Search_In_Range_2P_P1_comboBox, "Please");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateComboBoxItem(Option2, new List<String> { "Patient_ID", "Age", "Visit_date", "Birth_date", "DMF", "_dmf", "DEF" }))
            {
                Error.SetError(Search_In_Range_2P_P2_comboBox, "Please");
                return;
            }
            Error.Clear();

            if (Option1 == Option2)
            {
                MessageBox.Show("Please choose different Search Parameters");
                Error.SetError(Search_In_Range_2P_P1_comboBox, "plz");
                Error.SetError(Search_In_Range_2P_P2_comboBox, "plz");
                return;
            }
            Error.Clear();

            ///////////////////////////////////////////////

            SearchKeyFROM1 = Search_IR_2P_P1_from_textBox.Text;
            SearchKeyTO1 = Search_IR_2P_P1_to_textBox.Text;

            if (Option1 == "Patient_ID" && (!ValidateData.ValidateIDField(SearchKeyFROM1) || !ValidateData.ValidateIDField(SearchKeyTO1)))
            {
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid ID");
                return;
            }
            else if (Option1 == "Age" && (!ValidateData.ValidateAge(SearchKeyFROM1) || !ValidateData.ValidateAge(SearchKeyTO1)))
            {
                Error.SetError(SIR_2P_P1_SK_Label, "Enter Valid age");
                return;
            }
            else if (Option1 == "Visit_date" && (!ValidateData.ValidateDate(SearchKeyFROM1) || !ValidateData.ValidateDate(SearchKeyTO1)))
            {
                MessageBox.Show("Please enter valid Visit date, ex: 1/2/2002 ");
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option1 == "Birth_date" && (!ValidateData.ValidateDate(SearchKeyFROM1) || !ValidateData.ValidateDate(SearchKeyTO1)))
            {
                MessageBox.Show("Please enter valid Birth date, ex: 1/2/2002 ");
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option1 == "DMF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM1) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO1)))
            {
                MessageBox.Show("Please enter valid DMF values");
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option1 == "_dmf" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM1) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO1)))
            {
                MessageBox.Show("Please enter valid dmf values");
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option1 == "DEF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM1) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO1)))
            {
                MessageBox.Show("Please enter valid DEF values");
                Error.SetError(SIR_2P_P1_SK_Label, "Enter valid DEF values");
                return;
            }
            Error.Clear();

            // ---------------------------------------------------------
            SearchKeyFROM2 = Search_IR_2P_P2_from_textBox.Text;
            SearchKeyTO2 = Search_IR_2P_P2_to_textBox.Text;

            if (Option2 == "Patient_ID" && (!ValidateData.ValidateIDField(SearchKeyFROM2) || !ValidateData.ValidateIDField(SearchKeyTO2)))
            {
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid ID");
                return;
            }
            else if (Option2 == "Age" && (!ValidateData.ValidateAge(SearchKeyFROM2) || !ValidateData.ValidateAge(SearchKeyTO2)))
            {
                Error.SetError(SIR_2P_P2_SK_Label, "Enter Valid age");
                return;
            }
            else if (Option2 == "Visit_date" && (!ValidateData.ValidateDate(SearchKeyFROM2) || !ValidateData.ValidateDate(SearchKeyTO2)))
            {
                MessageBox.Show("Please enter valid Visit date, ex: 1/2/2002 ");
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option2 == "Birth_date" && (!ValidateData.ValidateDate(SearchKeyFROM2) || !ValidateData.ValidateDate(SearchKeyTO2)))
            {
                MessageBox.Show("Please enter valid Birth date, ex: 1/2/2002 ");
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid visit date");
                return;
            }
            else if (Option2 == "DMF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM2) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO2)))
            {
                MessageBox.Show("Please enter valid DMF values");
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option2 == "_dmf" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM2) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO2)))
            {
                MessageBox.Show("Please enter valid dmf values");
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid DMF values");
                return;
            }
            else if (Option2 == "DEF" && (!ValidateData.ValidateDoubleSearchKEy(SearchKeyFROM2) || !ValidateData.ValidateDoubleSearchKEy(SearchKeyTO2)))
            {
                MessageBox.Show("Please enter valid DEF values");
                Error.SetError(SIR_2P_P2_SK_Label, "Enter valid DEF values");
                return;
            }
            Error.Clear();
            #endregion

            /////////////////////////////////////
            // Fetch Data from DB

            SQLcommand = Get_Search_InRange_2P_SQLcommand(Option1,Option2, SearchKeyFROM1, SearchKeyTO1, SearchKeyFROM2, SearchKeyTO2);

            if (SQLcommand.Length != 0)
            {
                Search_Result newResult = new Search_Result(SQLcommand);

                if (newResult.ShowForm == true)
                    newResult.Show();
                else
                {
                    Error.SetError(Set_Search_2P_Button, "Search keys is not exist in your database");
                    return;
                }

            }
            else
            {
                MessageBox.Show("SQL COMMAND STRING IS EMPTY");
            }
            Error.Clear();
        }

        // Get SQL commands for search In range with two parameters
        private String Get_Search_InRange_2P_SQLcommand(String Option1, String Option2, String SearchKeyFROM1, String SearchKeyTO1, String SearchKeyFROM2, String SearchKeyTO2)
        {
            String sqlCommand = "";

            if (Option1 == "Visit_date" || Option1 == "Birth_date")
            {
                DateTime Key = DateTime.Parse(SearchKeyFROM1);
                String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyFROM1 = FormatedSearchKey;

                Key = DateTime.Parse(SearchKeyTO1);
                FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyTO1 = FormatedSearchKey;

            }

            if (Option2 == "Visit_date" || Option2 == "Birth_date")
            {
                DateTime Key = DateTime.Parse(SearchKeyFROM2);
                String FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyFROM2 = FormatedSearchKey;

                Key = DateTime.Parse(SearchKeyTO2);
                FormatedSearchKey = Key.ToString("yyyy-MM-dd");
                SearchKeyTO2 = FormatedSearchKey;

            }

            sqlCommand = "SELECT * FROM Patient_info WHERE " + Option1 + " BETWEEN '" + SearchKeyFROM1 + "' AND '" + SearchKeyTO1 + "' AND " + Option2 + " BETWEEN '" + SearchKeyFROM2 + "' AND '" + SearchKeyTO2 + "'"; 
            return sqlCommand;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // in the Load event initialize our tracking object
            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker(this);
            _dirtyTracker.MarkAsClean();

        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            // simulate closing the window; if the form is "dirty" (changed since the last save)
            // then prompt the user to save.

            //string message = "Would you like to save changes before closing?";
            //string caption = "Warning";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            //DialogResult result;

            //// Displays the MessageBox.

            //if (_dirtyTracker.IsDirty)
            //{
            //    result = MessageBox.Show(message, caption, buttons);
            //    if (result == DialogResult.Yes)
            //    {
            //        _dirtyTracker.MarkAsClean();

            //        List<Control> list = _dirtyTracker.GetListOfDirtyControls();
                
            //            // create a string list incorporating the names of all currently dirty controls
            //            string msgList = "";
            //            foreach (Control c in list)
            //                msgList += string.Format("\r\n * {0}", c.Name);

            //            string msg = string.Format(
            //                "You left some fields without save:\r\n{0}"
            //                , msgList);

            //            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 
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



        /// <summary>
        /// Generated by mistake :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        private void Set_Search_Diagnosis_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Set_Search_twoP_tabPage_Click(object sender, EventArgs e)
        {

        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

       
       

      
   
    }
}
