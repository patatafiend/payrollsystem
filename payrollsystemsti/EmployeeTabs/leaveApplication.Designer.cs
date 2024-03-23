﻿namespace payrollsystemsti.EmployeeTabs
{
    partial class leaveApplication
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
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dgLeaveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgLeaveCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgAppliedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgImageData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.cbLeaves = new System.Windows.Forms.ComboBox();
			this.tbReason = new System.Windows.Forms.TextBox();
			this.dtStart = new System.Windows.Forms.DateTimePicker();
			this.dtEnd = new System.Windows.Forms.DateTimePicker();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.lbFileName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.pbMedCert = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMedCert)).BeginInit();
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
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgLeaveID,
            this.dgLeaveCategory,
            this.dgAppliedDate,
            this.dgStart,
            this.dgEnd,
            this.dgReason,
            this.dgStatus,
            this.dgImageData,
            this.dgFileName});
			this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView1.Location = new System.Drawing.Point(46, 446);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(744, 175);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			// 
			// dgLeaveID
			// 
			this.dgLeaveID.HeaderText = "Leave ID";
			this.dgLeaveID.Name = "dgLeaveID";
			this.dgLeaveID.ReadOnly = true;
			// 
			// dgLeaveCategory
			// 
			this.dgLeaveCategory.HeaderText = "Leave Category";
			this.dgLeaveCategory.Name = "dgLeaveCategory";
			this.dgLeaveCategory.ReadOnly = true;
			// 
			// dgAppliedDate
			// 
			this.dgAppliedDate.HeaderText = "Date Applied";
			this.dgAppliedDate.Name = "dgAppliedDate";
			this.dgAppliedDate.ReadOnly = true;
			// 
			// dgStart
			// 
			this.dgStart.HeaderText = "Date Start";
			this.dgStart.Name = "dgStart";
			this.dgStart.ReadOnly = true;
			// 
			// dgEnd
			// 
			this.dgEnd.HeaderText = "Date End";
			this.dgEnd.Name = "dgEnd";
			this.dgEnd.ReadOnly = true;
			// 
			// dgReason
			// 
			this.dgReason.HeaderText = "Reason";
			this.dgReason.Name = "dgReason";
			this.dgReason.ReadOnly = true;
			// 
			// dgStatus
			// 
			this.dgStatus.HeaderText = "Status";
			this.dgStatus.Name = "dgStatus";
			this.dgStatus.ReadOnly = true;
			// 
			// dgImageData
			// 
			this.dgImageData.HeaderText = "ImageData";
			this.dgImageData.Name = "dgImageData";
			this.dgImageData.ReadOnly = true;
			this.dgImageData.Visible = false;
			// 
			// dgFileName
			// 
			this.dgFileName.HeaderText = "File Name";
			this.dgFileName.Name = "dgFileName";
			this.dgFileName.ReadOnly = true;
			this.dgFileName.Visible = false;
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSubmit.ForeColor = System.Drawing.SystemColors.Control;
			this.btnSubmit.Location = new System.Drawing.Point(51, 381);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(118, 44);
			this.btnSubmit.TabIndex = 1;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.BackColor = System.Drawing.Color.Teal;
			this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
			this.btnUpdate.Location = new System.Drawing.Point(178, 381);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(118, 44);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// cbLeaves
			// 
			this.cbLeaves.BackColor = System.Drawing.SystemColors.HotTrack;
			this.cbLeaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLeaves.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.cbLeaves.FormattingEnabled = true;
			this.cbLeaves.Location = new System.Drawing.Point(48, 109);
			this.cbLeaves.Name = "cbLeaves";
			this.cbLeaves.Size = new System.Drawing.Size(206, 21);
			this.cbLeaves.TabIndex = 3;
			this.cbLeaves.SelectedIndexChanged += new System.EventHandler(this.cbLeaves_SelectedIndexChanged);
			// 
			// tbReason
			// 
			this.tbReason.Location = new System.Drawing.Point(46, 242);
			this.tbReason.Multiline = true;
			this.tbReason.Name = "tbReason";
			this.tbReason.Size = new System.Drawing.Size(349, 93);
			this.tbReason.TabIndex = 4;
			// 
			// dtStart
			// 
			this.dtStart.CustomFormat = "dd/MM/yyyy";
			this.dtStart.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStart.Location = new System.Drawing.Point(48, 172);
			this.dtStart.MinDate = new System.DateTime(2024, 3, 2, 0, 0, 0, 0);
			this.dtStart.Name = "dtStart";
			this.dtStart.Size = new System.Drawing.Size(100, 23);
			this.dtStart.TabIndex = 5;
			// 
			// dtEnd
			// 
			this.dtEnd.CustomFormat = "dd/MM/yyyy";
			this.dtEnd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEnd.Location = new System.Drawing.Point(154, 172);
			this.dtEnd.MinDate = new System.DateTime(2024, 3, 2, 0, 0, 0, 0);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.Size = new System.Drawing.Size(100, 23);
			this.dtEnd.TabIndex = 8;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.BackColor = System.Drawing.Color.Teal;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
			this.btnAdd.Location = new System.Drawing.Point(605, 307);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(84, 37);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.UseWaitCursor = true;
			this.btnAdd.Visible = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.BackColor = System.Drawing.Color.Crimson;
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemove.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
			this.btnRemove.Location = new System.Drawing.Point(695, 307);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(84, 37);
			this.btnRemove.TabIndex = 10;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Visible = false;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// lbFileName
			// 
			this.lbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbFileName.AutoSize = true;
			this.lbFileName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFileName.Location = new System.Drawing.Point(583, 83);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(92, 19);
			this.lbFileName.TabIndex = 11;
			this.lbFileName.Text = "File Name:";
			this.lbFileName.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(44, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(181, 19);
			this.label1.TabIndex = 12;
			this.label1.Text = "Choose Type of Leave:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(44, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 19);
			this.label2.TabIndex = 13;
			this.label2.Text = "Start:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(150, 149);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 19);
			this.label3.TabIndex = 14;
			this.label3.Text = "End:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(42, 219);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 19);
			this.label4.TabIndex = 15;
			this.label4.Text = "Reason:";
			// 
			// pbMedCert
			// 
			this.pbMedCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbMedCert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbMedCert.Location = new System.Drawing.Point(587, 109);
			this.pbMedCert.Name = "pbMedCert";
			this.pbMedCert.Size = new System.Drawing.Size(203, 187);
			this.pbMedCert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbMedCert.TabIndex = 7;
			this.pbMedCert.TabStop = false;
			this.pbMedCert.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Crimson;
			this.label6.Location = new System.Drawing.Point(42, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(323, 32);
			this.label6.TabIndex = 18;
			this.label6.Text = "Leave Form Application\r\n";
			// 
			// leaveApplication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(858, 658);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbFileName);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dtEnd);
			this.Controls.Add(this.pbMedCert);
			this.Controls.Add(this.dtStart);
			this.Controls.Add(this.tbReason);
			this.Controls.Add(this.cbLeaves);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "leaveApplication";
			this.Text = "leaveApplication";
			this.Load += new System.EventHandler(this.leaveApplication_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMedCert)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbLeaves;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.PictureBox pbMedCert;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLeaveCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAppliedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgImageData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFileName;
    }
}