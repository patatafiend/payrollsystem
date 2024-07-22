namespace payrollsystemsti.AdminTabs
{
	partial class HistoryLogForm
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
			this.dgv_HistoryLog = new System.Windows.Forms.DataGridView();
			this.btnExit = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_HistoryLog = new System.Windows.Forms.Label();
			this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryLog)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv_HistoryLog
			// 
			this.dgv_HistoryLog.AllowUserToAddRows = false;
			this.dgv_HistoryLog.AllowUserToDeleteRows = false;
			this.dgv_HistoryLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_HistoryLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dgv_HistoryLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_HistoryLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.Department,
            this.LoginTime});
			this.dgv_HistoryLog.Location = new System.Drawing.Point(33, 178);
			this.dgv_HistoryLog.Margin = new System.Windows.Forms.Padding(4);
			this.dgv_HistoryLog.Name = "dgv_HistoryLog";
			this.dgv_HistoryLog.ReadOnly = true;
			this.dgv_HistoryLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_HistoryLog.Size = new System.Drawing.Size(975, 417);
			this.dgv_HistoryLog.TabIndex = 8;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Crimson;
			this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
			this.btnExit.Location = new System.Drawing.Point(890, 127);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(118, 44);
			this.btnExit.TabIndex = 29;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
			this.panel2.Controls.Add(this.lb_HistoryLog);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1052, 45);
			this.panel2.TabIndex = 30;
			// 
			// lb_HistoryLog
			// 
			this.lb_HistoryLog.AutoSize = true;
			this.lb_HistoryLog.BackColor = System.Drawing.Color.Transparent;
			this.lb_HistoryLog.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb_HistoryLog.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lb_HistoryLog.Location = new System.Drawing.Point(3, 11);
			this.lb_HistoryLog.Name = "lb_HistoryLog";
			this.lb_HistoryLog.Size = new System.Drawing.Size(104, 23);
			this.lb_HistoryLog.TabIndex = 0;
			this.lb_HistoryLog.Text = "HistoryLog";
			// 
			// FirstName
			// 
			this.FirstName.DataPropertyName = "FirstName";
			this.FirstName.HeaderText = "First Name";
			this.FirstName.Name = "FirstName";
			this.FirstName.ReadOnly = true;
			// 
			// Department
			// 
			this.Department.DataPropertyName = "Department";
			this.Department.HeaderText = "Department";
			this.Department.Name = "Department";
			this.Department.ReadOnly = true;
			// 
			// LoginTime
			// 
			this.LoginTime.DataPropertyName = "LoginTime";
			this.LoginTime.HeaderText = "Time";
			this.LoginTime.Name = "LoginTime";
			this.LoginTime.ReadOnly = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(33, 142);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 31;
			// 
			// HistoryLogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1052, 636);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.dgv_HistoryLog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HistoryLogForm";
			this.Text = "HistoyLogForm";
			this.Load += new System.EventHandler(this.HistoryLogForm_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryLog)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_HistoryLog;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lb_HistoryLog;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Department;
		private System.Windows.Forms.DataGridViewTextBoxColumn LoginTime;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}