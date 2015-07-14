namespace DPPD_Dental_Clinic_Management_System
{
    partial class Create_New_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_New_Account));
            this.newUNtextBox = new System.Windows.Forms.TextBox();
            this.newPasstextBox = new System.Windows.Forms.TextBox();
            this.newPassRetextbox = new System.Windows.Forms.TextBox();
            this.Create_new_Account_Button = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newUNtextBox
            // 
            this.newUNtextBox.Location = new System.Drawing.Point(227, 89);
            this.newUNtextBox.Name = "newUNtextBox";
            this.newUNtextBox.Size = new System.Drawing.Size(309, 20);
            this.newUNtextBox.TabIndex = 0;
            // 
            // newPasstextBox
            // 
            this.newPasstextBox.Location = new System.Drawing.Point(227, 144);
            this.newPasstextBox.Name = "newPasstextBox";
            this.newPasstextBox.Size = new System.Drawing.Size(309, 20);
            this.newPasstextBox.TabIndex = 1;
            // 
            // newPassRetextbox
            // 
            this.newPassRetextbox.Location = new System.Drawing.Point(227, 197);
            this.newPassRetextbox.Name = "newPassRetextbox";
            this.newPassRetextbox.Size = new System.Drawing.Size(309, 20);
            this.newPassRetextbox.TabIndex = 2;
            // 
            // Create_new_Account_Button
            // 
            this.Create_new_Account_Button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_new_Account_Button.Location = new System.Drawing.Point(208, 259);
            this.Create_new_Account_Button.Name = "Create_new_Account_Button";
            this.Create_new_Account_Button.Size = new System.Drawing.Size(116, 47);
            this.Create_new_Account_Button.TabIndex = 6;
            this.Create_new_Account_Button.Text = "Create";
            this.Create_new_Account_Button.UseVisualStyleBackColor = true;
            this.Create_new_Account_Button.Click += new System.EventHandler(this.Create_new_Account_Button_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(129, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(277, 23);
            this.label15.TabIndex = 33;
            this.label15.Text = "*NOTE that: Passowrd maximum length is 20";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 34;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Password";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "Re-enter Password";
            // 
            // Create_New_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 331);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Create_new_Account_Button);
            this.Controls.Add(this.newPassRetextbox);
            this.Controls.Add(this.newPasstextBox);
            this.Controls.Add(this.newUNtextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Create_New_Account";
            this.Text = "Create New Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newUNtextBox;
        private System.Windows.Forms.TextBox newPasstextBox;
        private System.Windows.Forms.TextBox newPassRetextbox;
        private System.Windows.Forms.Button Create_new_Account_Button;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}