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
            this.btnEnrollFinger = new System.Windows.Forms.Button();
            this.tbFingerID = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFingerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnrollFinger
            // 
            this.btnEnrollFinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnrollFinger.BackColor = System.Drawing.Color.SkyBlue;
            this.btnEnrollFinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnrollFinger.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollFinger.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnrollFinger.Location = new System.Drawing.Point(636, 95);
            this.btnEnrollFinger.Name = "btnEnrollFinger";
            this.btnEnrollFinger.Size = new System.Drawing.Size(118, 60);
            this.btnEnrollFinger.TabIndex = 34;
            this.btnEnrollFinger.Text = "Enroll Finger\r\nFingerprint";
            this.btnEnrollFinger.UseVisualStyleBackColor = false;
            this.btnEnrollFinger.Click += new System.EventHandler(this.btnEnrollFinger_Click);
            // 
            // tbFingerID
            // 
            this.tbFingerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFingerID.Location = new System.Drawing.Point(40, 44);
            this.tbFingerID.Multiline = true;
            this.tbFingerID.Name = "tbFingerID";
            this.tbFingerID.Size = new System.Drawing.Size(168, 22);
            this.tbFingerID.TabIndex = 35;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Location = new System.Drawing.Point(636, 170);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(118, 60);
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
            this.dataGridView1.Location = new System.Drawing.Point(40, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(590, 325);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // dgEmpID
            // 
            this.dgEmpID.HeaderText = "Emp ID";
            this.dgEmpID.Name = "dgEmpID";
            this.dgEmpID.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "FINGER ID";
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
            this.cbFilterID.Location = new System.Drawing.Point(509, 65);
            this.cbFilterID.Name = "cbFilterID";
            this.cbFilterID.Size = new System.Drawing.Size(121, 24);
            this.cbFilterID.TabIndex = 39;
            this.cbFilterID.SelectedIndexChanged += new System.EventHandler(this.cbFilterID_SelectedIndexChanged);
            // 
            // enrollFingerprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbFilterID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbFingerID);
            this.Controls.Add(this.btnEnrollFinger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "enrollFingerprint";
            this.Text = "Enroll Fingerprint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.enrollFingerprint_FormClosed);
            this.Load += new System.EventHandler(this.enrollFingerprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnrollFinger;
        private System.Windows.Forms.TextBox tbFingerID;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFingerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIsDeleted;
        private System.Windows.Forms.ComboBox cbFilterID;
    }
}