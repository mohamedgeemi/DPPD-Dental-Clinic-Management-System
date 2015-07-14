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
    public class Data_Validator
    {
        public int TrowIndex, TcolumnIndex; 
        public Data_Validator()
        { }
        public bool ValidateID(String ID)
        {
            int Patient_ID;
            // ID Validation
            if (!int.TryParse(ID, out Patient_ID) || string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Please enter a valid ID");
                return false;
            }

            var Check = Login_Form.context.Patient_info;
            Patient_ID = Int32.Parse(ID);
            if (Check.Any(I => I.Patient_ID == Patient_ID))
            {
                MessageBox.Show("This ID is Already Exist in the database");
                return false;
            }

            return true;
        }
        public bool ValidateIDIsExist(String ID)
        {
            int Patient_ID;
            // ID Validation
            if (!int.TryParse(ID, out Patient_ID) || string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Please enter a valid ID");
                return false;
            }

            var Check = Login_Form.context.Patient_info;
            Patient_ID = Int32.Parse(ID);
            if (!Check.Any(I => I.Patient_ID == Patient_ID))
            {
                MessageBox.Show("This ID is not Exist in the database");
                return false;
            }

            return true;
 
        }
        public bool ValidateIDField(String ID)
        {
            int Patient_ID;
            // ID Validation
            if (!int.TryParse(ID, out Patient_ID) || string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Please enter a valid ID");
                return false;
            }
            return true;
        }
        public bool ValidateAge(String Age)
        {
            int Patient_Age;
            // Age Validation

            if (!int.TryParse(Age, out Patient_Age) || string.IsNullOrEmpty(Age))
            {

                MessageBox.Show("Please enter a valid Age");
                return false;
            }
            return true;
        }
        public bool ValidateSex(String Sex)
        {
             // Sex Validation
            if (string.IsNullOrEmpty(Sex) || (Sex != "Male" && Sex != "Female"))
            {
                MessageBox.Show("Please enter a valid Sex");
                return false;
            }
            return true;
        }
        public bool ValidateDate(String Date)
        {
            DateTime D = new DateTime() ;
            // Date Of birth validation 
            if (string.IsNullOrEmpty(Date) || !DateTime.TryParse(Date, out D))
            {
                return false;
            }
            return true;
        }
        public bool ValidateName(String Name)
        {
            // Name Validation
            if (string.IsNullOrEmpty(Name) || !Name.All(C => Char.IsLetter(C) || Char.IsWhiteSpace(C)))
            {
                MessageBox.Show("Please enter valid Name");
                return false;
            }
            return true;
        }
        public bool ValidateNumber(String Num)
        {
            // Home number validation
            if (string.IsNullOrEmpty(Num) || !Num.All(C => Char.IsDigit(C)))
            {
                return false;
            }
            return true;
        }
        public bool ValidateRelativeMarriage(String RM)
        {
            // Relative Validation
            if (string.IsNullOrEmpty(RM) || (RM != "Yes" && RM != "No"))
            {
                MessageBox.Show("Please enter a valid Relative Marriage");
                return false;
            }
            return true;
        }
        public bool ValidateNullField(String Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                return false;
            }
            return true;
        }
        public bool ValidatePatientImage(PictureBox PM)
        {
            // Patient Photo validation
            if (PM == null || PM.Image == null)
            {
                MessageBox.Show("Please attach Patient Photo");
                return false;

            }
            return true;
        }
        public bool ValidateXrayImage(List<Bitmap> PXrays)
        {
            // Xray images validation
            if (PXrays.Any() == false)
            {
                MessageBox.Show("Please attach Patient's X-ray images");
                return false;
            }
            return true;
        }
        public bool ValidateEmptyTable(DataGridView dt)
        {
            bool isEMPTY = true;
            foreach (DataGridViewRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    if (row.Cells[i].Value != null)
                    {
                        isEMPTY = false;
                        break;
                    }
                }

                if (isEMPTY == false)
                    break;
                if (isEMPTY == true)
                {
                    MessageBox.Show("Please fill the table with data");
                    return false;
                }

            }
            return true;
        }
        public bool ValidateTableData(DataGridView dt, Char Option)
        {
            foreach (DataGridViewRow row in dt.Rows)
            {
                if (Option == 'D')
                {
                    if (row.Cells[0].Value == null && row.Cells[1].Value == null)
                        continue;

                    if (row.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please fill the Diagnosis at row number: " + PLUSONE(row.Index));
                        return false;
                    }

                    if (row.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please fill the Treatment Plan at row number: " + PLUSONE(row.Index));
                        return false;
                    }
                }
                else if (Option == 'P')
                {
                    String templ, temp2, temp4;
                    DateTime date = new DateTime();

                    templ = ""; temp2 = ""; temp4 = "";
                    if (row.Cells[0].Value == null && row.Cells[1].Value == null && row.Cells[2].Value == null && row.Cells[3].Value == null && row.Cells[5].Value == null)
                        continue;

                    if (row.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please fill the Date at row number: " + PLUSONE(row.Index) + " , ex:1/2/2017");
                        return false;
                    }
                    templ = row.Cells[0].Value.ToString();
                    if (DateTime.TryParse(templ, out date) == false)
                    {
                        MessageBox.Show("Please enter valid Date at row number: " + PLUSONE(row.Index) + " , ex:1/2/2017");
                        return false;

                    }

                    if (row.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please fill the Doctor's Name at row number: " + PLUSONE(row.Index));
                        return false;
                    }
                    temp2 = row.Cells[1].Value.ToString();
                    if (!NamesCheck(temp2))
                    {
                        MessageBox.Show("Please enter valid Doctor's Name at row number: " + PLUSONE(row.Index));
                        return false;
                    }

                    if (row.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please fill the Procedure at row number: " + PLUSONE(row.Index));
                        return false;
                    }

                    // No check for the medication because it can be NULL :D
                    if (row.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please fill the Procedure Comment at row number: " + PLUSONE(row.Index));
                        return false;
                    }
                    if (row.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please fill the Supervisor name at row number: " + PLUSONE(row.Index));
                        return false;
                    }
                    temp4 = row.Cells[5].Value.ToString();
                    if (!NamesCheck(temp4))
                    {
                        MessageBox.Show("Please enter valid Supervisor Signature name at row number: " + PLUSONE(row.Index));
                        return false;
                    }
                }

            }

            return true;
        }
        public bool ValidateComboBoxItem(String Item, List<String> ListOfItems)
        {
            if (string.IsNullOrEmpty(Item) || !ListOfItems.Contains(Item))
            {
                MessageBox.Show("Please Choose valid option from the list");
                return false;
            }
            return true;
        }
        public bool ValidateIntSearchKey(String SearchKey)
        {
            Int64 id;
            if (string.IsNullOrEmpty(SearchKey) || !SearchKey.All(i => Char.IsDigit(i)) || !Int64.TryParse(SearchKey, out id))
            {
                MessageBox.Show("Please enter valid search key");
                return false;
            }

            return true;
        }
        public bool ValidateSetSearchKey(String Option, String SearchKey)
        {

            if (Option == "Diagnose")
            {
                if (!ValidateNullField(SearchKey))
                {
                    MessageBox.Show("Please choose valid Diagnose Search Key");
                    return false;
                }
            }
            else if (Option == "Procedures")
            {
                if (!ValidateNullField(SearchKey))
                {
                    MessageBox.Show("Please choose valid Procedure Search key");
                    return false;
                }
            }
            else if (Option == "Sex")
            {
                if (!ValidateSex(SearchKey))
                {
                    return false;
                }
            }
            else if (Option == "Relative_marriage")
            {
                if (!ValidateRelativeMarriage(SearchKey))
                {
                    return false;
                }
            }
            else
            {
                if (Option == "Age")
                {
                    if (!ValidateAge(SearchKey))
                    {
                        return false;
                    }
                }
                else if (Option == "Visit_date")
                {
                    if (!ValidateDate(SearchKey))
                    {
                        MessageBox.Show("Please enter a valid Visit Date, ex: 1/1/2016");
                        return false;
                    }
                }
                else
                {
                    // Names Validation
                    if (!ValidateName(SearchKey))
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        public bool ValidateDoubleSearchKEy(String value)
        {
            Double F;

            if (string.IsNullOrEmpty(value) || !Double.TryParse(value, out F))
                return false;
            return true;
        }
        public void ReorderXray_table()
        {
            var Query = from X in Login_Form.context.X_ray_images select X;
            int index = 1;

            foreach (var item in Query)
            {
                item.Xray_images_ID = index;
                index++;
            }
            Login_Form.context.SaveChanges();
        }
        public void ReorderDiagnosis_table()
        {
            var Query = from X in Login_Form.context.Diagnoses select X;
            int index = 1;

            foreach (var item in Query)
            {
                item.Diagnose_ID = index;
                index++;
            }
            Login_Form.context.SaveChanges();
        }
        public void ReorderDates_table()
        {
            var Query = from X in Login_Form.context.Dates select X;
            int index = 1;

            foreach (var item in Query)
            {
                item.Dates_ID = index;
                index++;
            }
            Login_Form.context.SaveChanges();
        }

        /// <summary>
        /// Helper Functions :D
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static String PLUSONE(int index)
        {
            return (index + 1).ToString();
        }
        private static bool NamesCheck(String s)
        {
            foreach (char c in s)
            {
                if (!(Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                    return false;
            }
            return true;
        }

        #region Naive Method

        //String ID, Age, Name, Home_no, Mobile_no, Patient_Address, Cheif_comp, Medical_Alr, Visit_Date, Birth_Date, Patient_Sex, RelativeMarriage;
        //DateTime VisitDate, BirthDate;
        //bool DATPs, DAP;
        //PictureBox Patient_image;
        //List<Bitmap> PXrays;
        // public int GOTO;

        //public Data_Validator(String Patient_ID, String age, String sex, String DateOfBirth, String Patient_name
        //    ,String Visit_date, String Homenum, String Mobile, String Address, String Realative_Marriage,
        //    String Chief_Complaint, String Medical_alert, PictureBox Patient_Photo,
        //     List<Bitmap> Patient_Xray_images, bool DiagnosisAndTP_DataValidation, bool DatesAndProc_DataValidation)
        //{
        //    ID = Patient_ID;
        //    Age = age;
        //    Patient_Sex = sex;
        //    Birth_Date = DateOfBirth;
        //    Name = Patient_name;
        //    Visit_Date = Visit_date;
        //    Home_no = Homenum;
        //    Mobile_no = Mobile;
        //    Patient_Address = Address;
        //    RelativeMarriage = Realative_Marriage;
        //    Cheif_comp = Chief_Complaint;
        //    Medical_Alr = Medical_alert;
        //    Patient_image = Patient_Photo;
        //    PXrays = Patient_Xray_images;
        //    DATPs = DiagnosisAndTP_DataValidation;
        //    DAP = DatesAndProc_DataValidation;
        //}
        
        // Validate Basic info
        /* public bool Validation()
         {
             int Patient_ID, Patient_Age;
             // ID Validation
             if (!int.TryParse(ID, out Patient_ID) || string.IsNullOrEmpty(ID))
             {
                 MessageBox.Show("Please enter a valid ID");
                 return false;
             }


             var Check = Login_Form.context.Patient_info;
             Patient_ID = Int32.Parse(ID);
             if (Check.Any(I => I.Patient_ID == Patient_ID))
             {

                 MessageBox.Show("This ID is Already Exist in the database");
                 return false;
             }

             // Age Validation

             if (!int.TryParse(Age, out Patient_Age) || string.IsNullOrEmpty(Age))
             {

                 MessageBox.Show("Please enter a valid Age");
                 return false;
             }

             // Sex Validation
             if (string.IsNullOrEmpty(Patient_Sex) || (Patient_Sex != "Male" && Patient_Sex != "Female"))
             {
                 MessageBox.Show("Please enter a valid Sex");
                 return false;
             }


             // Date Of birth validation 
             if (string.IsNullOrEmpty(Birth_Date) || !DateTime.TryParse(Birth_Date, out BirthDate))
             {
                 MessageBox.Show("Please enter a valid Date of Birth, ex: 1/1/2016");
                 return false;
             }


             // Name Validation
             if (string.IsNullOrEmpty(Name) || !Name.All(C => Char.IsLetter(C) || Char.IsWhiteSpace(C)))
             {
                 MessageBox.Show("Please enter valid Name");
                 return false;
             }

             // Visit Date validation
             if (string.IsNullOrEmpty(Visit_Date) || !DateTime.TryParse(Visit_Date, out VisitDate))
             {
                 MessageBox.Show("Please enter a valid Visit Date, ex: 2/2/2016");
                 return false;
             }

             // Home number validation
             if (string.IsNullOrEmpty(Home_no) || !Home_no.All(C => Char.IsDigit(C)))
             {
                 MessageBox.Show("Please enter a valid Home number");
                 return false;
             }

             // Mobile number validation
             if (string.IsNullOrEmpty(Mobile_no) || !Mobile_no.All(C => Char.IsDigit(C)))
             {
                 MessageBox.Show("Please enter a valid Mobile number");
                 return false;
             }

             // Relative Validation
             if (string.IsNullOrEmpty(RelativeMarriage) || (RelativeMarriage != "Yes" && RelativeMarriage != "No"))
             {
                 MessageBox.Show("Please enter a valid Relative Marriage");
                 return false;
             }

             // Cheif Complaint validation
             if (string.IsNullOrEmpty(Cheif_comp))
             {
                 MessageBox.Show("Please enter a valid Chief Complaint");
                 return false;
             }

             // Medical validation
             if (string.IsNullOrEmpty(Medical_Alr))
             {
                 MessageBox.Show("Please enter a valid Medical Alert");
                 return false;
             }

             // Address validation
             if (string.IsNullOrEmpty(Patient_Address))
             {
                 MessageBox.Show("Please enter a valid Address");
                 return false;
             }

             // Patient Photo validation
             if (Patient_image == null || Patient_image.Image == null)
             {
                 MessageBox.Show("Please attach Patient Photo");
                 return false;

             }

             // Xray images validation
             if (PXrays.Any() == false)
             {
                 MessageBox.Show("Please attach Patient's X-ray images");
                 return false;
             }

             if (DATPs == false && DAP == false)
             {
                 MessageBox.Show("Please fill The Diagnosis and Treatment Plans && Dates Table");
                 GOTO = 1;
                 return false;
             }
             if (DATPs == false)
             {
                 MessageBox.Show("Please fill The Dinagnosis And Treatment Plans");
                 GOTO = 1;
                 return false;
             }

             if (DAP == false)
             {
                 MessageBox.Show("Please fill The Dates and Procedures table");
                 GOTO = 2;
                 return false;
             }

             return true;
         }*/
        #endregion
    }
}
