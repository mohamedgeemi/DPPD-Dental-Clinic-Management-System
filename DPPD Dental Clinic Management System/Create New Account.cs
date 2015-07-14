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
    public partial class Create_New_Account : Form
    {
        ErrorProvider Error;
        public Create_New_Account()
        {
            InitializeComponent();
            Error = new ErrorProvider();
            
            newPasstextBox.PasswordChar = '*';
            newPasstextBox.MaxLength = 20;

            newPassRetextbox.PasswordChar = '*';
            newPassRetextbox.MaxLength = 20;
        }

        // Get Data of new user
        private void Create_new_Account_Button_Click(object sender, EventArgs e)
        {
            String Username, Passoword, Re_enteredPassword;
            bool Validate;

            Username = newUNtextBox.Text;
            Passoword = newPasstextBox.Text;
            Re_enteredPassword = newPassRetextbox.Text;

            Validate = Validation(Username, Passoword, Re_enteredPassword);

            if (Validate == false)
                return;

            if (Validate == true)
            {
                AddNewAccount(Username, Passoword);
                MessageBox.Show("You have Registered Successfully!");
                this.Close();
            }         
        }

        // Add new user in DB
        private void AddNewAccount(String username, String password)
        {
            Login newAccount = new Login();
            var count = (from o in Login_Form.context.Logins select o).Count();

            newAccount.User_ID = count + 1;
            newAccount.Username = username;
            newAccount.Password = password;

            Login_Form.context.Logins.Add(newAccount);

            Login_Form.context.SaveChanges();
        }
        // Validate Data
        private bool Validation(String username, String password, String Re_enteredPassword)
        {
            bool ValidatationUN, ValidationPW;

            ValidatationUN = ValidateUserName(username);

            if (ValidatationUN == false)
            {
                MessageBox.Show("Username is already reserved!!");
                Error.SetError(newUNtextBox, "plz");
                return false;
            }
            Error.Clear();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter valid username");
                Error.SetError(newUNtextBox, "plz");
                return false;
            }
            Error.Clear();

            ValidationPW = ValidatePassword(password, Re_enteredPassword);

            if (ValidationPW == false)
            {
                MessageBox.Show("The two Passwords don't Match!!");
                Error.SetError(newPassRetextbox, "plz");
                return false;
            }
            Error.Clear();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Re_enteredPassword))
            {
                MessageBox.Show("Please enter valid password");
                Error.SetError(newPasstextBox, "plz");
                return false;
            }
            Error.Clear();

            if (password.Length > 20 || Re_enteredPassword.Length > 20)
            {
                MessageBox.Show("The maximum password length is 20!");
                Error.SetError(newPasstextBox, "plz");
                return false;
            }
            Error.Clear();

            return true;
 
        }

        // Validate username
        private bool ValidateUserName(String username)
        {
            var Query = from u in Login_Form.context.Logins.Where(u=> u.Username == username) select u;
            var usernames = Query.ToList();

            if (Login_Form.context.Logins.Any(u=> u.Username == username))
            {
                return false;
            }

            return true;                                
        }
        // Validate password
        private bool ValidatePassword(String Password, String Re_enteredPassword)
        {
            if (Password == Re_enteredPassword)
                return true;

            return false;
        }
    }
}
