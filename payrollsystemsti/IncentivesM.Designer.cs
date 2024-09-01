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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lb1 = new System.Windows.Forms.Label();
			this.tb1 = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dg1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dg2nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dg3rd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dg6th = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgIsDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Crimson;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Location = new System.Drawing.Point(185, 222);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(118, 44);
			this.btnCancel.TabIndex = 97;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Visible = false;
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
            this.dg6th,
            this.dgIsDeactivated});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Location = new System.Drawing.Point(52, 273);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(657, 237);
			this.dataGridView1.TabIndex = 91;
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
			// dg6th
			// 
			this.dg6th.HeaderText = "Adjustment";
			this.dg6th.Name = "dg6th";
			this.dg6th.ReadOnly = true;
			this.dg6th.Visible = false;
			// 
			// dgIsDeactivated
			// 
			this.dgIsDeactivated.HeaderText = "IsDeactivated";
			this.dgIsDeactivated.Name = "dgIsDeactivated";
			this.dgIsDeactivated.ReadOnly = true;
			this.dgIsDeactivated.Visible = false;
			// 
			// btnUpdate
			// 
			this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnUpdate.Location = new System.Drawing.Point(52, 222);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(118, 44);
			this.btnUpdate.TabIndex = 90;
			this.btnUpdate.Text = "Edit";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Crimson;
			this.label11.Location = new System.Drawing.Point(46, 40);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(202, 44);
			this.label11.TabIndex = 89;
			this.label11.Text = "Incentives";
			// 
			// IncentivesM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(913, 574);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lb1);
			this.Controls.Add(this.tb1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.label11);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "IncentivesM";
			this.Text = "IncentivesM";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg2nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg3rd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg6th;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeactivated;
    }
}