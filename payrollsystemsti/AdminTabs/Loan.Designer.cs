namespace payrollsystemsti.AdminTabs
{
    partial class Loan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dg1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg2nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg3rd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg4th = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg5th = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIsDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHDMF = new System.Windows.Forms.TextBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.tbSSS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg1st,
            this.dg2nd,
            this.dg3rd,
            this.dg4th,
            this.dg5th,
            this.dgIsDeactivated});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(283, 65);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(666, 462);
            this.dataGridView1.TabIndex = 74;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dg1st
            // 
            this.dg1st.HeaderText = "ID";
            this.dg1st.Name = "dg1st";
            this.dg1st.ReadOnly = true;
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
            this.dg3rd.HeaderText = "SSS";
            this.dg3rd.Name = "dg3rd";
            this.dg3rd.ReadOnly = true;
            // 
            // dg4th
            // 
            this.dg4th.HeaderText = "HDMF";
            this.dg4th.Name = "dg4th";
            this.dg4th.ReadOnly = true;
            // 
            // dg5th
            // 
            this.dg5th.HeaderText = "Company";
            this.dg5th.Name = "dg5th";
            this.dg5th.ReadOnly = true;
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
            this.tbSearch.Location = new System.Drawing.Point(777, 35);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(172, 23);
            this.tbSearch.TabIndex = 78;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(407, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 85;
            this.label1.Text = "HDMF Loan:";
            // 
            // tbHDMF
            // 
            this.tbHDMF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHDMF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHDMF.Location = new System.Drawing.Point(15, 233);
            this.tbHDMF.Multiline = true;
            this.tbHDMF.Name = "tbHDMF";
            this.tbHDMF.Size = new System.Drawing.Size(232, 32);
            this.tbHDMF.TabIndex = 84;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(9, 110);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(89, 22);
            this.lb1.TabIndex = 83;
            this.lb1.Text = "SSS Loan:";
            // 
            // tbSSS
            // 
            this.tbSSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSSS.Location = new System.Drawing.Point(12, 135);
            this.tbSSS.Multiline = true;
            this.tbSSS.Name = "tbSSS";
            this.tbSSS.Size = new System.Drawing.Size(232, 32);
            this.tbSSS.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 22);
            this.label2.TabIndex = 87;
            this.label2.Text = "Company Loan:";
            // 
            // tbCompany
            // 
            this.tbCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompany.Location = new System.Drawing.Point(15, 334);
            this.tbCompany.Multiline = true;
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(232, 32);
            this.tbCompany.TabIndex = 86;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(283, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 44);
            this.btnSave.TabIndex = 88;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 560);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHDMF);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.tbSSS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Loan";
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.Loan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg3rd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg4th;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg5th;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeactivated;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHDMF;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox tbSSS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Button btnSave;
    }
}