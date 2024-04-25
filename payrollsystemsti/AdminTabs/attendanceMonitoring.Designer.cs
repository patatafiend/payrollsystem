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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTimeIN = new System.Windows.Forms.Button();
            this.btnOvertime = new System.Windows.Forms.Button();
            this.btnTimeOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dgStatus});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(52, 151);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(699, 470);
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
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dddd, MM/dd/yyyy hh:mm tt";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(52, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(338, 30);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // btnTimeIN
            // 
            this.btnTimeIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeIN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTimeIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeIN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeIN.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTimeIN.Location = new System.Drawing.Point(58, 91);
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
            this.btnOvertime.Location = new System.Drawing.Point(633, 91);
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
            this.btnTimeOUT.Location = new System.Drawing.Point(239, 91);
            this.btnTimeOUT.Name = "btnTimeOUT";
            this.btnTimeOUT.Size = new System.Drawing.Size(118, 44);
            this.btnTimeOUT.TabIndex = 34;
            this.btnTimeOUT.Text = "Time OUT";
            this.btnTimeOUT.UseVisualStyleBackColor = false;
            // 
            // attendanceMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 644);
            this.Controls.Add(this.btnTimeOUT);
            this.Controls.Add(this.btnOvertime);
            this.Controls.Add(this.btnTimeIN);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "attendanceMonitoring";
            this.Text = "attendanceMonitoring";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.attendanceMonitoring_FormClosed);
            this.Load += new System.EventHandler(this.attendanceMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTimeIN;
        private System.Windows.Forms.Button btnOvertime;
        private System.Windows.Forms.Button btnTimeOUT;
    }
}