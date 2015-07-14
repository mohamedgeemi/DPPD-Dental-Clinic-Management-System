using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Reflection;

namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Add_new_Patient : Form
    {
        Bitmap Patient_Picture;
        List<Bitmap> Patient_Xray_images;
        List<String> Diagnosis, Treatment_plans , XrayImagesNames;
        Double DMF, _dmf, DEF;
        Double D, M, F;
        Double d, m, f;
        Double _D, E, _F;
        List<List<String>> DatesAndProc_table, DiagnosisAndTPs_table;
        DataSourceConnection Con;
        BindingSource BSS;
        DataTable Check;
        Data_Validator ValidateData; 
        ErrorProvider Error;
        bool DiagnosisAndTP_DataValidation, DatesAndProc_DataValidation, NewPatientWasAdded;
        DCEntities DataEntiry;

        private SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
       
        private void Add_new_Patient_Load(object sender, EventArgs e)
        {

            // in the Load event initialize our tracking object
           _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker(this);
           _dirtyTracker.MarkAsClean();

        }
       
        public Add_new_Patient()
        {
            InitializeComponent();
            Patient_Xray_images = new List<Bitmap>();
            Diagnosis = new List<String>();
            Treatment_plans = new List<String>();
            XrayImagesNames = new List<String>();
            Con = new DataSourceConnection();
            BSS = new BindingSource();
            Check = new DataTable();
            ValidateData = new Data_Validator();
            Error = new ErrorProvider();
            DataEntiry = new DCEntities();
            DiagnosisAndTP_DataValidation = false;
            DatesAndProc_DataValidation = false;
            NewPatientWasAdded = false;
            AddnewPatient_saveAndConfirm_button.Visible = false;
            FillComboBoxes();
        }

        // Fill the Comboboxes with Data
        public void FillComboBoxes()
        {
            // Diagnosis and Treatment Plans Grid
            string SqlCommand = "SELECT DISTINCT Diagnose FROM DiagnosisList";
            BSS.DataSource = Con.GetData(SqlCommand);
            Login_Form.DiagList = (DataTable)BSS.DataSource;
            DiagnosisColumn.DataSource = Login_Form.DiagList;
            DiagnosisColumn.DisplayMember = "Diagnose";

            // Dates and Procedures Grid
            SqlCommand = "SELECT DISTINCT Procedures FROM ProcedureList";
            BSS.DataSource = Con.GetData(SqlCommand);
            Login_Form.ProcList = (DataTable) BSS.DataSource;
            Dates_Procedures.DataSource = Login_Form.ProcList;
            Dates_Procedures.DisplayMember = "Procedures";
            
        }

        // Add Patient Photo
        private void AddPatientPhoto_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Patient_Picture = new Bitmap(open.FileName);
                    Patient_Photo_pictureBox.Image = Patient_Picture;
                    Patient_Photo_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed to load Image");
            }
        }

        // Add X-ray images
        private void AddPatientXray_button_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog open = new FolderBrowserDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
     
                    var searchPattern = new Regex(@"$(?<=\.(jpg|gif|bmp|png|jpeg|bpg|tiff|rif))", RegexOptions.IgnoreCase);
                    var files = Directory.GetFiles(open.SelectedPath).Where(f => searchPattern.IsMatch(f));

                    System.IO.FileInfo info;  
                    string fileName; 

     
                    foreach (var image in files)
                    {
                        info = new System.IO.FileInfo(image);
                        fileName = info.Name;
                        XrayImagesNames.Add(fileName);
                        Patient_Xray_images.Add(new Bitmap(image));
                    }
                  
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed to load Images");
            }

        }
  
        // Save Diagnosis and Treatment Plan Data
        private void DATP_SaveAndConfirmButton_Click(object sender, EventArgs e)
        {
            
            DiagnosisAndTPs_table = new List<List<String>>();
            // fill the data in the containers 

            if (string.IsNullOrEmpty(DMF_D_textBox.Text) || string.IsNullOrEmpty(DMF_M_textbox.Text) || string.IsNullOrEmpty(DMF_F_textBox.Text)
                || !Double.TryParse(DMF_D_textBox.Text, out D) || !Double.TryParse(DMF_M_textbox.Text, out M) || !Double.TryParse(DMF_F_textBox.Text, out F))
            {
                MessageBox.Show("Please enter a valid DMF values");
                Error.SetError(DMF_Label, "Please enter a valid DMF values");
                return;
            }
            Error.Clear();
            D = Double.Parse(DMF_D_textBox.Text);
            M = Double.Parse(DMF_M_textbox.Text);
            F = Double.Parse(DMF_F_textBox.Text);

            DMF = D + M + F;

            if (string.IsNullOrEmpty(_dmf_d_textBox.Text) || string.IsNullOrEmpty(_dmf_m_textBox.Text) || string.IsNullOrEmpty(_dmf_f_textBox.Text)
               || !Double.TryParse(_dmf_d_textBox.Text, out d) || !Double.TryParse(_dmf_m_textBox.Text, out m) || !Double.TryParse(_dmf_f_textBox.Text, out f))
            {
                MessageBox.Show("Please enter a valid dmf values");
                Error.SetError(_dmf_label, "Please enter a valid dmf values");
                return;
            }
            Error.Clear();
            d = Double.Parse(_dmf_d_textBox.Text);
            m = Double.Parse(_dmf_m_textBox.Text);
            f = Double.Parse(_dmf_f_textBox.Text);

            _dmf = d + m + f;

            if (string.IsNullOrEmpty(DEF_D_textBox.Text) || string.IsNullOrEmpty(DEF_E_textBox.Text) || string.IsNullOrEmpty(DEF_F_textbox.Text)
               || !Double.TryParse(DEF_D_textBox.Text, out _D) || !Double.TryParse(DEF_E_textBox.Text, out E) || !Double.TryParse(DEF_F_textbox.Text, out _F))
            {
                MessageBox.Show("Please enter a valid DEF values");
                Error.SetError(DEF_Label, "Please enter a valid dmf values");
                return;
            }
            Error.Clear();
            _D = Double.Parse(DEF_D_textBox.Text);
            E = Double.Parse(DEF_E_textBox.Text);
            _F = Double.Parse(DEF_F_textbox.Text);

            DEF = _D + E + _F;
            
         ///////////////////////////////////////////////////////////////

            if (!ValidateData.ValidateEmptyTable(DiagnosisAndTPdataGridView))
            {
                Error.SetError(DiagnosisAndTPdataGridView, "Please fill the table with Data");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateTableData(DiagnosisAndTPdataGridView, 'D'))
                return;
                           
            // Filling the Data
            List<String> CurrentRow;
            foreach (DataGridViewRow row in DiagnosisAndTPdataGridView.Rows)
            {
                CurrentRow = new List<String>();
                if (row.Cells[0].Value == null && row.Cells[1].Value == null )
                    continue;

                for (int i = 0; i < 2; i++)
                    CurrentRow.Add(row.Cells[i].Value.ToString());

                DiagnosisAndTPs_table.Add(CurrentRow);
            }
            DiagnosisAndTP_DataValidation = true;
            MessageBox.Show("The Data of this page was saved successfully :D");
            Add_newPatient_tabControl.SelectedIndex = 2;

            #region Diagnosis And Treatment Plans Validation Naive Method
            /*      

            if (string.IsNullOrEmpty(D10_comboBox.Text))
            {
                MessageBox.Show("Please enter valid Diagnose from the list");
                return;
            }

            if (!string.IsNullOrEmpty(D1_comboBox.Text) && string.IsNullOrEmpty(TP1_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the first Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D1_comboBox.Text)) && !string.IsNullOrEmpty(TP1_textBox.Text))
            {
                MessageBox.Show("Please enter valid Diagnosis for the first Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D2_comboBox.Text) && string.IsNullOrEmpty(TP2_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the Second Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D2_comboBox.Text)  && !string.IsNullOrEmpty(TP2_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnosis for the Second Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D3_comboBox.Text) && string.IsNullOrEmpty(TP3_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the Third Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D3_comboBox.Text) && !string.IsNullOrEmpty(TP3_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnosis for the Third Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D4_comboBox.Text) && string.IsNullOrEmpty(TP4_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the Fourth Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D4_comboBox.Text) && !string.IsNullOrEmpty(TP4_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the Fourth Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D5_comboBox.Text) && string.IsNullOrEmpty(TP5_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the Fifth Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D5_comboBox.Text)  && !string.IsNullOrEmpty(TP5_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the Fifth Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D6_comboBox.Text) && string.IsNullOrEmpty(TP6_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the 6th Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D6_comboBox.Text) && !string.IsNullOrEmpty(TP6_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the 6th Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D7_comboBox.Text) && string.IsNullOrEmpty(TP7_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the 7th Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D7_comboBox.Text) && !string.IsNullOrEmpty(TP7_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the 7th Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D8_comboBox.Text) && string.IsNullOrEmpty(TP8_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the 8th Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D8_comboBox.Text)  && !string.IsNullOrEmpty(TP8_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the 8th Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D9_comboBox.Text) && string.IsNullOrEmpty(TP9_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the 9th Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D9_comboBox.Text) && !string.IsNullOrEmpty(TP9_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the 9th Treatment Plan");
                return;
            }
            if (!string.IsNullOrEmpty(D10_comboBox.Text) && string.IsNullOrEmpty(TP10_textBox.Text))
            {
                MessageBox.Show("Please enter valid Treatment Plan for the 9th Diagnose");
                return;
            }
            if ((string.IsNullOrEmpty(D10_comboBox.Text) && !string.IsNullOrEmpty(TP10_textBox.Text)))
            {
                MessageBox.Show("Please enter valid Diagnose for the 10th Treatment Plan");
                return;
            }

            */

           /* List<String> DListNames  = new List<String>();
            List<String> TListNames = new List<String>();
            foreach (var comboBox in AddDiagnosisAndTP_panel.Controls.OfType<ComboBox>())
            {
                DListNames.Add(comboBox.Name);
            }

            foreach (var textbox in AddDiagnosisAndTP_panel.Controls.OfType<TextBox>())
            {
                TListNames.Add(textbox.Name);
            }
            #region Filling Date
            int x = 5;

            foreach (var comboBox in AddDiagnosisAndTP_panel.Controls.OfType<ComboBox>())
            {
                if(comboBox.Text.Length != 0)
                 Diagnosis.Add(comboBox.Text);
            }
            int index = 0;
            foreach (var textbox in AddDiagnosisAndTP_panel.Controls.OfType<TextBox>())
            {
                index++;
                if (index > 10)
                    break;

                if(textbox.Text.Length != 0)
                    Treatment_plans.Add(textbox.Text);
            }*/

            //if (D1_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D1_comboBox.Text);
            //if (TP1_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP1_textBox.Text);

            //if (D2_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D2_comboBox.Text);
            //if (TP2_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP2_textBox.Text);

            //if (D3_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D3_comboBox.Text);
            //if (TP3_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP3_textBox.Text);

            //if (D4_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D4_comboBox.Text);
            //if (TP4_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP4_textBox.Text);

            //if (D5_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D5_comboBox.Text);
            //if (TP5_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP5_textBox.Text);

            //if (D6_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D6_comboBox.Text);
            //if (TP6_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP6_textBox.Text);

            //if (D7_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D7_comboBox.Text);
            //if (TP7_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP7_textBox.Text);

            //if (D8_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D8_comboBox.Text);
            //if (TP8_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP8_textBox.Text);

            //if (D9_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D9_comboBox.Text);
            //if (TP9_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP9_textBox.Text);

            //if (D10_comboBox.Text.Length != 0)
            //    Diagnosis.Add(D10_comboBox.Text);
            //if (TP10_textBox.Text.Length != 0)
            //    Treatment_plans.Add(TP10_textBox.Text);
            #endregion

        }

        // Save data of Dates and Procedure page
        private void DAP_saveAndConfirm_Button_Click(object sender, EventArgs e)
        {
            DatesAndProc_table = new List<List<String>>();
          
            if (!ValidateData.ValidateEmptyTable(DatesAndProc_dataGridView))
            {
                Error.SetError(DatesAndProc_dataGridView, "Please fill the table with Data");
                return;
            }
            Error.Clear();


            if (!ValidateData.ValidateTableData(DatesAndProc_dataGridView, 'P'))
                return;       


            // Filling the Data
            List<String> CurrentRow;
            foreach (DataGridViewRow row in DatesAndProc_dataGridView.Rows)
            {
                CurrentRow = new List<String>();
                if (row.Cells[0].Value == null && row.Cells[1].Value == null && row.Cells[2].Value == null && row.Cells[3].Value == null && row.Cells[5].Value == null)
                    continue;

                for (int i = 0; i < 6; i++)
                {
                    if (i == 4 && row.Cells[4].Value == null)
                    {
                        CurrentRow.Add(" ");
                        continue;
                    }
                    CurrentRow.Add(row.Cells[i].Value.ToString());
                }
                    

                DatesAndProc_table.Add(CurrentRow);
            }
            DatesAndProc_DataValidation = true;
            MessageBox.Show("The Data of this page was saved successfully :D");
            Add_newPatient_tabControl.SelectedIndex = 0;
        }

        // Main Function
        private void AddnewPatient_saveAndConfirm_button_Click(object sender, EventArgs e)
        {
            int ID = 0, Age;
            String Name, Home_no = "", Mobile_no, Address, Cheif_comp, Medical_Alr, Comments, Sex, RelativeMarriage;
            DateTime VisitDate, BirthDate;
            byte[] PatientPhoto;
            var newPatient = new Patient_info();

            // Re-validate
            if (!DataValidation())
                return;

            try
            {

                ID = Int32.Parse(Patient_ID_textBox.Text);
                Age = Int32.Parse(Age_textBox.Text);
                Name = Patient_name_textBox.Text;
                Home_no = Homenum_textBox.Text;
                Mobile_no = Mobile_textBox.Text;
                Address = Address_textBox.Text;
                Cheif_comp = Chief_Complaint_textBox.Text;
                Medical_Alr = Medical_alert_textBox.Text;
                VisitDate = Convert.ToDateTime(Visit_date_textBox.Text);
                BirthDate = Convert.ToDateTime(DateOfBirth_textBox.Text);
                PatientPhoto = imageToByteArray(Patient_Picture);
                Comments = Comments_textbox.Text;
                Sex = Sex_Combobox.Text;
                RelativeMarriage = Realative_Marriage_comboBox.Text;


              

                // Main Panel
                ///////////////////////////////
                newPatient.Patient_ID = ID;
                newPatient.Patient_name = Name;
                newPatient.Visit_date = VisitDate;
                newPatient.Age = Age;
                newPatient.Home_number = Home_no;
                newPatient.Phone_number = Mobile_no;
                newPatient.Birth_date = BirthDate;
                newPatient.Patient_image = PatientPhoto;
                newPatient.Sex = Sex;
                newPatient.Relative_marriage = RelativeMarriage;
                newPatient.Address = Address;
                newPatient.Cheif_complaint = Cheif_comp;
                newPatient.Medical_alert = Medical_Alr;
                newPatient.D_DMF = D;
                newPatient.M_DMF = M;
                newPatient.F_DMF = F;
                newPatient.DMF = DMF;
                newPatient.dd_dmf = d;
                newPatient.mm_dmf = m;
                newPatient.ff_dmf = f;
                newPatient.C_dmf = _dmf;
                newPatient.D_DEF = _D;
                newPatient.E_DEF = E;
                newPatient.F_DEF = _F;
                newPatient.DEF = DEF;

                if (Comments.Length != 0)
                    newPatient.Comments = Comments;

                ///////////////////////////////////////////
                // Diagnosis and Treatment Plans panel
                //////////////////////////////////////////
                var Dcount = (from o in DataEntiry.Diagnoses select o).Count();
                int Dtemp = Dcount + 1;
                foreach (List<String> row in DiagnosisAndTPs_table)
                {
                    var DiagnosisObject = new Diagnosis();
                    DiagnosisObject.Diagnose_ID = Dtemp;
                    DiagnosisObject.Diagnose = row[0];
                    DiagnosisObject.Treatment_Plan = row[1];

                    newPatient.Diagnoses.Add(DiagnosisObject);
                    Dtemp++;
                }
                /////////////////////////////////////////
                // Patinet's X-ray images
                ////////////////////////////////////////
                // Byte[] XrayImage;

                MemoryStream ms;
                int index = 0;
                var Xcount = (from o in DataEntiry.X_ray_images select o).Count();
                int Xtemp = Xcount + 1;
                foreach (Bitmap img in Patient_Xray_images)
                {

                    var XrayimageObject = new X_ray_images();
                    ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    XrayimageObject.Xray_image = ms.ToArray();
                    XrayimageObject.Image_name = XrayImagesNames[index];
                    XrayimageObject.Xray_images_ID = Xtemp;
                    newPatient.X_ray_images.Add(XrayimageObject);
                    index++;
                    Xtemp++;
                }

                /////////////////////////////////////////
                // Dates And Procedures Panel
                ////////////////////////////////////////
                var DAcount = (from o in DataEntiry.Dates select o).Count();
                int DAtemp = DAcount + 1;
                foreach (List<String> row in DatesAndProc_table)
                {
                    var DatesObject = new Date();

                    DatesObject.Dates_ID = DAtemp;
                    DatesObject.Date1 = Convert.ToDateTime(row[0]);
                    DatesObject.Doctor_name = row[1];
                    DatesObject.Procedures = row[2];
                    DatesObject.Procedure_Comment = row[3];
                    if (row[4].Length != 0)
                        DatesObject.Medication = row[4];
                    DatesObject.Supervisor_signature = row[5];

                    newPatient.Dates.Add(DatesObject);
                    DAtemp++;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please press Check Data Button before Saving");
                return;
            }

            DataEntiry.Patient_info.Add(newPatient);

            try
            {   
                DataEntiry.SaveChanges();
            }
            catch (Exception ex)
            {
                Exception exeption = ex;
                MessageBox.Show("Something wrong with saving the changes in the DBcontext");
                return;
            }

            // Check if exist
            string SqlCommand = "SELECT * FROM Patient_info WHERE Patient_ID = "+ID.ToString()+" AND Home_number = "+ Home_no.ToString()+" ";
            BSS.DataSource = Con.GetData(SqlCommand);
            Check = (DataTable)BSS.DataSource;

           if (Check.Rows.Count != 0 )             
            {
                MessageBox.Show("The patient was added successfully");
                NewPatientWasAdded = true;
                Add_new_Patient Reset = new Add_new_Patient();
                this.Close();
                this.Dispose();
                Reset.Show();
            }
            else
                MessageBox.Show("Failed to add the patient file");
        }

        // Data Validation
        private void Check_Data_button_Click(object sender, EventArgs e)
        {

            if (!DataValidation())
                return;

            if (DiagnosisAndTP_DataValidation == false && DatesAndProc_DataValidation == false)
            {
                MessageBox.Show("Please fill The Diagnosis and Treatment Plans && Dates Pages");
                Add_newPatient_tabControl.SelectedIndex = 1;
                return;
            }
            if (DiagnosisAndTP_DataValidation == false)
            {
                MessageBox.Show("Please fill The Dinagnosis And Treatment Plans Page");
                Add_newPatient_tabControl.SelectedIndex = 1;
                return;
            }

            if (DatesAndProc_DataValidation == false)
            {
                MessageBox.Show("Please fill The Dates and Procedures table Page");
                Add_newPatient_tabControl.SelectedIndex = 2;
                return;
            }

            /// Finalyyyyyyy :D
            MessageBox.Show("Your Data is valid and ready to be added to the database\nPlease press Confirm And Save Button");
            AddnewPatient_saveAndConfirm_button.Visible = true;

            #region Validation Native method

            /*  Data_Validator Validate = new Data_Validator(Patient_ID_textBox.Text, Age_textBox.Text, Sex_Combobox.Text, DateOfBirth_textBox.Text,
           Patient_name_textBox.Text,Visit_date_textBox.Text, Homenum_textBox.Text, Mobile_textBox.Text, Address_textBox.Text,
           Realative_Marriage_comboBox.Text, Chief_Complaint_textBox.Text, Medical_alert_textBox.Text, Patient_Photo_pictureBox,
           Patient_Xray_images, DiagnosisAndTP_DataValidation, DatesAndProc_DataValidation);*/
            //ValidationResult = Validate.Validation();
            //bool ValidationResult = false;

            //if (ValidationResult == false)
            //{
            //    Add_newPatient_tabControl.SelectedIndex =  Validate.GOTO;
            //    Validate = null;
            //    return;
            //}
            //else
            //{
            //    /// Finalyyyyyyy :D
            //    MessageBox.Show("Your Data is valid and ready to be added to the database, Please press Confirm And Save Button");
            //    AddnewPatient_saveAndConfirm_button.Visible = true;
            //}


            //int ID, Age;
            //DateTime VisitDate, BirthDate;

            //#region Main Panel Validation

            //// ID Validation
            //if (!int.TryParse(Patient_ID_textBox.Text, out ID) || string.IsNullOrEmpty(Patient_ID_textBox.Text))
            //{
                
            //    MessageBox.Show("Please enter a valid ID");
            //    return;
            //}
          
         
            //var Check = Login_Form.context.Patient_info;
            //ID = Int32.Parse(Patient_ID_textBox.Text);
            //if (Check.Any(I => I.Patient_ID == ID))
            //{

            //    MessageBox.Show("This ID is Already Exist in the database");
            //    return;
            //}

            //// Age Validation
          
            //if (!int.TryParse(Age_textBox.Text, out Age) || string.IsNullOrEmpty(Age_textBox.Text))
            //{

            //    MessageBox.Show("Please enter a valid Age");
            //    return;
            //}

            //// Sex Validation
            //if(string.IsNullOrEmpty(Sex_Combobox.Text) || (Sex_Combobox.Text != "Male" && Sex_Combobox.Text != "Female"))
            //{
            //    MessageBox.Show("Please enter a valid Sex");
            //    return;
            //}


            //// Date Of birth validation 
            //if (string.IsNullOrEmpty(DateOfBirth_textBox.Text) || !DateTime.TryParse(DateOfBirth_textBox.Text, out BirthDate))
            //{
            //    MessageBox.Show("Please enter a valid Date of Birth, ex: 1/1/2016");
            //    return;
            //}


            //// Name Validation
            //if (string.IsNullOrEmpty(Patient_name_textBox.Text) || !Patient_name_textBox.Text.All(C=> Char.IsLetter(C) || Char.IsWhiteSpace(C)) )
            //{
            //    MessageBox.Show("Please enter valid Name");
            //    return;
            //}

            //// Visit Date validation
            //if (string.IsNullOrEmpty(Visit_date_textBox.Text) || !DateTime.TryParse(Visit_date_textBox.Text, out VisitDate))
            //{
            //    MessageBox.Show("Please enter a valid Visit Date, ex: 2/2/2016");
            //    return;
            //}

            //// Home number validation
            //if (string.IsNullOrEmpty(Homenum_textBox.Text) || !Homenum_textBox.Text.All(C => Char.IsDigit(C)))
            //{
            //    MessageBox.Show("Please enter a valid Home number");
            //    return;
            //}

            //// Mobile number validation
            //if (string.IsNullOrEmpty(Mobile_textBox.Text) || !Mobile_textBox.Text.All(C => Char.IsDigit(C)))
            //{
            //    MessageBox.Show("Please enter a valid Mobile number");
            //    return;
            //}

            //// Relative Validation
            //if (string.IsNullOrEmpty(Realative_Marriage_comboBox.Text) || (Realative_Marriage_comboBox.Text != "Yes" && Realative_Marriage_comboBox.Text != "No"))
            //{
            //    MessageBox.Show("Please enter a valid Relative Marriage");
            //    return;
            //}

            //// Cheif Complaint validation
            //if (string.IsNullOrEmpty(Chief_Complaint_textBox.Text))
            //{
            //    MessageBox.Show("Please enter a valid Chief Complaint");
            //    return;
            //}

            //// Medical validation
            //if (string.IsNullOrEmpty(Medical_alert_textBox.Text))
            //{
            //    MessageBox.Show("Please enter a valid Medical Alert");
            //    return;
            //}

            //// Address validation
            //if (string.IsNullOrEmpty(Address_textBox.Text))
            //{
            //    MessageBox.Show("Please enter a valid Address");
            //    return;
            //}

            //// Patient Photo validation
            //if (Patient_Photo_pictureBox == null || Patient_Photo_pictureBox.Image == null)
            //{
            //    MessageBox.Show("Please attach Patient Photo");
            //    return;
 
            //}

            //// Xray images validation
            //if (Patient_Xray_images.Any() == false)
            //{
            //    MessageBox.Show("Please attach Patient's X-ray images");
            //    return;
            //}

            //#endregion

            //if (DiagnosisAndTP_DataValidation == false && DatesAndProc_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Diagnosis and Treatment Plans && Dates Table");
            //    return;
            //}
            //if (DiagnosisAndTP_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Dinagnosis And Treatment Plans");
            //    return;
            //}

            //if (DatesAndProc_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Dates and Procedures table");
            //    return;
            //}
            
            ///// Finalyyyyyyy :D
            //MessageBox.Show("Your Data is valid and ready to be added to the database, Please press Confirm And Save Button");
            #endregion

        }
        private bool DataValidation()
        {
            if (!ValidateData.ValidateID(Patient_ID_textBox.Text))
            {
                Error.SetError(Patient_ID_textBox, "Please enter valid ID");
                return false;
            }

            Error.Clear();

            if (!ValidateData.ValidateAge(Age_textBox.Text))
            {
                Error.SetError(Age_textBox, "Please enter valid Age");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateSex(Sex_Combobox.Text))
            {

                Error.SetError(Sex_Combobox, "Please enter valid Sex");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateDate(DateOfBirth_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Date of Birth, ex: 1/1/2016");
                Error.SetError(DateOfBirth_textBox, "Please enter valid Birth date");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateDate(Visit_date_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Visit of Birth, ex: 1/1/2016");
                Error.SetError(Visit_date_textBox, "Please enter valid Visit date");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateName(Patient_name_textBox.Text))
            {
                Error.SetError(Patient_name_textBox, "Please enter valid Name");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateNumber(Homenum_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Home number");
                Error.SetError(Homenum_textBox, "Please enter valid Home Number");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateNumber(Mobile_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Mobile number");
                Error.SetError(Mobile_textBox, "Please enter valid Mobile Number");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateRelativeMarriage(Realative_Marriage_comboBox.Text))
            {
                Error.SetError(Realative_Marriage_comboBox, "Please enter valid Relative Marriage");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateNullField(Address_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Address");
                Error.SetError(Address_textBox, "Please enter valid Address");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateNullField(Chief_Complaint_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Chief Complaint");
                Error.SetError(Chief_Complaint_textBox, "Please enter valid Chief Complaint");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateNullField(Medical_alert_textBox.Text))
            {
                MessageBox.Show("Please enter a valid Medical Complaint");
                Error.SetError(Medical_alert_textBox, "Please enter valid Medical Alert");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidatePatientImage(Patient_Photo_pictureBox))
            {
                Error.SetError(AddPatientPhoto_button, "Please enter valid Patient Photo");
                return false;
            }
            Error.Clear();

            if (!ValidateData.ValidateXrayImage(Patient_Xray_images))
            {
                Error.SetError(AddPatientXray_button, "Please attach Patient X-rays");
                return false;
            }
            Error.Clear();

            return true;
 
        }

        // Update Diagnosis List
        private void Add_new_Diagnose_Click(object sender, EventArgs e)
        {
            String newItem;
            DiagnosisList DiagListObject;
            newItem = Interaction.InputBox(" Add new Item to Diagnosis List\n NOTE THAT: Enter one Diagnose at a time", "Add new Diagnose");

            if ( Login_Form.DiagList.AsEnumerable().Any(row => newItem == row.Field<String>("Diagnose")) )
            {
                MessageBox.Show("This Item is already exist in your List");
                Error.SetError(Add_new_Diagnose,"plzzz");
                return;
            }

            DataTable Update = new DataTable();
            Update = Login_Form.DiagList;

            if (!string.IsNullOrEmpty(newItem))
            {
                Login_Form.DiagnosisList.Add(newItem);
                var newRow = Update.NewRow();
                newRow[0] = newItem;
                Update.Rows.InsertAt(newRow, DiagnosisColumn.Items.Count);
                UpdateDiagDateSource(Update);
                Login_Form.DiagList = Update;
                //////////////////////////////////

                if (!DataEntiry.DiagnosisLists.Any(i => i.Diagnose == newItem))
                {
                    DiagListObject = new DiagnosisList();
                    DiagListObject.Diagnose = newItem;
                    DiagListObject.ID = Login_Form.DiagList.Rows.Count + 1;
                    Login_Form.context.DiagnosisLists.Add(DiagListObject);
                    Login_Form.context.SaveChanges();
                }
            }


            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("You didn't enter new item");
                return;
            }

            if (!string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("The new Diagnose was added successfully");
            }

        }

        // Update Procedures List
        private void Add_new_Procedure_Click_1(object sender, EventArgs e)
        {
            String newItem;
            ProcedureList ProceListObject;

            newItem = Interaction.InputBox(" Add new Item to Procedure List\n NOTE THAT: Enter one Procedure at a time", "Add new Procedure");

            if (Login_Form.ProcList.AsEnumerable().Any(row => newItem == row.Field<String>("Procedures")))
            {
                MessageBox.Show("This Item is already exist in your List");
                Error.SetError(Add_new_Diagnose, "plzzz");
                return;
            }

            DataTable Update = new DataTable();
            Update = Login_Form.ProcList;
            if (!string.IsNullOrEmpty(newItem))
            {
                var newRow = Update.NewRow();
                newRow[0] = newItem;
                Update.Rows.InsertAt(newRow, Dates_Procedures.Items.Count);
                UpdateProcDateSource(Update);
                Login_Form.ProcList = Update;
                Login_Form.ProceduresList.Add(newItem);
                //////////

                if (!DataEntiry.ProcedureLists.Any(i => i.Procedures == newItem))
                {
                    ProceListObject = new ProcedureList();
                    ProceListObject.Procedures = newItem;
                    ProceListObject.ID = Login_Form.ProcList.Rows.Count + 1;
                    Login_Form.context.ProcedureLists.Add(ProceListObject);
                    Login_Form.context.SaveChanges();
                }
                
            }


            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("You didn't enter new item");
                return;

            }

            if (!string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("The new procedure was added successfully");
            }

        }

        public void UpdateProcDateSource(DataTable dt)
        {
            Dates_Procedures.DataSource = null;
            Dates_Procedures.DataSource = dt;
            Dates_Procedures.DisplayMember = "Procedures";
        }
        public void UpdateDiagDateSource(DataTable dt)
        {

            DiagnosisColumn.DataSource = null;
            DiagnosisColumn.DataSource = new DataView(dt);
            DiagnosisColumn.DisplayMember = "Diagnose";
        }
        private void DiagnosisAndTPdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddnewPatient_saveAndConfirm_button.Visible = false;
            DiagnosisAndTP_DataValidation = false;
        }

        private void DatesAndProc_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddnewPatient_saveAndConfirm_button.Visible = false;
            DatesAndProc_DataValidation = false;
        }

        /// <summary>
        /// Helper Functions
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
      
        private static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Add_new_Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            // simulate closing the window; if the form is "dirty" (changed since the last save)
            // then prompt the user to save.

            string message = "Would you like to save changes before closing?";
            string caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result;

            // Displays the MessageBox.


            if (_dirtyTracker.IsDirty && NewPatientWasAdded == false)
            {
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    _dirtyTracker.MarkAsClean();
                    MessageBox.Show("Please Check Data and Press Save and Confirm Button"
                        , "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }

        }

        private void Dirty_Control_List_Click(object sender, EventArgs e)
        {
            // list the controls that are currently dirty
            List<Control> list = _dirtyTracker.GetListOfDirtyControls();
            if (list.Count > 0)
            {
                // create a string list incorporating the names of all currently dirty controls
                string msgList = "";
                foreach (Control c in list)
                    msgList += string.Format("\r\n * {0}", c.Name);

                string msg = string.Format(
                    "The following controls are dirty (have values different than the most recent save):\r\n{0}"
                    , msgList);

                MessageBox.Show(msg, "Dirty Controls", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("None of the controls are currently 'dirty' (changed since the last save)"
                    , "All Clean", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
      



        /// <summary>
        /// ///// Generated by mistake :D
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDiagnosisAndTP_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void DMF_D_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DMF_M_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void DMF_F_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void _dmf_d_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void _dmf_m_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void _dmf_f_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void DEF_D_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void DEF_F_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DEF_E_textBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void DatesAndProc_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void D1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void D4_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DAP_back_button_Click(object sender, EventArgs e)
        {

        }

       

       

      

       

    }
}
