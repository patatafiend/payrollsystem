namespace payrollsystemsti.AdminTabs
{
    partial class Printing
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
            this.btnPayslip = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTHW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPayslip
            // 
            this.btnPayslip.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnPayslip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayslip.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayslip.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPayslip.Location = new System.Drawing.Point(36, 36);
            this.btnPayslip.Name = "btnPayslip";
            this.btnPayslip.Size = new System.Drawing.Size(120, 47);
            this.btnPayslip.TabIndex = 40;
            this.btnPayslip.Text = "Print";
            this.btnPayslip.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgFullName,
            this.dgBasic,
            this.dgTHW,
            this.dgOT,
            this.dgLate,
            this.dgAbsent});
            this.dataGridView1.Location = new System.Drawing.Point(36, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(725, 301);
            this.dataGridView1.TabIndex = 41;
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "EmployeeID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            // 
            // dgFullName
            // 
            this.dgFullName.HeaderText = "Name";
            this.dgFullName.Name = "dgFullName";
            this.dgFullName.ReadOnly = true;
            // 
            // dgBasic
            // 
            this.dgBasic.HeaderText = "Basic Rate";
            this.dgBasic.Name = "dgBasic";
            this.dgBasic.ReadOnly = true;
            // 
            // dgTHW
            // 
            this.dgTHW.HeaderText = "TotalHoursWorked";
            this.dgTHW.Name = "dgTHW";
            this.dgTHW.ReadOnly = true;
            // 
            // dgOT
            // 
            this.dgOT.HeaderText = "OvertimeHours";
            this.dgOT.Name = "dgOT";
            this.dgOT.ReadOnly = true;
            this.dgOT.Visible = false;
            // 
            // dgLate
            // 
            this.dgLate.HeaderText = "TotalLate";
            this.dgLate.Name = "dgLate";
            this.dgLate.ReadOnly = true;
            this.dgLate.Visible = false;
            // 
            // dgAbsent
            // 
            this.dgAbsent.HeaderText = "TotalAbsent";
            this.dgAbsent.Name = "dgAbsent";
            this.dgAbsent.ReadOnly = true;
            this.dgAbsent.Visible = false;
            // 
            // Printing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPayslip);
            this.Name = "Printing";
            this.Text = "Printing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPayslip;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTHW;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAbsent;
    }
}