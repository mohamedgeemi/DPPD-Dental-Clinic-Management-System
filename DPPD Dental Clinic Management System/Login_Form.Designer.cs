namespace DPPD_Dental_Clinic_Management_System
{
    partial class Login_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.UsernametextBox = new System.Windows.Forms.TextBox();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.newAccountButton = new System.Windows.Forms.Button();
            this.MainFormPanel = new System.Windows.Forms.Panel();
            this.ViewAll_DB_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.IDtoview_textBox = new System.Windows.Forms.TextBox();
            this.View_Patient_Button = new System.Windows.Forms.Button();
            this.SearchPatientsButton = new System.Windows.Forms.Button();
            this.AddnewPatientButton = new System.Windows.Forms.Button();
            this.MainPage_menuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSetOfPatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainFormPanel.SuspendLayout();
            this.MainPage_menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernametextBox
            // 
            this.UsernametextBox.Location = new System.Drawing.Point(386, 165);
            this.UsernametextBox.Name = "UsernametextBox";
            this.UsernametextBox.Size = new System.Drawing.Size(200, 20);
            this.UsernametextBox.TabIndex = 0;
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(386, 235);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.Size = new System.Drawing.Size(200, 20);
            this.PasswordtextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // Login_button
            // 
            this.Login_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_button.Location = new System.Drawing.Point(268, 303);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(133, 45);
            this.Login_button.TabIndex = 4;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // newAccountButton
            // 
            this.newAccountButton.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newAccountButton.Location = new System.Drawing.Point(417, 303);
            this.newAccountButton.Name = "newAccountButton";
            this.newAccountButton.Size = new System.Drawing.Size(188, 45);
            this.newAccountButton.TabIndex = 5;
            this.newAccountButton.Text = "Create New Account";
            this.newAccountButton.UseVisualStyleBackColor = true;
            this.newAccountButton.Click += new System.EventHandler(this.newAccountButton_Click);
            // 
            // MainFormPanel
            // 
            this.MainFormPanel.Controls.Add(this.ViewAll_DB_button);
            this.MainFormPanel.Controls.Add(this.label3);
            this.MainFormPanel.Controls.Add(this.IDtoview_textBox);
            this.MainFormPanel.Controls.Add(this.View_Patient_Button);
            this.MainFormPanel.Controls.Add(this.SearchPatientsButton);
            this.MainFormPanel.Controls.Add(this.AddnewPatientButton);
            this.MainFormPanel.Controls.Add(this.MainPage_menuStrip);
            this.MainFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormPanel.Location = new System.Drawing.Point(0, 0);
            this.MainFormPanel.Name = "MainFormPanel";
            this.MainFormPanel.Size = new System.Drawing.Size(621, 390);
            this.MainFormPanel.TabIndex = 6;
            this.MainFormPanel.Visible = false;
            // 
            // ViewAll_DB_button
            // 
            this.ViewAll_DB_button.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAll_DB_button.Location = new System.Drawing.Point(384, 247);
            this.ViewAll_DB_button.Name = "ViewAll_DB_button";
            this.ViewAll_DB_button.Size = new System.Drawing.Size(162, 102);
            this.ViewAll_DB_button.TabIndex = 5;
            this.ViewAll_DB_button.Text = "Database Browser";
            this.ViewAll_DB_button.UseVisualStyleBackColor = true;
            this.ViewAll_DB_button.Click += new System.EventHandler(this.ViewAll_DB_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter ID";
            // 
            // IDtoview_textBox
            // 
            this.IDtoview_textBox.Location = new System.Drawing.Point(136, 220);
            this.IDtoview_textBox.Name = "IDtoview_textBox";
            this.IDtoview_textBox.Size = new System.Drawing.Size(100, 20);
            this.IDtoview_textBox.TabIndex = 3;
            // 
            // View_Patient_Button
            // 
            this.View_Patient_Button.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Patient_Button.Location = new System.Drawing.Point(83, 247);
            this.View_Patient_Button.Name = "View_Patient_Button";
            this.View_Patient_Button.Size = new System.Drawing.Size(153, 102);
            this.View_Patient_Button.TabIndex = 2;
            this.View_Patient_Button.Text = "View Patient";
            this.View_Patient_Button.UseVisualStyleBackColor = true;
            this.View_Patient_Button.Click += new System.EventHandler(this.View_Patient_Button_Click);
            // 
            // SearchPatientsButton
            // 
            this.SearchPatientsButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPatientsButton.Location = new System.Drawing.Point(384, 45);
            this.SearchPatientsButton.Name = "SearchPatientsButton";
            this.SearchPatientsButton.Size = new System.Drawing.Size(162, 114);
            this.SearchPatientsButton.TabIndex = 1;
            this.SearchPatientsButton.Text = "Search";
            this.SearchPatientsButton.UseVisualStyleBackColor = true;
            this.SearchPatientsButton.Click += new System.EventHandler(this.SearchPatientsButton_Click);
            // 
            // AddnewPatientButton
            // 
            this.AddnewPatientButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddnewPatientButton.Location = new System.Drawing.Point(83, 45);
            this.AddnewPatientButton.Name = "AddnewPatientButton";
            this.AddnewPatientButton.Size = new System.Drawing.Size(171, 114);
            this.AddnewPatientButton.TabIndex = 0;
            this.AddnewPatientButton.Text = "Add new Patient";
            this.AddnewPatientButton.UseVisualStyleBackColor = true;
            this.AddnewPatientButton.Click += new System.EventHandler(this.AddnewPatientButton_Click);
            // 
            // MainPage_menuStrip
            // 
            this.MainPage_menuStrip.AutoSize = false;
            this.MainPage_menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MainPage_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.MainPage_menuStrip.Location = new System.Drawing.Point(5, 0);
            this.MainPage_menuStrip.Name = "MainPage_menuStrip";
            this.MainPage_menuStrip.Size = new System.Drawing.Size(182, 24);
            this.MainPage_menuStrip.TabIndex = 6;
            this.MainPage_menuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSetOfPatientsToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // deleteSetOfPatientsToolStripMenuItem
            // 
            this.deleteSetOfPatientsToolStripMenuItem.Name = "deleteSetOfPatientsToolStripMenuItem";
            this.deleteSetOfPatientsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteSetOfPatientsToolStripMenuItem.Text = "Delete Set of Patients";
            this.deleteSetOfPatientsToolStripMenuItem.Click += new System.EventHandler(this.deleteSetOfPatientsToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(597, 61);
            this.label4.TabIndex = 7;
            this.label4.Text = "Welcome to Department of Pediatric And Preventive           Dentistry Dental Clin" +
    "ic Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 390);
            this.Controls.Add(this.MainFormPanel);
            this.Controls.Add(this.newAccountButton);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.UsernametextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainPage_menuStrip;
            this.Name = "Login_Form";
            this.Text = "DPPD Dental Clinic Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Form_FormClosing);
            this.MainFormPanel.ResumeLayout(false);
            this.MainFormPanel.PerformLayout();
            this.MainPage_menuStrip.ResumeLayout(false);
            this.MainPage_menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernametextBox;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Button newAccountButton;
        private System.Windows.Forms.Panel MainFormPanel;
        private System.Windows.Forms.Button SearchPatientsButton;
        private System.Windows.Forms.Button AddnewPatientButton;
        private System.Windows.Forms.Button View_Patient_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IDtoview_textBox;
        private System.Windows.Forms.Button ViewAll_DB_button;
        private System.Windows.Forms.MenuStrip MainPage_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSetOfPatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

