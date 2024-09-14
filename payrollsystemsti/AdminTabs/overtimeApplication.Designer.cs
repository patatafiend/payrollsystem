namespace payrollsystemsti.AdminTabs
{
    partial class overtimeApplication
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.overtimegrid = new System.Windows.Forms.DataGridView();
            this.dgOvertimeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAppliedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.timeout = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.overtimegrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Justification:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "End:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Start:";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(70, 263);
            this.tbReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(366, 141);
            this.tbReason.TabIndex = 18;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(261, 457);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(177, 68);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Location = new System.Drawing.Point(70, 457);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(177, 68);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // overtimegrid
            // 
            this.overtimegrid.AllowUserToAddRows = false;
            this.overtimegrid.AllowUserToDeleteRows = false;
            this.overtimegrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimegrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.overtimegrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.overtimegrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgOvertimeID,
            this.dgAppliedDate,
            this.dgStart,
            this.dgEnd,
            this.dgReason,
            this.dgStatus});
            this.overtimegrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.overtimegrid.Location = new System.Drawing.Point(488, 62);
            this.overtimegrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.overtimegrid.Name = "overtimegrid";
            this.overtimegrid.ReadOnly = true;
            this.overtimegrid.RowHeadersWidth = 62;
            this.overtimegrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.overtimegrid.Size = new System.Drawing.Size(807, 586);
            this.overtimegrid.TabIndex = 24;
            // 
            // dgOvertimeID
            // 
            this.dgOvertimeID.HeaderText = "Overtime ID";
            this.dgOvertimeID.MinimumWidth = 8;
            this.dgOvertimeID.Name = "dgOvertimeID";
            this.dgOvertimeID.ReadOnly = true;
            // 
            // dgAppliedDate
            // 
            this.dgAppliedDate.HeaderText = "Date Applied";
            this.dgAppliedDate.MinimumWidth = 8;
            this.dgAppliedDate.Name = "dgAppliedDate";
            this.dgAppliedDate.ReadOnly = true;
            // 
            // dgStart
            // 
            this.dgStart.HeaderText = "From";
            this.dgStart.MinimumWidth = 8;
            this.dgStart.Name = "dgStart";
            this.dgStart.ReadOnly = true;
            // 
            // dgEnd
            // 
            this.dgEnd.HeaderText = "To";
            this.dgEnd.MinimumWidth = 8;
            this.dgEnd.Name = "dgEnd";
            this.dgEnd.ReadOnly = true;
            // 
            // dgReason
            // 
            this.dgReason.HeaderText = "Justification";
            this.dgReason.MinimumWidth = 8;
            this.dgReason.Name = "dgReason";
            this.dgReason.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.MinimumWidth = 8;
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // time
            // 
            this.time.CalendarFont = new System.Drawing.Font("Microsoft YaHei", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.CustomFormat = "hh:mm tt";
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.time.Location = new System.Drawing.Point(141, 82);
            this.time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(172, 35);
            this.time.TabIndex = 37;
            this.time.Value = new System.DateTime(2024, 5, 12, 17, 51, 0, 0);
            // 
            // timeout
            // 
            this.timeout.CalendarFont = new System.Drawing.Font("Microsoft YaHei", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeout.CustomFormat = "hh:mm tt";
            this.timeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.timeout.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeout.Location = new System.Drawing.Point(141, 131);
            this.timeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeout.Name = "timeout";
            this.timeout.ShowUpDown = true;
            this.timeout.Size = new System.Drawing.Size(172, 35);
            this.timeout.TabIndex = 38;
            this.timeout.Value = new System.DateTime(2024, 5, 12, 17, 51, 0, 0);
            // 
            // overtimeApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1353, 702);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.time);
            this.Controls.Add(this.overtimegrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "overtimeApplication";
            this.Text = "overtimeApplication";
            ((System.ComponentModel.ISupportInitialize)(this.overtimegrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView overtimegrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOvertimeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAppliedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.DateTimePicker timeout;
    }
}