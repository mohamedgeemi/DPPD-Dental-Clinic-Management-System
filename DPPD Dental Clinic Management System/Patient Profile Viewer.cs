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

namespace DPPD_Dental_Clinic_Management_System
{
    public partial class Patient_Profile_Viewer : Form
    {
       
        int Patient_ID, Age, XrayViewerImageIndex;
        String Patient_Name, Home_no, Mobile_no, Address, Cheif_comp, Medical_Alr, Comments,Sex, RelativeMarriage;
        DateTime VisitDate, BirthDate;
        byte[] PatientPhoto;
        Double DMF, dmf, DEF;
        Double D, M, F;
        Double d, m, f;
        Double _D, E, _F;
        Patient_info Patient;
        List<Bitmap> Xray_images;
        List<String> XrayimagesNames , Diagnosis, TreatmentPlans;
        List<List<String>> DiagnosisAndTPs_table, DatesAndProc_table;
        DCEntities RetrievedContext;
        Data_Validator ValidateData;
   
        public Patient_Profile_Viewer(int id)
        {
            InitializeComponent();
            Patient_ID = id;
            RetrievedContext = new DCEntities();
            ValidateData = new Data_Validator();
            Patient = new Patient_info();
            Xray_images = new List<Bitmap>();
            XrayimagesNames = new List<String>();
            Diagnosis = new List<String>();
            TreatmentPlans = new List<String>();
            DiagnosisAndTPs_table = new List<List<String>>();
            DatesAndProc_table = new List<List<String>>();
            ViewPatientProfile();
            XrayViewerImageIndex = 0;
        }

        // Main 
        public void ViewPatientProfile()
        {
          //  var Query = from P in RetrievedContext.Patient_info.Where(P => P.Patient_ID == Patient_ID) select P;
            if (CheckBoxIfExist() == false)
                return;

            GetPatientData();
            FillData();
            this.Text = Patient.Patient_name;
            ViewBasicInfo();  
 
            //////////////////

            GetPatientXrayImages();
            ViewXrayImages();
            
            /////////////////////
            GetDiagnosisAndTreatmentPlans();
            ViewDiagnosisAndTreatmentPlans();
            
            //////////////////////
            GetDatesAndProcedures();
            ViewDatesAndProcedures();
        }
        // check if exist
        public bool CheckBoxIfExist()
        {
            if (!RetrievedContext.Patient_info.Any(i => i.Patient_ID == Patient_ID))
            {
                MessageBox.Show("This ID is not exist in your database");
                return false;
            }
            return true;
 
        }
        // Get patient data
        public void GetPatientData()
        {
            Patient = RetrievedContext.Patient_info.Where(ID => ID.Patient_ID == Patient_ID).FirstOrDefault();
        }
        // Fill the data in the form
        public void FillData()
        {
            //////////////////

            Age = Patient.Age;
            Patient_Name = Patient.Patient_name;
            Home_no = Patient.Home_number;
            Mobile_no = Patient.Phone_number;
            Address = Patient.Address;
            Cheif_comp = Patient.Cheif_complaint;
            Medical_Alr = Patient.Medical_alert;
            Comments = Patient.Comments;
            VisitDate = Patient.Visit_date;
            BirthDate = Patient.Birth_date;
            Sex = Patient.Sex;
            RelativeMarriage = Patient.Relative_marriage;
            PatientPhoto = Patient.Patient_image;
            DMF = Patient.DMF;
            D = Convert.ToDouble(Patient.D_DMF);
            M = Convert.ToDouble(Patient.M_DMF);
            F = Convert.ToDouble(Patient.F_DMF);
            dmf = Patient.C_dmf;
            d = Convert.ToDouble(Patient.dd_dmf);
            m = Convert.ToDouble(Patient.mm_dmf);
            f = Convert.ToDouble(Patient.ff_dmf);
            DEF = Patient.DEF;
            _D = Convert.ToDouble(Patient.D_DEF);
            E = Convert.ToDouble(Patient.E_DEF);
            _F = Convert.ToDouble(Patient.F_DEF);
        }
        // Fill Basic info page
        public void ViewBasicInfo()
        {
            ////////////
            P_ID.Text = Patient_ID.ToString();
            P_Name.Text = Patient_Name;
            P_Age.Text = Age.ToString();
            P_Sex.Text = Sex;
            P_Birthday.Text = BirthDate.ToShortDateString();
            P_Home_no.Text = Home_no;
            P_Mobile_nom.Text = Mobile_no;
            P_Visit_date.Text = VisitDate.ToShortDateString();
            P_Realative_Marriage.Text = RelativeMarriage;
            P_Address.Text = Address;
            P_Chief_Comp.Text = Cheif_comp;
            P_Medical_Alert.Text = Medical_Alr;
            if (Comments != null)
                P_Comments.Text = Comments;

            PatientPhoto = Patient.Patient_image;
            MemoryStream ms = new MemoryStream(PatientPhoto);

            var image = Image.FromStream(ms);
            P_Profile_Picture.Image = image;
            P_Profile_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
 
        }
        // Get the Xray images
        public void GetPatientXrayImages() {

            var images = Patient.X_ray_images.Where(i=>i.Patient_ID == Patient_ID);

            byte[] current_Img;
            MemoryStream ms;
            foreach (var image in images)
            {
                XrayimagesNames.Add(image.Image_name);
                current_Img = image.Xray_image;
                ms = new MemoryStream(current_Img);
                Xray_images.Add(new Bitmap (Image.FromStream(ms)));
            }
        }
        // Fill X-ray images page
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

