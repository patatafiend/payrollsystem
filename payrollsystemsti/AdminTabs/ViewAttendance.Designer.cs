namespace payrollsystemsti.AdminTabs
{
    partial class ViewAttendance
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
            this.historyTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stipayrolldbDataSet3 = new payrollsystemsti.stipayrolldbDataSet3();
            this.stipayrolldbDataSet = new payrollsystemsti.stipayrolldbDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.historyTableTableAdapter = new payrollsystemsti.stipayrolldbDataSetTableAdapters.HistoryTableTableAdapter();
            this.stipayrolldbDataSet2 = new payrollsystemsti.stipayrolldbDataSet2();
            this.historyTableTableAdapter1 = new payrollsystemsti.stipayrolldbDataSet2TableAdapters.HistoryTableTableAdapter();
            this.historyTableTableAdapter2 = new payrollsystemsti.stipayrolldbDataSet3TableAdapters.HistoryTableTableAdapter();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.absentsDataGridViewTextBoxColumn,
            this.timeInDataGridViewTextBoxColumn,
            this.timeOutDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.historyTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(43, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(770, 336);
            this.dataGridView1.TabIndex = 28;
            // 
            // historyTableBindingSource
            // 
            this.historyTableBindingSource.DataMember = "HistoryTable";
            this.historyTableBindingSource.DataSource = this.stipayrolldbDataSet3;
            // 
            // stipayrolldbDataSet3
            // 
            this.stipayrolldbDataSet3.DataSetName = "stipayrolldbDataSet3";
            this.stipayrolldbDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stipayrolldbDataSet
            // 
            this.stipayrolldbDataSet.DataSetName = "stipayrolldbDataSet";
            this.stipayrolldbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(37, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 31);
            this.label1.TabIndex = 29;
            this.label1.Text = "Attedance History";
            // 
            // historyTableTableAdapter
            // 
            this.historyTableTableAdapter.ClearBeforeFill = true;
            // 
            // stipayrolldbDataSet2
            // 
            this.stipayrolldbDataSet2.DataSetName = "stipayrolldbDataSet2";
            this.stipayrolldbDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // historyTableTableAdapter1
            // 
            this.historyTableTableAdapter1.ClearBeforeFill = true;
            // 
            // historyTableTableAdapter2
            // 
            this.historyTableTableAdapter2.ClearBeforeFill = true;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.CustomFormat = "MMMM";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(43, 123);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(142, 26);
            this.dtDate.TabIndex = 102;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Visible = false;
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
            // absentsDataGridViewTextBoxColumn
            // 
            this.absentsDataGridViewTextBoxColumn.DataPropertyName = "Absents";
            this.absentsDataGridViewTextBoxColumn.HeaderText = "Absents";
            this.absentsDataGridViewTextBoxColumn.Name = "absentsDataGridViewTextBoxColumn";
            this.absentsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeInDataGridViewTextBoxColumn
            // 
            this.timeInDataGridViewTextBoxColumn.DataPropertyName = "TimeIn";
            this.timeInDataGridViewTextBoxColumn.HeaderText = "TimeIn";
            this.timeInDataGridViewTextBoxColumn.Name = "timeInDataGridViewTextBoxColumn";
            this.timeInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeOutDataGridViewTextBoxColumn
            // 
            this.timeOutDataGridViewTextBoxColumn.DataPropertyName = "TimeOut";
            this.timeOutDataGridViewTextBoxColumn.HeaderText = "TimeOut";
            this.timeOutDataGridViewTextBoxColumn.Name = "timeOutDataGridViewTextBoxColumn";
            this.timeOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ViewAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(866, 541);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewAttendance";
            this.Text = "ViewAttendance";
            this.Load += new System.EventHandler(this.ViewAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stipayrolldbDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private stipayrolldbDataSet stipayrolldbDataSet;
        private stipayrolldbDataSetTableAdapters.HistoryTableTableAdapter historyTableTableAdapter;
		private stipayrolldbDataSet2 stipayrolldbDataSet2;
		private stipayrolldbDataSet2TableAdapters.HistoryTableTableAdapter historyTableTableAdapter1;
		private stipayrolldbDataSet3 stipayrolldbDataSet3;
		private System.Windows.Forms.BindingSource historyTableBindingSource;
		private stipayrolldbDataSet3TableAdapters.HistoryTableTableAdapter historyTableTableAdapter2;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn absentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOutDataGridViewTextBoxColumn;
    }
}