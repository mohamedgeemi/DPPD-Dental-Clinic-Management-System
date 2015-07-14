namespace DPPD_Dental_Clinic_Management_System
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.Statistics_tabControl = new System.Windows.Forms.TabControl();
            this.NumberOfVisits_tabPage = new System.Windows.Forms.TabPage();
            this.Get_Number_Visits_button = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Visits_to_textBox = new System.Windows.Forms.TextBox();
            this.Visits_from_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BirthDate_tabPage = new System.Windows.Forms.TabPage();
            this.Get_BirthDate_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Birth_date_to_textBox = new System.Windows.Forms.TextBox();
            this.BirthDate_from_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Procedures_tabPage = new System.Windows.Forms.TabPage();
            this.Get_Proc_Number_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Procedures_comboBox = new System.Windows.Forms.ComboBox();
            this.Statistics_tabControl.SuspendLayout();
            this.NumberOfVisits_tabPage.SuspendLayout();
            this.BirthDate_tabPage.SuspendLayout();
            this.Procedures_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Statistics_tabControl
            // 
            this.Statistics_tabControl.Controls.Add(this.NumberOfVisits_tabPage);
            this.Statistics_tabControl.Controls.Add(this.BirthDate_tabPage);
            this.Statistics_tabControl.Controls.Add(this.Procedures_tabPage);
            this.Statistics_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Statistics_tabControl.Location = new System.Drawing.Point(0, 0);
            this.Statistics_tabControl.Name = "Statistics_tabControl";
            this.Statistics_tabControl.SelectedIndex = 0;
            this.Statistics_tabControl.Size = new System.Drawing.Size(574, 371);
            this.Statistics_tabControl.TabIndex = 0;
            // 
            // NumberOfVisits_tabPage
            // 
            this.NumberOfVisits_tabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NumberOfVisits_tabPage.Controls.Add(this.Get_Number_Visits_button);
            this.NumberOfVisits_tabPage.Controls.Add(this.label15);
            this.NumberOfVisits_tabPage.Controls.Add(this.label14);
            this.NumberOfVisits_tabPage.Controls.Add(this.Visits_to_textBox);
            this.NumberOfVisits_tabPage.Controls.Add(this.Visits_from_textBox);
            this.NumberOfVisits_tabPage.Controls.Add(this.label11);
            this.NumberOfVisits_tabPage.Location = new System.Drawing.Point(4, 22);
            this.NumberOfVisits_tabPage.Name = "NumberOfVisits_tabPage";
            this.NumberOfVisits_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NumberOfVisits_tabPage.Size = new System.Drawing.Size(566, 345);
            this.NumberOfVisits_tabPage.TabIndex = 0;
            this.NumberOfVisits_tabPage.Text = "Visits";
            // 
            // Get_Number_Visits_button
            // 
            this.Get_Number_Visits_button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Get_Number_Visits_button.Location = new System.Drawing.Point(238, 248);
            this.Get_Number_Visits_button.Name = "Get_Number_Visits_button";
            this.Get_Number_Visits_button.Size = new System.Drawing.Size(93, 35);
            this.Get_Number_Visits_button.TabIndex = 74;
            this.Get_Number_Visits_button.Text = "Get";
            this.Get_Number_Visits_button.UseVisualStyleBackColor = true;
            this.Get_Number_Visits_button.Click += new System.EventHandler(this.Get_Number_Visits_button_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(298, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 23);
            this.label15.TabIndex = 73;
            this.label15.Text = "to";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(64, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 72;
            this.label14.Text = "from";
            // 
            // Visits_to_textBox
            // 
            this.Visits_to_textBox.Location = new System.Drawing.Point(347, 161);
            this.Visits_to_textBox.Name = "Visits_to_textBox";
            this.Visits_to_textBox.Size = new System.Drawing.Size(120, 20);
            this.Visits_to_textBox.TabIndex = 71;
            // 
            // Visits_from_textBox
            // 
            this.Visits_from_textBox.Location = new System.Drawing.Point(126, 161);
            this.Visits_from_textBox.Name = "Visits_from_textBox";
            this.Visits_from_textBox.Size = new System.Drawing.Size(119, 20);
            this.Visits_from_textBox.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(54, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(453, 23);
            this.label11.TabIndex = 61;
            this.label11.Text = "Get the Number of visits in a specific interval";
            // 
            // BirthDate_tabPage
            // 
            this.BirthDate_tabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BirthDate_tabPage.Controls.Add(this.Get_BirthDate_Button);
            this.BirthDate_tabPage.Controls.Add(this.label1);
            this.BirthDate_tabPage.Controls.Add(this.label2);
            this.BirthDate_tabPage.Controls.Add(this.Birth_date_to_textBox);
            this.BirthDate_tabPage.Controls.Add(this.BirthDate_from_textBox);
            this.BirthDate_tabPage.Controls.Add(this.label3);
            this.BirthDate_tabPage.Location = new System.Drawing.Point(4, 22);
            this.BirthDate_tabPage.Name = "BirthDate_tabPage";
            this.BirthDate_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BirthDate_tabPage.Size = new System.Drawing.Size(563, 344);
            this.BirthDate_tabPage.TabIndex = 2;
            this.BirthDate_tabPage.Text = "Birth date";
            // 
            // Get_BirthDate_Button
            // 
            this.Get_BirthDate_Button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Get_BirthDate_Button.Location = new System.Drawing.Point(239, 257);
            this.Get_BirthDate_Button.Name = "Get_BirthDate_Button";
            this.Get_BirthDate_Button.Size = new System.Drawing.Size(93, 35);
            this.Get_BirthDate_Button.TabIndex = 80;
            this.Get_BirthDate_Button.Text = "Get";
            this.Get_BirthDate_Button.UseVisualStyleBackColor = true;
            this.Get_BirthDate_Button.Click += new System.EventHandler(this.Get_BirthDate_Button_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "to";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 78;
            this.label2.Text = "from";
            // 
            // Birth_date_to_textBox
            // 
            this.Birth_date_to_textBox.Location = new System.Drawing.Point(348, 170);
            this.Birth_date_to_textBox.Name = "Birth_date_to_textBox";
            this.Birth_date_to_textBox.Size = new System.Drawing.Size(120, 20);
            this.Birth_date_to_textBox.TabIndex = 77;
            // 
            // BirthDate_from_textBox
            // 
            this.BirthDate_from_textBox.Location = new System.Drawing.Point(127, 170);
            this.BirthDate_from_textBox.Name = "BirthDate_from_textBox";
            this.BirthDate_from_textBox.Size = new System.Drawing.Size(119, 20);
            this.BirthDate_from_textBox.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(508, 23);
            this.label3.TabIndex = 75;
            this.label3.Text = "Get the Number of Birthdates in a specific interval";
            // 
            // Procedures_tabPage
            // 
            this.Procedures_tabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Procedures_tabPage.Controls.Add(this.Get_Proc_Number_Button);
            this.Procedures_tabPage.Controls.Add(this.label4);
            this.Procedures_tabPage.Controls.Add(this.Procedures_comboBox);
            this.Procedures_tabPage.Location = new System.Drawing.Point(4, 22);
            this.Procedures_tabPage.Name = "Procedures_tabPage";
            this.Procedures_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Procedures_tabPage.Size = new System.Drawing.Size(563, 344);
            this.Procedures_tabPage.TabIndex = 1;
            this.Procedures_tabPage.Text = "Procedures";
            // 
            // Get_Proc_Number_Button
            // 
            this.Get_Proc_Number_Button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Get_Proc_Number_Button.Location = new System.Drawing.Point(340, 166);
            this.Get_Proc_Number_Button.Name = "Get_Proc_Number_Button";
            this.Get_Proc_Number_Button.Size = new System.Drawing.Size(93, 35);
            this.Get_Proc_Number_Button.TabIndex = 81;
            this.Get_Proc_Number_Button.Text = "Get";
            this.Get_Proc_Number_Button.UseVisualStyleBackColor = true;
            this.Get_Proc_Number_Button.Click += new System.EventHandler(this.Get_Proc_Number_Button_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(103, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(341, 23);
            this.label4.TabIndex = 76;
            this.label4.Text = "Get the Number of each Procedure";
            // 
            // Procedures_comboBox
            // 
            this.Procedures_comboBox.FormattingEnabled = true;
            this.Procedures_comboBox.Location = new System.Drawing.Point(75, 174);
            this.Procedures_comboBox.Name = "Procedures_comboBox";
            this.Procedures_comboBox.Size = new System.Drawing.Size(160, 21);
            this.Procedures_comboBox.TabIndex = 67;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 371);
            this.Controls.Add(this.Statistics_tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Statistics_FormClosing);
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.Statistics_tabControl.ResumeLayout(false);
            this.NumberOfVisits_tabPage.ResumeLayout(false);
            this.NumberOfVisits_tabPage.PerformLayout();
            this.BirthDate_tabPage.ResumeLayout(false);
            this.BirthDate_tabPage.PerformLayout();
            this.Procedures_tabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Statistics_tabControl;
        private System.Windows.Forms.TabPage NumberOfVisits_tabPage;
        private System.Windows.Forms.TabPage Procedures_tabPage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Visits_to_textBox;
        private System.Windows.Forms.TextBox Visits_from_textBox;
        private System.Windows.Forms.Button Get_Number_Visits_button;
        private System.Windows.Forms.TabPage BirthDate_tabPage;
        private System.Windows.Forms.Button Get_BirthDate_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Birth_date_to_textBox;
        private System.Windows.Forms.TextBox BirthDate_from_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Procedures_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Get_Proc_Number_Button;
    }
}