        // Photo viewer - Previous
        private void Photo_viewer_Preivous_button_Click(object sender, EventArgs e)
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
        // Photo viewer - Next
        private void Photo_Viewer_Next_button_Click(object sender, EventArgs e)
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
        // Get Diagnosis and treatment plans data
        private void GetDiagnosisAndTreatmentPlans()
        {
            var Diagnosis = Patient.Diagnoses.Where(i => i.Patient_ID == Patient_ID);

            List<String> CurrentRow;
            foreach (var record in Diagnosis)
            {
                CurrentRow = new List<String>();
                CurrentRow.Add(record.Diagnose);
                CurrentRow.Add(record.Treatment_Plan);
  
                DiagnosisAndTPs_table.Add(CurrentRow);
            }
        }
        // View Diagnosis and treatment plans data
        private void ViewDiagnosisAndTreatmentPlans()
        {

            DMF_Value.Text = DMF.ToString();
            DMF_D.Text = D.ToString();
            DMF_M.Text = M.ToString();
            DMF_F.Text = F.ToString();
            _dmf_value.Text = dmf.ToString();
            _dmf_d.Text = d.ToString();
            _dmf_m.Text = m.ToString();
            _dmf_f.Text = f.ToString();
            DEF_Value.Text = DEF.ToString();
            DEF_D.Text = _D.ToString();
            DEF_E.Text = E.ToString();
            DEF_F.Text = _F.ToString();

            foreach (List<String> row in DiagnosisAndTPs_table)
            {
                DATP_dataGridView.Rows.Add(row.ToArray());
            }
        }
        // Get Dates and Procedure table
        private void GetDatesAndProcedures()
        {
            var Dates = Patient.Dates.Where(i=>i.Patient_ID == Patient_ID);
            
            List<String> CurrentRow;
            foreach(var Date in Dates)
            {
                CurrentRow = new List<String>();
                CurrentRow.Add(Date.Date1.ToShortDateString());
                CurrentRow.Add(Date.Doctor_name);
                CurrentRow.Add(Date.Procedures);
                CurrentRow.Add(Date.Procedure_Comment);
                CurrentRow.Add(Date.Medication);
                CurrentRow.Add(Date.Supervisor_signature);

                DatesAndProc_table.Add(CurrentRow);
            }
        }
        // View Dates and Procedure table
        private void ViewDatesAndProcedures()
        {
            foreach (List<String> row in DatesAndProc_table)
            {
                DAP_dataGridView.Rows.Add(row.ToArray());
            }
        }

        // Edit Patient Profile
        private void Edit_Patient_button_Click(object sender, EventArgs e)
        {
            Edit_Patient editPatient = new Edit_Patient(Patient_ID, Age, Patient_Name, Home_no, Mobile_no, Address, Cheif_comp, Medical_Alr,
                Comments,Sex, RelativeMarriage, VisitDate, BirthDate, PatientPhoto, Xray_images, XrayimagesNames, D, M, F, d, m, f,  _D, E, _F, DiagnosisAndTPs_table,DatesAndProc_table);

            editPatient.Show();
            this.Close();

        }

        // Delete Patient Profile
        private void Delete_patient_button_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this patient?";
            string caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon Icon = MessageBoxIcon.Warning;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons, Icon);
            if (result == DialogResult.Yes)
            {
                RetrievedContext.Database.ExecuteSqlCommand("DELETE FROM Diagnosis WHERE Patient_ID = {0}", Patient_ID);
                RetrievedContext.Database.ExecuteSqlCommand("DELETE FROM Dates WHERE Patient_ID = {0}", Patient_ID);
                RetrievedContext.Database.ExecuteSqlCommand("DELETE FROM [X-ray_images] WHERE Patient_ID = {0}", Patient_ID);
                RetrievedContext.Database.ExecuteSqlCommand("DELETE FROM Patient_info WHERE Patient_ID = {0}", Patient_ID);

                RetrievedContext.SaveChanges();

                if (!RetrievedContext.Patient_info.Any(i => i.Patient_ID == Patient_ID))
                {
                    MessageBox.Show("The patient was deleted");
                    ValidateData.ReorderXray_table();
                    ValidateData.ReorderDiagnosis_table();
                    ValidateData.ReorderDates_table();
                }
                else
                    MessageBox.Show("Failed to delete the patient");
                
                this.Close();
            }
        }

        /// <summary>
        /// Generated by mistake :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Basic_info_tabPage_Click(object sender, EventArgs e)
        {

        }

        private void P_Name_Click(object sender, EventArgs e)
        {

        }

    }
}
