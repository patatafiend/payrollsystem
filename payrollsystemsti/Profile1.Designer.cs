namespace payrollsystemsti
{
    partial class Profile1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_curDepartment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_EmpPosition = new System.Windows.Forms.Label();
            this.lb_EmpEmail = new System.Windows.Forms.Label();
            this.lb_EmpPhoNum = new System.Windows.Forms.Label();
            this.lb_EmpName = new System.Windows.Forms.Label();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCurrentUser = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_curDepartment
            // 
            this.lb_curDepartment.AutoSize = true;
            this.lb_curDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lb_curDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_curDepartment.Location = new System.Drawing.Point(480, 159);
            this.lb_curDepartment.Name = "lb_curDepartment";
            this.lb_curDepartment.Size = new System.Drawing.Size(113, 19);
            this.lb_curDepartment.TabIndex = 34;
            this.lb_curDepartment.Text = "Department:";
            this.lb_curDepartment.Click += new System.EventHandler(this.lb_curDepartment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "Birthday:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Gender:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "Age:";
            // 
            // lb_EmpPosition
            // 
            this.lb_EmpPosition.AutoSize = true;
            this.lb_EmpPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EmpPosition.Location = new System.Drawing.Point(480, 127);
            this.lb_EmpPosition.Name = "lb_EmpPosition";
            this.lb_EmpPosition.Size = new System.Drawing.Size(86, 19);
            this.lb_EmpPosition.TabIndex = 30;
            this.lb_EmpPosition.Text = "Position :";
            // 
            // lb_EmpEmail
            // 
            this.lb_EmpEmail.AutoSize = true;
            this.lb_EmpEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EmpEmail.Location = new System.Drawing.Point(57, 325);
            this.lb_EmpEmail.Name = "lb_EmpEmail";
            this.lb_EmpEmail.Size = new System.Drawing.Size(133, 19);
            this.lb_EmpEmail.TabIndex = 29;
            this.lb_EmpEmail.Text = "Email address :";
            // 
            // lb_EmpPhoNum
            // 
            this.lb_EmpPhoNum.AutoSize = true;
            this.lb_EmpPhoNum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EmpPhoNum.Location = new System.Drawing.Point(58, 296);
            this.lb_EmpPhoNum.Name = "lb_EmpPhoNum";
            this.lb_EmpPhoNum.Size = new System.Drawing.Size(103, 19);
            this.lb_EmpPhoNum.TabIndex = 28;
            this.lb_EmpPhoNum.Text = "Phone No. :";
            this.lb_EmpPhoNum.Click += new System.EventHandler(this.lb_EmpPhoNum_Click);
            // 
            // lb_EmpName
            // 
            this.lb_EmpName.AutoSize = true;
            this.lb_EmpName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_EmpName.Location = new System.Drawing.Point(58, 267);
            this.lb_EmpName.Name = "lb_EmpName";
            this.lb_EmpName.Size = new System.Drawing.Size(67, 19);
            this.lb_EmpName.TabIndex = 27;
            this.lb_EmpName.Text = "Name :";
            // 
            // lbEmployeeID
            // 
            this.lbEmployeeID.AutoSize = true;
            this.lbEmployeeID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEmployeeID.Location = new System.Drawing.Point(480, 94);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(113, 19);
            this.lbEmployeeID.TabIndex = 26;
            this.lbEmployeeID.Text = "EmployeeID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(41, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "My Profile";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pbCurrentUser
            // 
            this.pbCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCurrentUser.Image = global::payrollsystemsti.Properties.Resources.renz;
            this.pbCurrentUser.Location = new System.Drawing.Point(61, 94);
            this.pbCurrentUser.Name = "pbCurrentUser";
            this.pbCurrentUser.Size = new System.Drawing.Size(152, 147);
            this.pbCurrentUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentUser.TabIndex = 25;
            this.pbCurrentUser.TabStop = false;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(595, 486);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(90, 29);
            this.back.TabIndex = 35;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Profile1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.back);
            this.Controls.Add(this.lb_curDepartment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_EmpPosition);
            this.Controls.Add(this.lb_EmpEmail);
            this.Controls.Add(this.lb_EmpPhoNum);
            this.Controls.Add(this.lb_EmpName);
            this.Controls.Add(this.lbEmployeeID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbCurrentUser);
            this.Name = "Profile1";
            this.Size = new System.Drawing.Size(853, 604);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_curDepartment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_EmpPosition;
        private System.Windows.Forms.Label lb_EmpEmail;
        private System.Windows.Forms.Label lb_EmpPhoNum;
        private System.Windows.Forms.Label lb_EmpName;
        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbCurrentUser;
        private System.Windows.Forms.Button back;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
