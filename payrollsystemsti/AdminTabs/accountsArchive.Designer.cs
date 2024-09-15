namespace payrollsystemsti.AdminTabs
{
    partial class accountsArchive
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
            this.archives = new System.Windows.Forms.DataGridView();
            this.dgEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActivate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.btnovertime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.archives)).BeginInit();
            this.SuspendLayout();
            // 
            // archives
            // 
            this.archives.AllowUserToAddRows = false;
            this.archives.AllowUserToDeleteRows = false;
            this.archives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.archives.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.archives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.archives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmployeeID,
            this.dgFullName});
            this.archives.Location = new System.Drawing.Point(146, 231);
            this.archives.Margin = new System.Windows.Forms.Padding(6);
            this.archives.Name = "archives";
            this.archives.ReadOnly = true;
            this.archives.RowHeadersWidth = 62;
            this.archives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.archives.Size = new System.Drawing.Size(944, 412);
            this.archives.TabIndex = 4;
            this.archives.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.archives_MouseDoubleClick);
            // 
            // dgEmployeeID
            // 
            this.dgEmployeeID.HeaderText = "Employee ID";
            this.dgEmployeeID.MinimumWidth = 8;
            this.dgEmployeeID.Name = "dgEmployeeID";
            this.dgEmployeeID.ReadOnly = true;
            // 
            // dgFullName
            // 
            this.dgFullName.HeaderText = "Name";
            this.dgFullName.MinimumWidth = 8;
            this.dgFullName.Name = "dgFullName";
            this.dgFullName.ReadOnly = true;
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivate.Enabled = false;
            this.btnActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActivate.Location = new System.Drawing.Point(912, 152);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(177, 68);
            this.btnActivate.TabIndex = 27;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(136, 46);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 47);
            this.label11.TabIndex = 33;
            this.label11.Text = "Archive";
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(146, 175);
            this.searchbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(148, 26);
            this.searchbox.TabIndex = 34;
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            // 
            // btnovertime
            // 
            this.btnovertime.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnovertime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnovertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnovertime.ForeColor = System.Drawing.SystemColors.Control;
            this.btnovertime.Location = new System.Drawing.Point(529, 133);
            this.btnovertime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnovertime.Name = "btnovertime";
            this.btnovertime.Size = new System.Drawing.Size(177, 68);
            this.btnovertime.TabIndex = 35;
            this.btnovertime.Text = "Overtime";
            this.btnovertime.UseVisualStyleBackColor = false;
            this.btnovertime.Click += new System.EventHandler(this.btnovertime_Click);
            // 
            // accountsArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1236, 705);
            this.Controls.Add(this.btnovertime);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.archives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "accountsArchive";
            this.Text = "accountsArchive";
            this.Load += new System.EventHandler(this.accountsArchive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.archives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView archives;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFullName;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button btnovertime;
    }
}