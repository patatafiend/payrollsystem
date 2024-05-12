namespace payrollsystemsti.AdminTabs
{
    partial class attendanceMonitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(attendanceMonitoring));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.btnTimeIN = new System.Windows.Forms.Button();
            this.btnOvertime = new System.Windows.Forms.Button();
            this.btnTimeOUT = new System.Windows.Forms.Button();
            this.attendanceHeader = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnMax = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.attendanceHeader.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmpID,
            this.dgTime,
            this.dgDate,
            this.dgStatus});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(49, 176);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(911, 420);
            this.dataGridView1.TabIndex = 3;
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "Employee ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
            // 
            // dgTime
            // 
            this.dgTime.HeaderText = "Time";
            this.dgTime.Name = "dgTime";
            this.dgTime.ReadOnly = true;
            // 
            // dgDate
            // 
            this.dgDate.HeaderText = "Date";
            this.dgDate.Name = "dgDate";
            this.dgDate.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // date
            // 
            this.date.CustomFormat = "dddd, MM/dd/yyyy";
            this.date.Enabled = false;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(49, 58);
            this.date.Name = "date";
            this.date.ShowUpDown = true;
            this.date.Size = new System.Drawing.Size(248, 30);
            this.date.TabIndex = 4;
            this.date.Value = new System.DateTime(2024, 5, 12, 0, 0, 0, 0);
            // 
            // btnTimeIN
            // 
            this.btnTimeIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeIN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTimeIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeIN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeIN.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTimeIN.Location = new System.Drawing.Point(49, 125);
            this.btnTimeIN.Name = "btnTimeIN";
            this.btnTimeIN.Size = new System.Drawing.Size(118, 44);
            this.btnTimeIN.TabIndex = 26;
            this.btnTimeIN.Text = "Time IN";
            this.btnTimeIN.UseVisualStyleBackColor = false;
            this.btnTimeIN.Click += new System.EventHandler(this.btnTimeIN_Click);
            // 
            // btnOvertime
            // 
            this.btnOvertime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOvertime.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnOvertime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOvertime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOvertime.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOvertime.Location = new System.Drawing.Point(366, 125);
            this.btnOvertime.Name = "btnOvertime";
            this.btnOvertime.Size = new System.Drawing.Size(118, 44);
            this.btnOvertime.TabIndex = 33;
            this.btnOvertime.Text = "Overtime";
            this.btnOvertime.UseVisualStyleBackColor = false;
            // 
            // btnTimeOUT
            // 
            this.btnTimeOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeOUT.BackColor = System.Drawing.Color.Red;
            this.btnTimeOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeOUT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeOUT.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTimeOUT.Location = new System.Drawing.Point(206, 125);
            this.btnTimeOUT.Name = "btnTimeOUT";
            this.btnTimeOUT.Size = new System.Drawing.Size(118, 44);
            this.btnTimeOUT.TabIndex = 34;
            this.btnTimeOUT.Text = "Time OUT";
            this.btnTimeOUT.UseVisualStyleBackColor = false;
            this.btnTimeOUT.Click += new System.EventHandler(this.btnTimeOUT_Click);
            // 
            // attendanceHeader
            // 
            this.attendanceHeader.BackColor = System.Drawing.Color.Transparent;
            this.attendanceHeader.Controls.Add(this.controlBox);
            this.attendanceHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.attendanceHeader.Location = new System.Drawing.Point(0, 0);
            this.attendanceHeader.Name = "attendanceHeader";
            this.attendanceHeader.Size = new System.Drawing.Size(1008, 39);
            this.attendanceHeader.TabIndex = 35;
            this.attendanceHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.attendanceHeader_MouseDown);
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.panel17);
            this.controlBox.Controls.Add(this.panel12);
            this.controlBox.Controls.Add(this.panel16);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(868, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(140, 39);
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
            // time
            // 
            this.time.CustomFormat = "hh:mm tt";
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(820, 58);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(140, 30);
            this.time.TabIndex = 36;
            this.time.Value = new System.DateTime(2024, 5, 12, 17, 51, 0, 0);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // attendanceMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1008, 609);
            this.Controls.Add(this.time);
            this.Controls.Add(this.attendanceHeader);
            this.Controls.Add(this.btnTimeOUT);
            this.Controls.Add(this.btnOvertime);
            this.Controls.Add(this.btnTimeIN);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "attendanceMonitoring";
            this.Text = "attendanceMonitoring";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.attendanceMonitoring_FormClosed);
            this.Load += new System.EventHandler(this.attendanceMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.attendanceHeader.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button btnTimeIN;
        private System.Windows.Forms.Button btnOvertime;
        private System.Windows.Forms.Button btnTimeOUT;
        private System.Windows.Forms.Panel attendanceHeader;
        private System.Windows.Forms.Panel controlBox;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.Timer timer;
    }
}