namespace payrollsystemsti
{
    partial class enrollFingerprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(enrollFingerprint));
            this.btnEnrollFinger = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFingerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cbFilterID = new System.Windows.Forms.ComboBox();
            this.loadingIndicator = new System.Windows.Forms.PictureBox();
            this.loginHeader = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnMax = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).BeginInit();
            this.loginHeader.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnrollFinger
            // 
            this.btnEnrollFinger.BackColor = System.Drawing.Color.SkyBlue;
            this.btnEnrollFinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnrollFinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollFinger.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnrollFinger.Location = new System.Drawing.Point(55, 87);
            this.btnEnrollFinger.Name = "btnEnrollFinger";
            this.btnEnrollFinger.Size = new System.Drawing.Size(110, 50);
            this.btnEnrollFinger.TabIndex = 34;
            this.btnEnrollFinger.Text = "Enroll Finger\r\nFingerprint";
            this.btnEnrollFinger.UseVisualStyleBackColor = false;
            this.btnEnrollFinger.Click += new System.EventHandler(this.btnEnrollFinger_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Location = new System.Drawing.Point(171, 87);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(110, 50);
            this.btnRemove.TabIndex = 36;
            this.btnRemove.Text = "Remove Finger ID";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgLastName,
            this.dgFirstName,
            this.dgFingerID,
            this.dgIsDeleted});
            this.dataGridView1.Location = new System.Drawing.Point(55, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(727, 389);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "Emp ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            this.dgEmpID.Visible = false;
            // 
            // dgLastName
            // 
            this.dgLastName.HeaderText = "LastName";
            this.dgLastName.Name = "dgLastName";
            this.dgLastName.ReadOnly = true;
            // 
            // dgFirstName
            // 
            this.dgFirstName.HeaderText = "FirstName";
            this.dgFirstName.Name = "dgFirstName";
            this.dgFirstName.ReadOnly = true;
            // 
            // dgFingerID
            // 
            this.dgFingerID.HeaderText = "FingerID";
            this.dgFingerID.Name = "dgFingerID";
            this.dgFingerID.ReadOnly = true;
            // 
            // dgIsDeleted
            // 
            this.dgIsDeleted.HeaderText = "IsDeleted";
            this.dgIsDeleted.Name = "dgIsDeleted";
            this.dgIsDeleted.ReadOnly = true;
            this.dgIsDeleted.Visible = false;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // cbFilterID
            // 
            this.cbFilterID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilterID.FormattingEnabled = true;
            this.cbFilterID.Items.AddRange(new object[] {
            "FingerID",
            "No FingerID"});
            this.cbFilterID.Location = new System.Drawing.Point(661, 113);
            this.cbFilterID.Name = "cbFilterID";
            this.cbFilterID.Size = new System.Drawing.Size(121, 24);
            this.cbFilterID.TabIndex = 39;
            this.cbFilterID.SelectedIndexChanged += new System.EventHandler(this.cbFilterID_SelectedIndexChanged);
            // 
            // loadingIndicator
            // 
            this.loadingIndicator.Image = ((System.Drawing.Image)(resources.GetObject("loadingIndicator.Image")));
            this.loadingIndicator.Location = new System.Drawing.Point(298, 87);
            this.loadingIndicator.Name = "loadingIndicator";
            this.loadingIndicator.Size = new System.Drawing.Size(48, 48);
            this.loadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loadingIndicator.TabIndex = 40;
            this.loadingIndicator.TabStop = false;
            // 
            // loginHeader
            // 
            this.loginHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginHeader.BackColor = System.Drawing.Color.LavenderBlush;
            this.loginHeader.Controls.Add(this.controlBox);
            this.loginHeader.Location = new System.Drawing.Point(0, -2);
            this.loginHeader.Name = "loginHeader";
            this.loginHeader.Size = new System.Drawing.Size(839, 33);
            this.loginHeader.TabIndex = 41;
            this.loginHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginHeader_MouseDown);
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.panel17);
            this.controlBox.Controls.Add(this.panel12);
            this.controlBox.Controls.Add(this.panel16);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(699, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(140, 33);
            this.controlBox.TabIndex = 6;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btnClose);
            this.panel17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel17.Location = new System.Drawing.Point(93, 3);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(44, 30);
            this.panel17.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 27);
            this.btnClose.TabIndex = 30;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnMin);
            this.panel12.Location = new System.Drawing.Point(3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(44, 30);
            this.panel12.TabIndex = 0;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.SkyBlue;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Transparent;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(3, 3);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(36, 27);
            this.btnMin.TabIndex = 30;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnMax);
            this.panel16.Location = new System.Drawing.Point(48, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(44, 30);
            this.panel16.TabIndex = 30;
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.SkyBlue;
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.ForeColor = System.Drawing.Color.Transparent;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(3, 3);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(36, 27);
            this.btnMax.TabIndex = 30;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // enrollFingerprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(838, 544);
            this.Controls.Add(this.loginHeader);
            this.Controls.Add(this.loadingIndicator);
            this.Controls.Add(this.cbFilterID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEnrollFinger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "enrollFingerprint";
            this.Text = "Enroll Fingerprint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.enrollFingerprint_FormClosed);
            this.Load += new System.EventHandler(this.enrollFingerprint_Load);
            this.VisibleChanged += new System.EventHandler(this.enrollFingerprint_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).EndInit();
            this.loginHeader.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnrollFinger;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cbFilterID;
        private System.Windows.Forms.PictureBox loadingIndicator;
        private System.Windows.Forms.Panel loginHeader;
        private System.Windows.Forms.Panel controlBox;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFingerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeleted;
    }
}