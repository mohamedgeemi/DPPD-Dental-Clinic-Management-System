namespace DPPD_Dental_Clinic_Management_System
{
    partial class Search_Result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_Result));
            this.Close_button = new System.Windows.Forms.Button();
            this.Search_Result_dataGridView = new System.Windows.Forms.DataGridView();
            this.ViewPColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Result_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_button
            // 
            this.Close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Close_button.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_button.Location = new System.Drawing.Point(452, 346);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(144, 35);
            this.Close_button.TabIndex = 1;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // Search_Result_dataGridView
            // 
            this.Search_Result_dataGridView.AllowUserToAddRows = false;
            this.Search_Result_dataGridView.AllowUserToDeleteRows = false;
            this.Search_Result_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_Result_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_Result_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewPColumn});
            this.Search_Result_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.Search_Result_dataGridView.Name = "Search_Result_dataGridView";
            this.Search_Result_dataGridView.ReadOnly = true;
            this.Search_Result_dataGridView.Size = new System.Drawing.Size(1048, 333);
            this.Search_Result_dataGridView.TabIndex = 2;
            this.Search_Result_dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Search_Result_dataGridView_CellClick);
            // 
            // ViewPColumn
            // 
            this.ViewPColumn.HeaderText = "View Profile";
            this.ViewPColumn.Name = "ViewPColumn";
            this.ViewPColumn.ReadOnly = true;
            this.ViewPColumn.Text = "Click Me!";
            // 
            // Search_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 403);
            this.Controls.Add(this.Search_Result_dataGridView);
            this.Controls.Add(this.Close_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_Result";
            this.Text = "Search Result";
            ((System.ComponentModel.ISupportInitialize)(this.Search_Result_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.DataGridView Search_Result_dataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn ViewPColumn;
    }
}