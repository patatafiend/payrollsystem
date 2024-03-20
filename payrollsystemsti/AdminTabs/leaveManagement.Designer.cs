namespace payrollsystemsti.AdminTabs
{
    partial class leaveManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(leaveManagement));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLeaveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbLM = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgLeaveType,
            this.dgName,
            this.dgStatus});
            this.dataGridView1.Location = new System.Drawing.Point(84, 202);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(833, 342);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "Employee ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            // 
            // dgLeaveType
            // 
            this.dgLeaveType.HeaderText = "Leave Type";
            this.dgLeaveType.Name = "dgLeaveType";
            this.dgLeaveType.ReadOnly = true;
            // 
            // dgName
            // 
            this.dgName.HeaderText = "Name";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // lbLM
            // 
            this.lbLM.AutoSize = true;
            this.lbLM.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLM.ForeColor = System.Drawing.Color.Crimson;
            this.lbLM.Location = new System.Drawing.Point(78, 29);
            this.lbLM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLM.Name = "lbLM";
            this.lbLM.Size = new System.Drawing.Size(278, 32);
            this.lbLM.TabIndex = 9;
            this.lbLM.Text = "Leave Management";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Teal;
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.SystemColors.Control;
            this.btnView.Location = new System.Drawing.Point(81, 151);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(118, 44);
            this.btnView.TabIndex = 25;
            this.btnView.Text = "View Details";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(218, 151);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 44);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReload.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(879, 156);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(38, 39);
            this.btnReload.TabIndex = 27;
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // leaveManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(974, 701);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lbLM);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "leaveManagement";
            this.Text = "leaveManagement";
            this.Load += new System.EventHandler(this.leaveManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbLM;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
    }
}