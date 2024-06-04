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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgNDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAbsents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgNDW,
            this.dgAbsents,
            this.dgLates,
            this.dgED});
            this.dataGridView1.Location = new System.Drawing.Point(43, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(770, 336);
            this.dataGridView1.TabIndex = 28;
            // 
            // dgNDW
            // 
            this.dgNDW.HeaderText = "No. of Days Worked";
            this.dgNDW.Name = "dgNDW";
            this.dgNDW.ReadOnly = true;
            // 
            // dgAbsents
            // 
            this.dgAbsents.HeaderText = "Absents";
            this.dgAbsents.Name = "dgAbsents";
            this.dgAbsents.ReadOnly = true;
            // 
            // dgLates
            // 
            this.dgLates.HeaderText = "Lates(minutes)";
            this.dgLates.Name = "dgLates";
            this.dgLates.ReadOnly = true;
            // 
            // dgED
            // 
            this.dgED.HeaderText = "Estimated Deduction";
            this.dgED.Name = "dgED";
            this.dgED.ReadOnly = true;
            // 
            // ViewAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(866, 541);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewAttendance";
            this.Text = "ViewAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNDW;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAbsents;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLates;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgED;
    }
}