﻿namespace payrollsystemsti.AdminTabs
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.overtimegrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(433, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Justification:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "End:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Start:";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(437, 109);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(356, 108);
            this.tbReason.TabIndex = 18;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(154, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 44);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.Location = new System.Drawing.Point(30, 178);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(118, 44);
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
            this.overtimegrid.Location = new System.Drawing.Point(30, 239);
            this.overtimegrid.Name = "overtimegrid";
            this.overtimegrid.ReadOnly = true;
            this.overtimegrid.RowHeadersWidth = 62;
            this.overtimegrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.overtimegrid.Size = new System.Drawing.Size(763, 300);
            this.overtimegrid.TabIndex = 24;
            this.overtimegrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.overtimegrid_CellContentClick);
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
            this.time.Location = new System.Drawing.Point(89, 126);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(116, 26);
            this.time.TabIndex = 37;
            this.time.Value = new System.DateTime(2024, 5, 12, 17, 51, 0, 0);
            // 
            // timeout
            // 
            this.timeout.CalendarFont = new System.Drawing.Font("Microsoft YaHei", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeout.CustomFormat = "hh:mm tt";
            this.timeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.timeout.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeout.Location = new System.Drawing.Point(265, 125);
            this.timeout.Name = "timeout";
            this.timeout.ShowUpDown = true;
            this.timeout.Size = new System.Drawing.Size(116, 26);
            this.timeout.TabIndex = 38;
            this.timeout.Value = new System.DateTime(2024, 5, 12, 17, 51, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(279, 178);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 44);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(24, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(207, 31);
            this.label11.TabIndex = 40;
            this.label11.Text = "Overtime Form";
            // 
            // date
            // 
            this.date.CustomFormat = "dddd, MM/dd/yyyy";
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(89, 86);
            this.date.Name = "date";
            this.date.ShowUpDown = true;
            this.date.Size = new System.Drawing.Size(292, 26);
            this.date.TabIndex = 41;
            this.date.Value = new System.DateTime(2024, 5, 12, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Date:";
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // overtimeApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1006, 572);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.time);
            this.Controls.Add(this.overtimegrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "overtimeApplication";
            this.Text = "overtimeApplication";
            this.Load += new System.EventHandler(this.overtimeApplication_Load);
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
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label1;
    }
}