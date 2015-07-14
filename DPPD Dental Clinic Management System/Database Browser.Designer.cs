namespace DPPD_Dental_Clinic_Management_System
{
    partial class Database_Browser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database_Browser));
            this.DB_dataGridView = new System.Windows.Forms.DataGridView();
            this.ViewProfileColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.home_noColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiefCompColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicalAlertColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DMFColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dmfColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEFColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VPColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DB_Browser_tabControl = new System.Windows.Forms.TabControl();
            this.EC_tabPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgressBar_Percentage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DB_browser_progressBar = new System.Windows.Forms.ProgressBar();
            this.DS_tabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DB_Tables_comboBox = new System.Windows.Forms.ComboBox();
            this.ProgressBar_timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.NumOfPatients1 = new System.Windows.Forms.Label();
            this.NumOfPatients2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DB_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.DB_Browser_tabControl.SuspendLayout();
            this.EC_tabPage.SuspendLayout();
            this.DS_tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // DB_dataGridView
            // 
            this.DB_dataGridView.AllowUserToAddRows = false;
            this.DB_dataGridView.AllowUserToDeleteRows = false;
            this.DB_dataGridView.AllowUserToOrderColumns = true;
            this.DB_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DB_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DB_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewProfileColumn,
            this.IDColumn,
            this.AgeColumn,
            this.NameColumn,
            this.home_noColumn,
            this.MobileNumColumn,
            this.AddressColumn,
            this.ChiefCompColumn,
            this.MedicalAlertColumn,
            this.VisitDateColumn,
            this.BirthDayColumn,
            this.SexColumn,
            this.RMColumn,
            this.DMFColumn,
            this._dmfColumn,
            this.DEFColumn,
            this.CommentsColumn});
            this.DB_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.DB_dataGridView.Name = "DB_dataGridView";
            this.DB_dataGridView.ReadOnly = true;
            this.DB_dataGridView.Size = new System.Drawing.Size(1104, 394);
            this.DB_dataGridView.TabIndex = 0;
            this.DB_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_dataGridView_CellClick);
            // 
            // ViewProfileColumn
            // 
            this.ViewProfileColumn.HeaderText = "ViewProfile";
            this.ViewProfileColumn.Name = "ViewProfileColumn";
            this.ViewProfileColumn.ReadOnly = true;
            this.ViewProfileColumn.Text = "Click Me!";
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            // 
            // AgeColumn
            // 
            this.AgeColumn.HeaderText = "Age";
            this.AgeColumn.Name = "AgeColumn";
            this.AgeColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // home_noColumn
            // 
            this.home_noColumn.HeaderText = "Home Number";
            this.home_noColumn.Name = "home_noColumn";
            this.home_noColumn.ReadOnly = true;
            // 
            // MobileNumColumn
            // 
            this.MobileNumColumn.HeaderText = "Mobile Number";
            this.MobileNumColumn.Name = "MobileNumColumn";
            this.MobileNumColumn.ReadOnly = true;
            // 
            // AddressColumn
            // 
            this.AddressColumn.HeaderText = "Address";
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.ReadOnly = true;
            // 
            // ChiefCompColumn
            // 
            this.ChiefCompColumn.HeaderText = "Chief Complaint";
            this.ChiefCompColumn.Name = "ChiefCompColumn";
            this.ChiefCompColumn.ReadOnly = true;
            // 
            // MedicalAlertColumn
            // 
            this.MedicalAlertColumn.HeaderText = "Medical Alert";
            this.MedicalAlertColumn.Name = "MedicalAlertColumn";
            this.MedicalAlertColumn.ReadOnly = true;
            // 
            // VisitDateColumn
            // 
            this.VisitDateColumn.HeaderText = "Visit Date";
            this.VisitDateColumn.Name = "VisitDateColumn";
            this.VisitDateColumn.ReadOnly = true;
            // 
            // BirthDayColumn
            // 
            this.BirthDayColumn.HeaderText = "Birthday";
            this.BirthDayColumn.Name = "BirthDayColumn";
            this.BirthDayColumn.ReadOnly = true;
            // 
            // SexColumn
            // 
            this.SexColumn.HeaderText = "Sex";
            this.SexColumn.Name = "SexColumn";
            this.SexColumn.ReadOnly = true;
            // 
            // RMColumn
            // 
            this.RMColumn.HeaderText = "Relative Marriage";
            this.RMColumn.Name = "RMColumn";
            this.RMColumn.ReadOnly = true;
            // 
            // DMFColumn
            // 
            this.DMFColumn.HeaderText = "DMF";
            this.DMFColumn.Name = "DMFColumn";
            this.DMFColumn.ReadOnly = true;
            // 
            // _dmfColumn
            // 
            this._dmfColumn.HeaderText = "dmf";
            this._dmfColumn.Name = "_dmfColumn";
            this._dmfColumn.ReadOnly = true;
            // 
            // DEFColumn
            // 
            this.DEFColumn.HeaderText = "DEF";
            this.DEFColumn.Name = "DEFColumn";
            this.DEFColumn.ReadOnly = true;
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            this.CommentsColumn.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VPColumn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1104, 396);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // VPColumn
            // 
            this.VPColumn.HeaderText = "View Profile";
            this.VPColumn.Name = "VPColumn";
            this.VPColumn.ReadOnly = true;
            this.VPColumn.Text = "Click Me";
            this.VPColumn.ToolTipText = "Click Me";
            // 
            // DB_Browser_tabControl
            // 
            this.DB_Browser_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DB_Browser_tabControl.Controls.Add(this.EC_tabPage);
            this.DB_Browser_tabControl.Controls.Add(this.DS_tabPage);
            this.DB_Browser_tabControl.Location = new System.Drawing.Point(0, 0);
            this.DB_Browser_tabControl.Name = "DB_Browser_tabControl";
            this.DB_Browser_tabControl.SelectedIndex = 0;
            this.DB_Browser_tabControl.Size = new System.Drawing.Size(1112, 481);
            this.DB_Browser_tabControl.TabIndex = 2;
            // 
            // EC_tabPage
            // 
            this.EC_tabPage.Controls.Add(this.NumOfPatients1);
            this.EC_tabPage.Controls.Add(this.label4);
            this.EC_tabPage.Controls.Add(this.label3);
            this.EC_tabPage.Controls.Add(this.ProgressBar_Percentage);
            this.EC_tabPage.Controls.Add(this.label1);
            this.EC_tabPage.Controls.Add(this.DB_browser_progressBar);
            this.EC_tabPage.Controls.Add(this.DB_dataGridView);
            this.EC_tabPage.Location = new System.Drawing.Point(4, 22);
            this.EC_tabPage.Name = "EC_tabPage";
            this.EC_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EC_tabPage.Size = new System.Drawing.Size(1104, 455);
            this.EC_tabPage.TabIndex = 0;
            this.EC_tabPage.Text = "Entity View";
            this.EC_tabPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1035, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "%";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ProgressBar_Percentage
            // 
            this.ProgressBar_Percentage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBar_Percentage.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar_Percentage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressBar_Percentage.Location = new System.Drawing.Point(1002, 414);
            this.ProgressBar_Percentage.Name = "ProgressBar_Percentage";
            this.ProgressBar_Percentage.Size = new System.Drawing.Size(41, 26);
            this.ProgressBar_Percentage.TabIndex = 5;
            this.ProgressBar_Percentage.Text = "100";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(551, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loading Database";
            // 
            // DB_browser_progressBar
            // 
            this.DB_browser_progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DB_browser_progressBar.Location = new System.Drawing.Point(765, 407);
            this.DB_browser_progressBar.Name = "DB_browser_progressBar";
            this.DB_browser_progressBar.Size = new System.Drawing.Size(208, 36);
            this.DB_browser_progressBar.TabIndex = 1;
            // 
            // DS_tabPage
            // 
            this.DS_tabPage.Controls.Add(this.NumOfPatients2);
            this.DS_tabPage.Controls.Add(this.label6);
            this.DS_tabPage.Controls.Add(this.label2);
            this.DS_tabPage.Controls.Add(this.DB_Tables_comboBox);
            this.DS_tabPage.Controls.Add(this.dataGridView1);
            this.DS_tabPage.Location = new System.Drawing.Point(4, 22);
            this.DS_tabPage.Name = "DS_tabPage";
            this.DS_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DS_tabPage.Size = new System.Drawing.Size(1104, 455);
            this.DS_tabPage.TabIndex = 1;
            this.DS_tabPage.Text = "Data Source View";
            this.DS_tabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(724, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose Table";
            // 
            // DB_Tables_comboBox
            // 
            this.DB_Tables_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DB_Tables_comboBox.FormattingEnabled = true;
            this.DB_Tables_comboBox.Items.AddRange(new object[] {
            "Patient_info",
            "Dates",
            "Diagnosis",
            "X-ray images",
            "DiagnosisList",
            "ProcedureList"});
            this.DB_Tables_comboBox.Location = new System.Drawing.Point(875, 414);
            this.DB_Tables_comboBox.Name = "DB_Tables_comboBox";
            this.DB_Tables_comboBox.Size = new System.Drawing.Size(160, 21);
            this.DB_Tables_comboBox.TabIndex = 2;
            this.DB_Tables_comboBox.SelectedIndexChanged += new System.EventHandler(this.DB_Tables_comboBox_SelectedIndexChanged);
            // 
            // ProgressBar_timer
            // 
            this.ProgressBar_timer.Interval = 1;
            this.ProgressBar_timer.Tick += new System.EventHandler(this.ProgressBar_timer_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number Of Patients";
            // 
            // NumOfPatients1
            // 
            this.NumOfPatients1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NumOfPatients1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfPatients1.ForeColor = System.Drawing.Color.DarkOrange;
            this.NumOfPatients1.Location = new System.Drawing.Point(261, 414);
            this.NumOfPatients1.Name = "NumOfPatients1";
            this.NumOfPatients1.Size = new System.Drawing.Size(59, 23);
            this.NumOfPatients1.TabIndex = 8;
            this.NumOfPatients1.Text = "Num";
            // 
            // NumOfPatients2
            // 
            this.NumOfPatients2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NumOfPatients2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfPatients2.ForeColor = System.Drawing.Color.DarkOrange;
            this.NumOfPatients2.Location = new System.Drawing.Point(261, 414);
            this.NumOfPatients2.Name = "NumOfPatients2";
            this.NumOfPatients2.Size = new System.Drawing.Size(59, 23);
            this.NumOfPatients2.TabIndex = 10;
            this.NumOfPatients2.Text = "Num";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number Of Patients";
            // 
            // Database_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 481);
            this.Controls.Add(this.DB_Browser_tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Database_Browser";
            this.Text = "Database_Browser";
            ((System.ComponentModel.ISupportInitialize)(this.DB_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.DB_Browser_tabControl.ResumeLayout(false);
            this.EC_tabPage.ResumeLayout(false);
            this.DS_tabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DB_dataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn VPColumn;
        private System.Windows.Forms.TabControl DB_Browser_tabControl;
        private System.Windows.Forms.TabPage EC_tabPage;
        private System.Windows.Forms.TabPage DS_tabPage;
        private System.Windows.Forms.DataGridViewButtonColumn ViewProfileColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn home_noColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiefCompColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicalAlertColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DMFColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dmfColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEFColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;
        private System.Windows.Forms.ComboBox DB_Tables_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar DB_browser_progressBar;
        private System.Windows.Forms.Timer ProgressBar_timer;
        private System.Windows.Forms.Label ProgressBar_Percentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NumOfPatients1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label NumOfPatients2;
        private System.Windows.Forms.Label label6;
    }
}