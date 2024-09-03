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
			this.components = new System.ComponentModel.Container();
			this.dgv_HistoryLog = new System.Windows.Forms.DataGridView();
			this.historyFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.historyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timeAddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.historyTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.stipayrolldbDataSet4 = new payrollsystemsti.stipayrolldbDataSet4();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lb_HistoryLog = new System.Windows.Forms.Label();
			this.historyTableTableAdapter = new payrollsystemsti.stipayrolldbDataSet4TableAdapters.HistoryTableTableAdapter();
			this.stipayrolldbDataSet6 = new payrollsystemsti.stipayrolldbDataSet6();
			this.historyTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.historyTableTableAdapter1 = new payrollsystemsti.stipayrolldbDataSet6TableAdapters.HistoryTableTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryLog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet4)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_HistoryLog
			// 
			this.dgv_HistoryLog.AllowUserToAddRows = false;
			this.dgv_HistoryLog.AllowUserToDeleteRows = false;
			this.dgv_HistoryLog.AutoGenerateColumns = false;
			this.dgv_HistoryLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_HistoryLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dgv_HistoryLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_HistoryLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.historyFromDataGridViewTextBoxColumn,
            this.Department,
            this.FirstName,
            this.employeeIDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.historyIDDataGridViewTextBoxColumn,
            this.timeAddedDataGridViewTextBoxColumn});
			this.dgv_HistoryLog.DataSource = this.historyTableBindingSource1;
			this.dgv_HistoryLog.Location = new System.Drawing.Point(33, 178);
			this.dgv_HistoryLog.Margin = new System.Windows.Forms.Padding(4);
			this.dgv_HistoryLog.Name = "dgv_HistoryLog";
			this.dgv_HistoryLog.ReadOnly = true;
			this.dgv_HistoryLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_HistoryLog.Size = new System.Drawing.Size(975, 417);
			this.dgv_HistoryLog.TabIndex = 8;
			// 
			// historyFromDataGridViewTextBoxColumn
			// 
			this.historyFromDataGridViewTextBoxColumn.DataPropertyName = "HistoryFrom";
			this.historyFromDataGridViewTextBoxColumn.HeaderText = "HistoryFrom";
			this.historyFromDataGridViewTextBoxColumn.Name = "historyFromDataGridViewTextBoxColumn";
			this.historyFromDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// Department
			// 
			this.Department.DataPropertyName = "Department";
			this.Department.HeaderText = "Department";
			this.Department.Name = "Department";
			this.Department.ReadOnly = true;
			// 
			// FirstName
			// 
			this.FirstName.DataPropertyName = "FirstName";
			this.FirstName.HeaderText = "First Name";
			this.FirstName.Name = "FirstName";
			this.FirstName.ReadOnly = true;
			// 
			// employeeIDDataGridViewTextBoxColumn
			// 
			this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
			this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
			this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
			this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// firstNameDataGridViewTextBoxColumn
			// 
			this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
			this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
			this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// lastNameDataGridViewTextBoxColumn
			// 
			this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
			this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
			this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
			this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// historyIDDataGridViewTextBoxColumn
			// 
			this.historyIDDataGridViewTextBoxColumn.DataPropertyName = "HistoryID";
			this.historyIDDataGridViewTextBoxColumn.HeaderText = "HistoryID";
			this.historyIDDataGridViewTextBoxColumn.Name = "historyIDDataGridViewTextBoxColumn";
			this.historyIDDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// timeAddedDataGridViewTextBoxColumn
			// 
			this.timeAddedDataGridViewTextBoxColumn.DataPropertyName = "TimeAdded";
			this.timeAddedDataGridViewTextBoxColumn.HeaderText = "TimeAdded";
			this.timeAddedDataGridViewTextBoxColumn.Name = "timeAddedDataGridViewTextBoxColumn";
			this.timeAddedDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// historyTableBindingSource
			// 
			this.historyTableBindingSource.DataMember = "HistoryTable";
			this.historyTableBindingSource.DataSource = this.stipayrolldbDataSet4;
			// 
			// stipayrolldbDataSet4
			// 
			this.stipayrolldbDataSet4.DataSetName = "stipayrolldbDataSet4";
			this.stipayrolldbDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
			// historyTableTableAdapter
			// 
			this.historyTableTableAdapter.ClearBeforeFill = true;
			// 
			// stipayrolldbDataSet6
			// 
			this.stipayrolldbDataSet6.DataSetName = "stipayrolldbDataSet6";
			this.stipayrolldbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// historyTableBindingSource1
			// 
			this.historyTableBindingSource1.DataMember = "HistoryTable";
			this.historyTableBindingSource1.DataSource = this.stipayrolldbDataSet6;
			// 
			// historyTableTableAdapter1
			// 
			this.historyTableTableAdapter1.ClearBeforeFill = true;
			// 
			// HistoryLogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LavenderBlush;
			this.ClientSize = new System.Drawing.Size(1052, 636);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.dgv_HistoryLog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HistoryLogForm";
			this.Text = "HistoyLogForm";
			this.Load += new System.EventHandler(this.HistoryLogForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryLog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet4)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_HistoryLog;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lb_HistoryLog;
		private stipayrolldbDataSet4 stipayrolldbDataSet4;
		private System.Windows.Forms.BindingSource historyTableBindingSource;
		private stipayrolldbDataSet4TableAdapters.HistoryTableTableAdapter historyTableTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn historyFromDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Department;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn historyIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn timeAddedDataGridViewTextBoxColumn;
		private stipayrolldbDataSet6 stipayrolldbDataSet6;
		private System.Windows.Forms.BindingSource historyTableBindingSource1;
		private stipayrolldbDataSet6TableAdapters.HistoryTableTableAdapter historyTableTableAdapter1;
	}
}