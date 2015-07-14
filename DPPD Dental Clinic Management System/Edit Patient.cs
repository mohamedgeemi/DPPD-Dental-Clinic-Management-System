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
    public partial class Edit_Patient : Form
    {
        int EPatient_ID, EAge, XrayViewerImageIndex;
        String EPatient_Name, EHome_no, EMobile_no, EAddress, ECheif_comp, EMedical_Alr, EComments, ESex, ERelativeMarriage;
        DateTime EVisitDate, EBirthDate;
        byte[] EPatientPhoto;
        Double ED, EM, EF;
        Double Ed, Em, Ef;
        Double E_D, EE, E_F;
        Double DMF, _dmf, DEF;
        Double D, M, F;
        Double d, m, f;
        Double _D, E, _F;
        List<List<String>> EDiagnosisAndTPs_table, EDatesAndProc_table, Updated_DiagnosisAndTPs_table, Updated_DatesAndProc_table;
        List<Bitmap> Patient_Xray_images,  Xray_images;
        List<String> XrayImagesNames, XrayimagesNames;
        DataSourceConnection con;
        BindingSource BS;
        Data_Validator ValidateData;
        ErrorProvider Error;
        Patient_Profile_Viewer EditedPatient;
        bool DiagnosisAndTPsIsChanged, DatesAndProceduresIsChanged, AddNewPatientSaveAndConfirmIsPressed;
        bool DiagnosisAndTPsIsPressed, DatesAndProceduresIsPressed , AddnewXrayImagesIsPressed;
        DCEntities DataUpdater;
        Bitmap Profile_Picture;
        private SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        Patient_info Patient;
        int ID;

        public Edit_Patient(int Patient_ID, int Age, String Patient_Name, String Home_no, String Mobile_no, String Address, String Cheif_comp, String Medical_Alr,
            String Comments, String Sex, String RelativeMarriage, DateTime VisitDate, DateTime BirthDate, byte[] PatientPhoto, List<Bitmap> xray_images, List<String> xrayimagesNames,
            Double D, Double M, Double F, Double d, Double m, Double f, Double _D, Double E, Double _F, List<List<String>> DiagnosisAndTPs_table, List<List<String>> DatesAndProc_table)
        {
            InitializeComponent();
            EPatient_ID = Patient_ID;
            EAge = Age;
            EPatient_Name = Patient_Name;
            EHome_no = Home_no;
            EMobile_no = Mobile_no;
            EAddress = Address;
            ECheif_comp = Cheif_comp;
            EMedical_Alr = Medical_Alr;
            EComments = Comments;
            ESex = Sex;
            ERelativeMarriage = RelativeMarriage;
            EVisitDate = VisitDate;
            EBirthDate = BirthDate;
            EPatientPhoto = PatientPhoto;
            Xray_images = xray_images;
            XrayimagesNames = xrayimagesNames;
            ED = D;
            EM = M;
            EF = F;
            Ed = d;
            Em = m;
            Ef = f;
            E_D = _D;
            EE = E;
            E_F = _F;
            ID = EPatient_ID;
            this.Name = "Edit " + EPatient_Name + " Profile";
            EDiagnosisAndTPs_table = DiagnosisAndTPs_table;
            EDatesAndProc_table = DatesAndProc_table;
            Patient_Xray_images = new List<Bitmap>();
            XrayImagesNames = new List<String>();
            con = new DataSourceConnection();
            BS = new BindingSource();
            ValidateData = new Data_Validator();
            Error = new ErrorProvider();
            DataUpdater = new DCEntities();
            Patient = new Patient_info();
            Updated_DiagnosisAndTPs_table = new List<List<String>>();
            Updated_DatesAndProc_table = new List<List<String>>();
            DiagnosisAndTPsIsChanged = false;
            DatesAndProceduresIsChanged = false;
            DiagnosisAndTPsIsPressed = false;
            DatesAndProceduresIsPressed = false;
            AddnewXrayImagesIsPressed = false;
            AddnewPatient_saveAndConfirm_button.Visible = false;
            AddNewPatientSaveAndConfirmIsPressed = false;
            XrayViewerImageIndex = 0;
            IntializeComboBoxes();
            FillFormData();
        }

        // Edit from load
        private void Edit_Patient_Load(object sender, EventArgs e)
        {
            // in the Load event initialize our tracking object
            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker(this);
            _dirtyTracker.MarkAsClean();
        }

        // Intialize Diagnosis and Dates Comboboxes
        private void IntializeComboBoxes()
        {
            string SqlCommand = "SELECT DISTINCT Diagnose FROM DiagnosisList";
            BS.DataSource = con.GetData(SqlCommand);

            if (Login_Form.DiagList.Rows.Count != 0)
                DiagnosisColumn.DataSource = Login_Form.DiagList;
            else
                DiagnosisColumn.DataSource = BS.DataSource;
            DiagnosisColumn.DisplayMember = "Diagnose";

            SqlCommand = "SELECT DISTINCT Procedures FROM ProcedureList";
            BS.DataSource = con.GetData(SqlCommand);
            if (Login_Form.ProcList.Rows.Count != 0)
                Dates_Procedures.DataSource = Login_Form.ProcList;
            else
                Dates_Procedures.DataSource = BS.DataSource;
            Dates_Procedures.DisplayMember = "Procedures";
        }

        // Fill data in the form
        private void FillFormData()
        {
            FillBasicInfo();
            ViewXrayImages();
            FillDiagnosisAndTPs();
            FillDatesAndProcedures();
        }

        // Fill the basic info
        private void FillBasicInfo()
        {
            Patient_ID_textBox.Text = EPatient_ID.ToString();
            Age_textBox.Text = EAge.ToString();
            Sex_Combobox.Text = ESex;
            Patient_name_textBox.Text = EPatient_Name;
            Realative_Marriage_comboBox.Text = ERelativeMarriage;
            Visit_date_textBox.Text = EVisitDate.ToShortDateString();
            DateOfBirth_textBox.Text = EBirthDate.ToShortDateString();
            Address_textBox.Text = EAddress;
            Chief_Complaint_textBox.Text = ECheif_comp;
            Medical_alert_textBox.Text = EMedical_Alr;
            Comments_textbox.Text = EComments;
            Homenum_textBox.Text = EHome_no;
            Mobile_textBox.Text = EMobile_no;
            Patient_Photo_pictureBox.Image = byteArrayToImage(EPatientPhoto);
            Patient_Photo_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // View Patient Xrays
        private void ViewXrayImages()
        {
            if (Xray_images.Count != 0)
            {
                XrayViewer_pictureBox.Image = Xray_images[XrayViewerImageIndex];
                XrayViewer_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                X_ray_image_index.Text = Convert.ToString(XrayViewerImageIndex + 1);
                X_ray_image_Name.Text = XrayimagesNames[XrayViewerImageIndex];
            }
        }

        // Photo Viewer Previous
        private void Photo_viewer_Preivous_button_Click_1(object sender, EventArgs e)
        {
            if (Xray_images.Count != 0)
            {
                XrayViewerImageIndex -= 1;

                if (XrayViewerImageIndex < 0)
                    XrayViewerImageIndex = Xray_images.Count - 1;

                XrayViewer_pictureBox.Image = Xray_images[XrayViewerImageIndex];
                X_ray_image_index.Text = Convert.ToString(XrayViewerImageIndex + 1);
                X_ray_image_Name.Text = XrayimagesNames[XrayViewerImageIndex];
            }

        }

        // Photo Viewer Next
        private void Photo_Viewer_Next_button_Click_1(object sender, EventArgs e)
        {
            if (Xray_images.Count != 0)
            {
                XrayViewerImageIndex += 1;

                if (XrayViewerImageIndex > Xray_images.Count - 1)
                {
                    XrayViewerImageIndex = 0;
                }

                XrayViewer_pictureBox.Image = Xray_images[XrayViewerImageIndex];
                X_ray_image_index.Text = Convert.ToString(XrayViewerImageIndex + 1);
                X_ray_image_Name.Text = XrayimagesNames[XrayViewerImageIndex];
            }

        }

        // Delete this Xray
        private void DeleteThisXray_Button_Click(object sender, EventArgs e)
        {
            if (Xray_images.Count != 1)
            {
                string message = "Are you sure you want to delete this X-ray?";
                string caption = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon Icon = MessageBoxIcon.Warning;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons, Icon);
                if (result == DialogResult.Yes)
                {
                    var Query = from P in DataUpdater.X_ray_images.Where(P => P.Patient_ID == ID) select P;

                    int index = 0;
                    foreach (var item in Query)
                    {
                        if (index == XrayViewerImageIndex)
                        {
                            DataUpdater.X_ray_images.Remove(item);
                            Xray_images.RemoveAt(XrayViewerImageIndex);
                            XrayViewerImageIndex--;
                            break;
                        }
                        index++;
                    }

                    try
                    {
                        DataUpdater.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to delete the Xray");
                        return;
                    }

                    MessageBox.Show("The Xray was deleted");
                    ValidateData.ReorderXray_table();
                }
            }
            else
                MessageBox.Show("The X-ray Images field can't be empty\nPlease add another photo/s then delete this.");
        }   

        // Fill Diagnosis and Treatment Plans page
        private void FillDiagnosisAndTPs()
        {
            DMF_D_textBox.Text = ED.ToString();
            DMF_M_textbox.Text = EM.ToString();
            DMF_F_textBox.Text = EF.ToString();
            //------------------------------
            _dmf_d_textBox.Text = Ed.ToString();
            _dmf_m_textBox.Text = Em.ToString();
            _dmf_f_textBox.Text = Ef.ToString();
            //------------------------------
            DEF_D_textBox.Text = E_D.ToString();
            DEF_E_textBox.Text = EE.ToString();
            DEF_F_textbox.Text = E_F.ToString();
            //-----------------------------
            int i = 0;
            List<String> row;
            DiagnosisAndTPdataGridView.RowCount = 100;

           foreach(DataGridViewRow G_row in DiagnosisAndTPdataGridView.Rows)
            {
                if ( i >= EDiagnosisAndTPs_table.Count)
                    break;
      
                row = new List<String>();
                row = EDiagnosisAndTPs_table[i];
                G_row.Cells["DiagnosisColumn"].Value = row[0];
                G_row.Cells["TreatmentPlansColumn"].Value = row[1];          
                i++;
            }
 
        }

        // Fill Dates and Procedures page 
        private void FillDatesAndProcedures()
        {
            int i = 0;
            List<String> row;
            DatesAndProc_dataGridView.RowCount = 100;

            foreach (DataGridViewRow G_row in DatesAndProc_dataGridView.Rows)
            {
                if (i >= EDatesAndProc_table.Count)
                    break;

                row = new List<String>();
                row = EDatesAndProc_table[i];
                G_row.Cells[0].Value = row[0];
                G_row.Cells[1].Value = row[1];
                G_row.Cells["Dates_Procedures"].Value = row[2];
                G_row.Cells[3].Value = row[3];
                G_row.Cells[4].Value = row[4];
                G_row.Cells[5].Value = row[5];
                i++;
            }
 
        }
        
        // Edit form close event
        private void Edit_Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            // simulate closing the window; if the form is "dirty" (changed since the last save)
            // then prompt the user to save.

            string message = "Would you like to save changes before closing?";
            string caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result;

            // Displays the MessageBox.


            if (_dirtyTracker.IsDirty && !AddNewPatientSaveAndConfirmIsPressed)
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
                    EditedPatient = new Patient_Profile_Viewer(ID);
                    EditedPatient.Show();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                EditedPatient = new Patient_Profile_Viewer(ID);
                EditedPatient.Show();
            }

        }

        // Dirty list 
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

        // Data validation
        private void Check_Data_button_Click(object sender, EventArgs e)
        {

            if (!DataValidation())
                return;
           
            /// Finalyyyyyyy :D
            MessageBox.Show("Your Data is valid and ready to be added to the database\nPlease press Confirm And Save Button");
            AddnewPatient_saveAndConfirm_button.Visible = true;

            //if (DiagnosisAndTP_DataValidation == false && DatesAndProc_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Diagnosis and Treatment Plans && Dates Table");
            //    Add_newPatient_tabControl.SelectedIndex = 1;
            //    return;
            //}
            //if (DiagnosisAndTP_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Dinagnosis And Treatment Plans");
            //    Add_newPatient_tabControl.SelectedIndex = 1;
            //    return;
            //}

            //if (DatesAndProc_DataValidation == false)
            //{
            //    MessageBox.Show("Please fill The Dates and Procedures table");
            //    Add_newPatient_tabControl.SelectedIndex = 2;
            //    return;
            //}

        }
        private bool DataValidation()
        {
            List<Control> ChangedControls = _dirtyTracker.GetListOfDirtyControls();

            if (ChangedControls.Contains(Patient_ID_textBox))
            {

                if (!ValidateData.ValidateID(Patient_ID_textBox.Text))
                {
                    Error.SetError(Patient_ID_textBox, "Please enter valid ID");
                    return false;
                }
            }

            Error.Clear();

            if (ChangedControls.Contains(Age_textBox))
            {

                if (!ValidateData.ValidateAge(Age_textBox.Text))
                {
                    Error.SetError(Age_textBox, "Please enter valid Age");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Sex_Combobox))
            {

                if (!ValidateData.ValidateSex(Sex_Combobox.Text))
                {

                    Error.SetError(Sex_Combobox, "Please enter valid Sex");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(DateOfBirth_textBox))
            {

                if (!ValidateData.ValidateDate(DateOfBirth_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Date of Birth, ex: 1/1/2016");
                    Error.SetError(DateOfBirth_textBox, "Please enter valid Birth date");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Visit_date_textBox))
            {
                if (!ValidateData.ValidateDate(Visit_date_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Visit of Birth, ex: 1/1/2016");
                    Error.SetError(Visit_date_textBox, "Please enter valid Visit date");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Patient_name_textBox))
            {
                if (!ValidateData.ValidateName(Patient_name_textBox.Text))
                {
                    Error.SetError(Patient_name_textBox, "Please enter valid Name");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Homenum_textBox))
            {
                if (!ValidateData.ValidateNumber(Homenum_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Home number");
                    Error.SetError(Homenum_textBox, "Please enter valid Home Number");
                    return false;
                }
            }

            Error.Clear();

            if (ChangedControls.Contains(Mobile_textBox))
            {
                if (!ValidateData.ValidateNumber(Mobile_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Mobile number");
                    Error.SetError(Mobile_textBox, "Please enter valid Mobile Number");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Realative_Marriage_comboBox))
            {

                if (!ValidateData.ValidateRelativeMarriage(Realative_Marriage_comboBox.Text))
                {
                    Error.SetError(Realative_Marriage_comboBox, "Please enter valid Relative Marriage");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Address_textBox))
            {
                if (!ValidateData.ValidateNullField(Address_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Address");
                    Error.SetError(Address_textBox, "Please enter valid Address");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Chief_Complaint_textBox))
            {
                if (!ValidateData.ValidateNullField(Chief_Complaint_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Chief Complaint");
                    Error.SetError(Chief_Complaint_textBox, "Please enter valid Chief Complaint");
                    return false;
                }
            }
            Error.Clear();

            if (ChangedControls.Contains(Medical_alert_textBox))
            {
                if (!ValidateData.ValidateNullField(Medical_alert_textBox.Text))
                {
                    MessageBox.Show("Please enter a valid Medical Complaint");
                    Error.SetError(Medical_alert_textBox, "Please enter valid Medical Alert");
                    return false;
                }
            }
            Error.Clear();

            if (!ValidateData.ValidatePatientImage(Patient_Photo_pictureBox))
            {
                Error.SetError(AddPatientPhoto_button, "Please enter valid Patient Photo");
                return false;
            }
            Error.Clear();

            if (ChangedControls.Contains(DMF_D_textBox) || ChangedControls.Contains(DMF_M_textbox) || ChangedControls.Contains(DMF_F_textBox))
            {
                if (string.IsNullOrEmpty(DMF_D_textBox.Text) || string.IsNullOrEmpty(DMF_M_textbox.Text) || string.IsNullOrEmpty(DMF_F_textBox.Text)
                    || !Double.TryParse(DMF_D_textBox.Text, out D) || !Double.TryParse(DMF_M_textbox.Text, out M) || !Double.TryParse(DMF_F_textBox.Text, out F))
                {
                    MessageBox.Show("Please enter a valid DMF values");
                    Error.SetError(DMF_Label, "Please enter a valid DMF values");
                    return false;
                }
            }

            Error.Clear();



            if (ChangedControls.Contains(_dmf_d_textBox) || ChangedControls.Contains(_dmf_m_textBox) || ChangedControls.Contains(_dmf_f_textBox))
            {

                if (string.IsNullOrEmpty(_dmf_d_textBox.Text) || string.IsNullOrEmpty(_dmf_m_textBox.Text) || string.IsNullOrEmpty(_dmf_f_textBox.Text)
                   || !Double.TryParse(_dmf_d_textBox.Text, out d) || !Double.TryParse(_dmf_m_textBox.Text, out m) || !Double.TryParse(_dmf_f_textBox.Text, out f))
                {
                    MessageBox.Show("Please enter a valid dmf values");
                    Error.SetError(_dmf_label, "Please enter a valid dmf values");
                    return false;
                }
            }

            Error.Clear();



            if (ChangedControls.Contains(DEF_D_textBox) || ChangedControls.Contains(DEF_E_textBox) || ChangedControls.Contains(DEF_F_textbox))
            {

                if (string.IsNullOrEmpty(DEF_D_textBox.Text) || string.IsNullOrEmpty(DEF_E_textBox.Text) || string.IsNullOrEmpty(DEF_F_textbox.Text)
                   || !Double.TryParse(DEF_D_textBox.Text, out _D) || !Double.TryParse(DEF_E_textBox.Text, out E) || !Double.TryParse(DEF_F_textbox.Text, out _F))
                {
                    MessageBox.Show("Please enter a valid DEF values");
                    Error.SetError(DEF_Label, "Please enter a valid dmf values");
                    return false;
                }
            }

            Error.Clear();

            return true;
        }

        // Update diagnosis list
        private void Add_new_Diagnose_Click(object sender, EventArgs e)
        {
            String newItem;
            DiagnosisList DiagListObject;
            newItem = Interaction.InputBox(" Add new Item to Diagnosis List\n NOTE THAT: Enter one Diagnose at a time", "Add new Diagnose");

            if (Login_Form.DiagList.AsEnumerable().Any(row => newItem == row.Field<String>("Diagnose")))
            {
                MessageBox.Show("This Item is already exist in your List");
                Error.SetError(Add_new_Diagnose, "plzzz");
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

                if (!DataUpdater.DiagnosisLists.Any(i => i.Diagnose == newItem))
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

        // Update data sources of lists
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

        // Update procedure list
        private void Add_new_Procedure_Click(object sender, EventArgs e)
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

                if (!DataUpdater.ProcedureLists.Any(i => i.Procedures == newItem))
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

        // Update profile photo
        private void AddPatientPhoto_button_Click(object sender, EventArgs e)
        {
            Bitmap PP = (Bitmap) byteArrayToImage(EPatientPhoto);
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    PP = new Bitmap(open.FileName);
                    Patient_Photo_pictureBox.Image = PP;
                    Patient_Photo_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed to load Image");
            }

            if (PP != byteArrayToImage(EPatientPhoto))
                Profile_Picture = PP;
        }

        // Main Function
        private void AddnewPatient_saveAndConfirm_button_Click(object sender, EventArgs e)
        {
            // re-validate
            if (!DataValidation())
                return;

            List<Control> ChangedControls = _dirtyTracker.GetListOfDirtyControls();
           
            Patient = DataUpdater.Patient_info.Where(i => i.Patient_ID == EPatient_ID).FirstOrDefault();

            

            #region Basic info 

            if (ChangedControls.Contains(Patient_ID_textBox))
            {
              ID = Int32.Parse(Patient_ID_textBox.Text);
              Patient.Patient_ID = ID;
            }

            if (ChangedControls.Contains(Age_textBox))
            {
                int Age;
                Age = Int32.Parse(Age_textBox.Text); 
                Patient.Age = Age;
            }
 
            if (ChangedControls.Contains(Sex_Combobox))
            {
                Patient.Sex = Sex_Combobox.Text;
            }


            if (ChangedControls.Contains(DateOfBirth_textBox))
            {
                DateTime BD = DateTime.Parse(DateOfBirth_textBox.Text);
                Patient.Birth_date = BD;
            }
           

            if (ChangedControls.Contains(Visit_date_textBox))
            {
                DateTime VD = DateTime.Parse(Visit_date_textBox.Text);
                Patient.Visit_date = VD;
            }
           

            if (ChangedControls.Contains(Patient_name_textBox))
            {
                Patient.Patient_name = Patient_name_textBox.Text;
            }

            if (ChangedControls.Contains(Homenum_textBox))
            {
                Patient.Home_number = Homenum_textBox.Text;
            }

            if (ChangedControls.Contains(Mobile_textBox))
            {
                Patient.Phone_number = Mobile_textBox.Text;
            }

            if (ChangedControls.Contains(Realative_Marriage_comboBox))
            {
                Patient.Relative_marriage = Realative_Marriage_comboBox.Text;
            }

            if (ChangedControls.Contains(Address_textBox))
            {
                Patient.Address = Address_textBox.Text;
            }

            if (ChangedControls.Contains(Chief_Complaint_textBox))
            {
                Patient.Cheif_complaint = Chief_Complaint_textBox.Text;
            }

            if (ChangedControls.Contains(Medical_alert_textBox))
            {
                Patient.Medical_alert = Medical_alert_textBox.Text;
            }

            if (Profile_Picture != null)
            {
                Patient.Patient_image = imageToByteArray(Profile_Picture) ;
            }

            if (AddnewXrayImagesIsPressed)
            {
                // Patinet's X-ray images
                ////////////////////////////////////////
                // Byte[] XrayImage;

                MemoryStream ms;
                int ix = 0;
                var Xcount = (from o in DataUpdater.X_ray_images select o).Count();
                int Xtemp = Xcount + 1;
                foreach (Bitmap img in Patient_Xray_images)
                {

                    var XrayimageObject = new X_ray_images();
                    ms = new MemoryStream();
                    img.Save(ms, img.RawFormat);
                    XrayimageObject.Patient_ID = ID;
                    XrayimageObject.Xray_image = ms.ToArray();
                    XrayimageObject.Image_name = XrayImagesNames[ix];
                    XrayimageObject.Xray_images_ID = Xtemp;
                    DataUpdater.X_ray_images.Add(XrayimageObject);
                    ix++;
                    Xtemp++;
                }
            }

            if (ChangedControls.Contains(DMF_D_textBox))
            {
                Patient.D_DMF = D;
            }

            if (ChangedControls.Contains(DMF_M_textbox))
            {
                Patient.M_DMF = M;
            }

            if (ChangedControls.Contains(DMF_F_textBox))
            {
                Patient.F_DMF = F;
            }

            if (ChangedControls.Contains(DMF_D_textBox) || ChangedControls.Contains(DMF_M_textbox) || ChangedControls.Contains(DMF_F_textBox))
            {
                Patient.DMF = DMF; 
            }

            if (ChangedControls.Contains(_dmf_d_textBox))
            {
                Patient.dd_dmf = d;
            }

            if (ChangedControls.Contains(_dmf_m_textBox))
            {
                Patient.mm_dmf = m;
            }

            if (ChangedControls.Contains(_dmf_f_textBox))
            {
                Patient.ff_dmf = f;
            }

            if (ChangedControls.Contains(_dmf_d_textBox) || ChangedControls.Contains(_dmf_m_textBox) || ChangedControls.Contains(_dmf_f_textBox))
            {
                Patient.C_dmf = _dmf;
            }

            if (ChangedControls.Contains(DEF_D_textBox))
            {
                Patient.D_DEF = _D;
            }

            if (ChangedControls.Contains(DEF_E_textBox))
            {
                Patient.E_DEF = E;
            }

            if (ChangedControls.Contains(DEF_F_textbox))
            {
                Patient.F_DEF = _F;
            }

            if (ChangedControls.Contains(DEF_D_textBox) || ChangedControls.Contains(DEF_E_textBox) || ChangedControls.Contains(DEF_F_textbox))
            {
                Patient.DEF = DEF;
            }

            #endregion
            ////////////////////////////////////////////////////////////////

            #region Diagnosis And Treatment Plans

            if (DiagnosisAndTPsIsChanged && DiagnosisAndTPsIsPressed)
            {
                int index = 0;
                var Query = from P in DataUpdater.Diagnoses.Where(P => P.Patient_ID == ID) select P;
                if (Updated_DiagnosisAndTPs_table.Count == EDiagnosisAndTPs_table.Count)
                {
                    // Update
                    foreach (var item in Query)
                    {
                        List<String> row = Updated_DiagnosisAndTPs_table[index];
                        item.Diagnose = row[0];
                        item.Treatment_Plan = row[1];
                        index++;
                    }
                }

                // increase
                if (Updated_DiagnosisAndTPs_table.Count > EDiagnosisAndTPs_table.Count)
                {
                    //update
                    foreach (var item in Query)
                    {
                        List<String> row = Updated_DiagnosisAndTPs_table[index];
                        item.Diagnose = row[0];
                        item.Treatment_Plan = row[1];
                        index++;
                    }

                    // create
                    var Dcount = (from o in DataUpdater.Diagnoses select o).Count();
                    int Dtemp = Dcount + 1;
                    for (int i = index; i < Updated_DiagnosisAndTPs_table.Count; i++)
                    {
                        List<String> row = Updated_DiagnosisAndTPs_table[i];
                        var DiagnosisObject = new Diagnosis();

                        DiagnosisObject.Patient_ID = ID;
                        DiagnosisObject.Diagnose_ID = Dtemp;
                        DiagnosisObject.Diagnose = row[0];
                        DiagnosisObject.Treatment_Plan = row[1];

                        DataUpdater.Diagnoses.Add(DiagnosisObject);
                        Dtemp++;
                    }
                }

                // decrease
                if (Updated_DiagnosisAndTPs_table.Count < EDiagnosisAndTPs_table.Count)
                {
                    // update
                    foreach (var item in Query)
                    {
                        
                        if (index < Updated_DiagnosisAndTPs_table.Count)
                        {
                            var checkItem = DataUpdater.Diagnoses.Create();
                            List<String> row = Updated_DiagnosisAndTPs_table[index];
                            checkItem.Diagnose = row[0];
                            checkItem.Treatment_Plan = row[2];

                            if (item.Diagnose == checkItem.Diagnose && item.Treatment_Plan == checkItem.Treatment_Plan)               
                            {
                                index++;
                                continue;
                            }
                            else 
                            {
                                item.Diagnose = row[0];
                                item.Treatment_Plan = row[1];
                            }
                        }
                        else
                        {
                            // delete
                            DataUpdater.Diagnoses.Remove(item);
                        }
                        index++;
                    }
                }
            }

            #endregion

            ////////////////////////////////////////////////////////////////
            #region Dates And Procedures
            if (DatesAndProceduresIsChanged && DatesAndProceduresIsPressed)
            {
                int index = 0;
                var Query = from P in DataUpdater.Dates.Where(P => P.Patient_ID == ID) select P;
                if (Updated_DatesAndProc_table.Count == EDatesAndProc_table.Count)
                {
                    foreach (var item in Query)
                    {
                        List<String> row = Updated_DatesAndProc_table[index];
                        item.Date1 = DateTime.Parse(row[0]);
                        item.Doctor_name = row[1];
                        item.Procedures = row[2];
                        item.Procedure_Comment = row[3];
                        if (row[4].Length != 0)
                            item.Medication = row[4];
                        item.Supervisor_signature = row[5];
                        index++;
                    }
                }

                if (Updated_DatesAndProc_table.Count > EDatesAndProc_table.Count)
                {
                    foreach (var item in Query)
                    {
                        List<String> row = Updated_DatesAndProc_table[index];
                        item.Date1 = DateTime.Parse(row[0]);
                        item.Doctor_name = row[1];
                        item.Procedures = row[2];
                        item.Procedure_Comment = row[3];
                        if (row[4].Length != 0)
                            item.Medication = row[4];
                        item.Supervisor_signature = row[5];
                        index++;
                    }


                    var Dcount = (from o in DataUpdater.Dates select o).Count();
                    int Dtemp = Dcount + 1;
                    for (int i = index; i < Updated_DatesAndProc_table.Count; i++)
                    {
                        List<String> row = Updated_DatesAndProc_table[i];
                        var DatesObject = new Date();

                        DatesObject.Patient_ID = ID;
                        DatesObject.Dates_ID = Dtemp;
                        DatesObject.Date1 = Convert.ToDateTime(row[0]);
                        DatesObject.Doctor_name = row[1];
                        DatesObject.Procedures = row[2];
                        DatesObject.Procedure_Comment = row[3];
                        if (row[4].Length != 0)
                            DatesObject.Medication = row[4];
                        DatesObject.Supervisor_signature = row[5];

                        DataUpdater.Dates.Add(DatesObject);
                        Dtemp++;
                    }
                }

                if (Updated_DatesAndProc_table.Count < EDatesAndProc_table.Count)
                {
                    // update
                    foreach (var item in Query)
                    {
                        if (index < Updated_DatesAndProc_table.Count)
                        {
                            var checkItem = DataUpdater.Dates.Create();
                            List<String> row = Updated_DatesAndProc_table[index];
                            checkItem.Date1 = DateTime.Parse(row[0]);
                            checkItem.Doctor_name = row[1];
                            checkItem.Procedures = row[2];
                            checkItem.Procedure_Comment = row[3];
                            if (row[4].Length != 0)
                                checkItem.Medication = row[4];
                            checkItem.Supervisor_signature = row[5];

                            if (item.Date1 == checkItem.Date1 && item.Doctor_name == checkItem.Doctor_name &&
                                item.Procedures == checkItem.Procedures && item.Procedure_Comment == checkItem.Procedure_Comment
                                && item.Medication == checkItem.Medication && item.Supervisor_signature == checkItem.Supervisor_signature)
                                
                            {
                                 index++;
                                 continue;
                            }
                            else
                            {
                                item.Date1 = DateTime.Parse(row[0]);
                                item.Doctor_name = row[1];
                                item.Procedures = row[2];
                                item.Procedure_Comment = row[3];
                                if (row[4].Length != 0)
                                    item.Medication = row[4];
                                item.Supervisor_signature = row[5];
                            }
                        }
                        else
                        {
                            // delete
                            DataUpdater.Dates.Remove(item);
                        }
                        index++;
                    }
                }
            }
            #endregion

            try
            {
                DataUpdater.SaveChanges();
            }
            catch (Exception ex)
            {
                Exception see = ex;
                MessageBox.Show("There was a problem while saving in the DBcontext\n" + ex.Message);
                return;
            }

            AddNewPatientSaveAndConfirmIsPressed = true;
            MessageBox.Show("The Patient was edited successfully");

            EditedPatient = new Patient_Profile_Viewer(Int32.Parse(Patient_ID_textBox.Text));
            this.Close();
            EditedPatient.Show();

        }

        // Diagnosis And Treatment Plans save
        private void DATP_SaveAndConfirmButton_Click(object sender, EventArgs e)
        {
            List<Control> ChangedControls = _dirtyTracker.GetListOfDirtyControls();

            if (ChangedControls.Contains(DMF_D_textBox) || ChangedControls.Contains(DMF_M_textbox) || ChangedControls.Contains(DMF_F_textBox))
            {
                if (string.IsNullOrEmpty(DMF_D_textBox.Text) || string.IsNullOrEmpty(DMF_M_textbox.Text) || string.IsNullOrEmpty(DMF_F_textBox.Text)
                    || !Double.TryParse(DMF_D_textBox.Text, out D) || !Double.TryParse(DMF_M_textbox.Text, out M) || !Double.TryParse(DMF_F_textBox.Text, out F))
                {
                    MessageBox.Show("Please enter a valid DMF values");
                    Error.SetError(DMF_Label, "Please enter a valid DMF values");
                    return;
                }

                D = Double.Parse(DMF_D_textBox.Text);
                M = Double.Parse(DMF_M_textbox.Text);
                F = Double.Parse(DMF_F_textBox.Text);

                DMF = D + M + F;
            }

            Error.Clear();

           

            if (ChangedControls.Contains(_dmf_d_textBox) || ChangedControls.Contains(_dmf_m_textBox) || ChangedControls.Contains(_dmf_f_textBox))
            {

                if (string.IsNullOrEmpty(_dmf_d_textBox.Text) || string.IsNullOrEmpty(_dmf_m_textBox.Text) || string.IsNullOrEmpty(_dmf_f_textBox.Text)
                   || !Double.TryParse(_dmf_d_textBox.Text, out d) || !Double.TryParse(_dmf_m_textBox.Text, out m) || !Double.TryParse(_dmf_f_textBox.Text, out f))
                {
                    MessageBox.Show("Please enter a valid dmf values");
                    Error.SetError(_dmf_label, "Please enter a valid dmf values");
                    return;
                }

                d = Double.Parse(_dmf_d_textBox.Text);
                m = Double.Parse(_dmf_m_textBox.Text);
                f = Double.Parse(_dmf_f_textBox.Text);

                _dmf = d + m + f;
            }

            Error.Clear();

           

            if (ChangedControls.Contains(DEF_D_textBox) || ChangedControls.Contains(DEF_E_textBox) || ChangedControls.Contains(DEF_F_textbox))
            {

                if (string.IsNullOrEmpty(DEF_D_textBox.Text) || string.IsNullOrEmpty(DEF_E_textBox.Text) || string.IsNullOrEmpty(DEF_F_textbox.Text)
                   || !Double.TryParse(DEF_D_textBox.Text, out _D) || !Double.TryParse(DEF_E_textBox.Text, out E) || !Double.TryParse(DEF_F_textbox.Text, out _F))
                {
                    MessageBox.Show("Please enter a valid DEF values");
                    Error.SetError(DEF_Label, "Please enter a valid dmf values");
                    return;
                }

                _D = Double.Parse(DEF_D_textBox.Text);
                E = Double.Parse(DEF_E_textBox.Text);
                _F = Double.Parse(DEF_F_textbox.Text);

                DEF = _D + E + _F;
            }

            Error.Clear();
           
            ///////////////////////////////////////////////////////////////////////////////////////

            if (!ValidateData.ValidateEmptyTable(DiagnosisAndTPdataGridView))
            {
                Error.SetError(DiagnosisAndTPdataGridView, "Please fill the table with Data");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateTableData(DiagnosisAndTPdataGridView, 'D'))
                return;

            DiagnosisAndTPsIsPressed = true;
           

            if (DiagnosisAndTPsIsChanged)
            {
                // Filling the Data
                List<String> CurrentRow;
                foreach (DataGridViewRow row in DiagnosisAndTPdataGridView.Rows)
                {
                    CurrentRow = new List<String>();
                    if (row.Cells[0].Value == null && row.Cells[1].Value == null)
                        continue;

                    for (int i = 0; i < 2; i++)
                        CurrentRow.Add(row.Cells[i].Value.ToString());

                    Updated_DiagnosisAndTPs_table.Add(CurrentRow);
                }
            }

            MessageBox.Show("The Data of this page was saved successfully :D\nPlease confirm the edit from the basic info page");
            Add_newPatient_tabControl.SelectedIndex = 0;

        }

        // Dates And Procedures save
        private void DAP_saveAndConfirm_Button_Click(object sender, EventArgs e)
        {
            if (!ValidateData.ValidateEmptyTable(DatesAndProc_dataGridView))
            {
                Error.SetError(DatesAndProc_dataGridView, "Please fill the table with Data");
                return;
            }
            Error.Clear();

            if (!ValidateData.ValidateTableData(DatesAndProc_dataGridView, 'P'))
                return;

            DatesAndProceduresIsPressed = true;      

            if (DatesAndProceduresIsChanged)
            {
                // Filling the Data
                List<String> CurrentRow;
                foreach (DataGridViewRow row in DatesAndProc_dataGridView.Rows)
                {
                    CurrentRow = new List<String>();
                    if (row.Cells[0].Value == null && row.Cells[1].Value == null && row.Cells[2].Value == null && row.Cells[3].Value == null && row.Cells[5].Value == null)
                        continue;

                    for (int i = 0; i < 6; i++)
                    {
                        if (i == 4 && row.Cells[i].Value == null)
                        {
                            CurrentRow.Add(" ");
                            continue;
                        }

                        CurrentRow.Add(row.Cells[i].Value.ToString());
                    }

                    Updated_DatesAndProc_table.Add(CurrentRow);
                }
            }

            MessageBox.Show("The Data of this page was saved successfully :D\nPlease confirm the edit from the basic info page");
            Add_newPatient_tabControl.SelectedIndex = 0;



        }

        // Value changed event in DATP gridview
        private void DiagnosisAndTPdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DiagnosisAndTPsIsChanged = true;   
        }

        // Value changed event in DAP gridview
        private void DatesAndProc_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DatesAndProceduresIsChanged = true;   
        }

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

        // Add X-ray-images
        private void AddPatientXray_button_Click_1(object sender, EventArgs e)
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
                    AddnewXrayImagesIsPressed = true;
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed to load Images");
            }

        }

       

    }
}
