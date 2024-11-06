namespace payrollsystemsti
{
    partial class OvertimeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OvertimeManagement));
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lbLM = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReload = new System.Windows.Forms.Button();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLeaveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Crimson;
            this.btnReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReject.Location = new System.Drawing.Point(332, 119);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(134, 56);
            this.btnReject.TabIndex = 37;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnApprove.Location = new System.Drawing.Point(192, 119);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(134, 56);
            this.btnApprove.TabIndex = 36;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Teal;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.SystemColors.Control;
            this.btnView.Location = new System.Drawing.Point(52, 119);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(134, 56);
            this.btnView.TabIndex = 34;
            this.btnView.Text = "View Details";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lbLM
            // 
            this.lbLM.AutoSize = true;
            this.lbLM.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLM.ForeColor = System.Drawing.Color.Crimson;
            this.lbLM.Location = new System.Drawing.Point(45, 37);
            this.lbLM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLM.Name = "lbLM";
            this.lbLM.Size = new System.Drawing.Size(390, 39);
            this.lbLM.TabIndex = 33;
            this.lbLM.Text = "Overtime Management";
            this.lbLM.Click += new System.EventHandler(this.lbLM_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgName,
            this.dgLeaveType,
            this.dgStatus,
            this.dgDateStart,
            this.dgDateEnd});
            this.dataGridView1.Location = new System.Drawing.Point(52, 182);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(755, 368);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(472, 130);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(42, 34);
            this.btnReload.TabIndex = 35;
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "Employee ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            this.dgEmpID.Visible = false;
            // 
            // dgName
            // 
            this.dgName.HeaderText = "Name";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            // 
            // dgLeaveType
            // 
            this.dgLeaveType.HeaderText = "OT Type";
            this.dgLeaveType.Name = "dgLeaveType";
            this.dgLeaveType.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // dgDateStart
            // 
            this.dgDateStart.HeaderText = "DateStart";
            this.dgDateStart.Name = "dgDateStart";
            this.dgDateStart.ReadOnly = true;
            this.dgDateStart.Visible = false;
            // 
            // dgDateEnd
            // 
            this.dgDateEnd.HeaderText = "DateEnd";
            this.dgDateEnd.Name = "dgDateEnd";
            this.dgDateEnd.ReadOnly = true;
            this.dgDateEnd.Visible = false;
            // 
            // OvertimeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(865, 648);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lbLM);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OvertimeManagement";
            this.Text = "OvertimeManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lbLM;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDateEnd;
    }
}