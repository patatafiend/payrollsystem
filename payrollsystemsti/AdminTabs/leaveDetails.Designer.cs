namespace payrollsystemsti.AdminTabs
{
    partial class leaveDetails
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbEmpID = new System.Windows.Forms.Label();
            this.lbLeaveType = new System.Windows.Forms.Label();
            this.lbReason = new System.Windows.Forms.Label();
            this.lbDateRange = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(335, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 112);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 107);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbFullName.Location = new System.Drawing.Point(42, 57);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(75, 20);
            this.lbFullName.TabIndex = 2;
            this.lbFullName.Text = "FullName";
            // 
            // lbDepartment
            // 
            this.lbDepartment.AutoSize = true;
            this.lbDepartment.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbDepartment.Location = new System.Drawing.Point(42, 89);
            this.lbDepartment.Name = "lbDepartment";
            this.lbDepartment.Size = new System.Drawing.Size(97, 20);
            this.lbDepartment.TabIndex = 3;
            this.lbDepartment.Text = "Department";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbPosition.Location = new System.Drawing.Point(42, 119);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(64, 20);
            this.lbPosition.TabIndex = 4;
            this.lbPosition.Text = "Position";
            // 
            // lbEmpID
            // 
            this.lbEmpID.AutoSize = true;
            this.lbEmpID.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbEmpID.Location = new System.Drawing.Point(42, 30);
            this.lbEmpID.Name = "lbEmpID";
            this.lbEmpID.Size = new System.Drawing.Size(101, 20);
            this.lbEmpID.TabIndex = 5;
            this.lbEmpID.Text = "Employee ID";
            // 
            // lbLeaveType
            // 
            this.lbLeaveType.AutoSize = true;
            this.lbLeaveType.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbLeaveType.Location = new System.Drawing.Point(42, 203);
            this.lbLeaveType.Name = "lbLeaveType";
            this.lbLeaveType.Size = new System.Drawing.Size(93, 20);
            this.lbLeaveType.TabIndex = 6;
            this.lbLeaveType.Text = "Leave Type";
            // 
            // lbReason
            // 
            this.lbReason.AutoSize = true;
            this.lbReason.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lbReason.Location = new System.Drawing.Point(42, 243);
            this.lbReason.Name = "lbReason";
            this.lbReason.Size = new System.Drawing.Size(60, 19);
            this.lbReason.TabIndex = 7;
            this.lbReason.Text = "Reason";
            // 
            // lbDateRange
            // 
            this.lbDateRange.AutoSize = true;
            this.lbDateRange.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lbDateRange.Location = new System.Drawing.Point(42, 159);
            this.lbDateRange.Name = "lbDateRange";
            this.lbDateRange.Size = new System.Drawing.Size(45, 20);
            this.lbDateRange.TabIndex = 8;
            this.lbDateRange.Text = "Date";
            // 
            // leaveDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 499);
            this.Controls.Add(this.lbDateRange);
            this.Controls.Add(this.lbReason);
            this.Controls.Add(this.lbLeaveType);
            this.Controls.Add(this.lbEmpID);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.lbDepartment);
            this.Controls.Add(this.lbFullName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "leaveDetails";
            this.Text = "leaveDetails";
            this.Load += new System.EventHandler(this.leaveDetails_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbEmpID;
        private System.Windows.Forms.Label lbLeaveType;
        private System.Windows.Forms.Label lbReason;
        private System.Windows.Forms.Label lbDateRange;
    }
}