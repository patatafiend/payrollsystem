namespace payrollsystemsti
{
    partial class IncentivesM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBatch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSingle = new System.Windows.Forms.Button();
            this.dg1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg3rd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIsDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(195, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 97;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(49, 118);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(83, 19);
            this.lb1.TabIndex = 94;
            this.lb1.Text = "Incentives :";
            // 
            // tb1
            // 
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(52, 143);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(150, 25);
            this.tb1.TabIndex = 93;
            this.tb1.TextChanged += new System.EventHandler(this.tb1_TextChanged);
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg1st,
            this.dg2nd,
            this.dg3rd,
            this.dgRemarks,
            this.dgIsDeactivated});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Location = new System.Drawing.Point(54, 350);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(802, 211);
            this.dataGridView1.TabIndex = 91;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // btnBatch
            // 
            this.btnBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatch.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatch.Enabled = false;
            this.btnBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBatch.Location = new System.Drawing.Point(453, 299);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(118, 44);
            this.btnBatch.TabIndex = 90;
            this.btnBatch.Text = "Batch";
            this.btnBatch.UseVisualStyleBackColor = false;
            this.btnBatch.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(46, 40);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 42);
            this.label11.TabIndex = 89;
            this.label11.Text = "Incentives";
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Name",
            "Department"});
            this.cbFilter.Location = new System.Drawing.Point(735, 281);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 24);
            this.cbFilter.TabIndex = 98;
            // 
            // tbRemarks
            // 
            this.tbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.Location = new System.Drawing.Point(53, 205);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(260, 80);
            this.tbRemarks.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 100;
            this.label1.Text = "Remarks:";
            // 
            // btnSingle
            // 
            this.btnSingle.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSingle.Enabled = false;
            this.btnSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSingle.Location = new System.Drawing.Point(54, 299);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(118, 44);
            this.btnSingle.TabIndex = 101;
            this.btnSingle.Text = "Single";
            this.btnSingle.UseVisualStyleBackColor = false;
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // dg1st
            // 
            this.dg1st.HeaderText = "ID";
            this.dg1st.Name = "dg1st";
            this.dg1st.ReadOnly = true;
            this.dg1st.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dg1st.Visible = false;
            // 
            // dg2nd
            // 
            this.dg2nd.HeaderText = "Employee Name";
            this.dg2nd.Name = "dg2nd";
            this.dg2nd.ReadOnly = true;
            // 
            // dg3rd
            // 
            this.dg3rd.HeaderText = "Incentives";
            this.dg3rd.Name = "dg3rd";
            this.dg3rd.ReadOnly = true;
            // 
            // dgRemarks
            // 
            this.dgRemarks.HeaderText = "Remarks";
            this.dgRemarks.Name = "dgRemarks";
            this.dgRemarks.ReadOnly = true;
            // 
            // dgIsDeactivated
            // 
            this.dgIsDeactivated.HeaderText = "IsDeactivated";
            this.dgIsDeactivated.Name = "dgIsDeactivated";
            this.dgIsDeactivated.ReadOnly = true;
            this.dgIsDeactivated.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbSearch.Location = new System.Drawing.Point(684, 311);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(172, 23);
            this.tbSearch.TabIndex = 102;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // IncentivesM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 574);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnSingle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRemarks);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IncentivesM";
            this.Text = "IncentivesM";
            this.Load += new System.EventHandler(this.IncentivesM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg3rd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeactivated;
        private System.Windows.Forms.TextBox tbSearch;
    }
}