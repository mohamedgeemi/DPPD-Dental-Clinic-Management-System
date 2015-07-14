namespace DPPD_Dental_Clinic_Management_System
{
    partial class Delete_Patients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Delete_Patients));
            this.label1 = new System.Windows.Forms.Label();
            this.Delete_from_textBox = new System.Windows.Forms.TextBox();
            this.Delete_to_textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Delete_patients_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Delete Patients With ID";
            // 
            // Delete_from_textBox
            // 
            this.Delete_from_textBox.Location = new System.Drawing.Point(123, 161);
            this.Delete_from_textBox.Name = "Delete_from_textBox";
            this.Delete_from_textBox.Size = new System.Drawing.Size(101, 20);
            this.Delete_from_textBox.TabIndex = 6;
            // 
            // Delete_to_textBox
            // 
            this.Delete_to_textBox.Location = new System.Drawing.Point(337, 161);
            this.Delete_to_textBox.Name = "Delete_to_textBox";
            this.Delete_to_textBox.Size = new System.Drawing.Size(101, 20);
            this.Delete_to_textBox.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(50, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 69;
            this.label14.Text = "from";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(298, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 23);
            this.label15.TabIndex = 70;
            this.label15.Text = "to";
            // 
            // Delete_patients_button
            // 
            this.Delete_patients_button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_patients_button.Location = new System.Drawing.Point(188, 235);
            this.Delete_patients_button.Name = "Delete_patients_button";
            this.Delete_patients_button.Size = new System.Drawing.Size(110, 35);
            this.Delete_patients_button.TabIndex = 71;
            this.Delete_patients_button.Text = "Delete";
            this.Delete_patients_button.UseVisualStyleBackColor = true;
            this.Delete_patients_button.Click += new System.EventHandler(this.Delete_patients_button_Click);
            // 
            // Delete_Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 329);
            this.Controls.Add(this.Delete_patients_button);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Delete_to_textBox);
            this.Controls.Add(this.Delete_from_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Delete_Patients";
            this.Text = "Delete Patients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Delete_Patients_FormClosing);
            this.Load += new System.EventHandler(this.Delete_Patients_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Delete_from_textBox;
        private System.Windows.Forms.TextBox Delete_to_textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Delete_patients_button;
    }
}