namespace payrollsystemsti.AdminTabs
{
    partial class accountsArchive
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
            this.dgEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActivate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEmployeeID,
            this.dgFullName});
            this.dataGridView1.Location = new System.Drawing.Point(97, 150);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(629, 268);
            this.dataGridView1.TabIndex = 4;
            // 
            // dgEmployeeID
            // 
            this.dgEmployeeID.HeaderText = "Employee ID";
            this.dgEmployeeID.Name = "dgEmployeeID";
            this.dgEmployeeID.ReadOnly = true;
            // 
            // dgFullName
            // 
            this.dgFullName.HeaderText = "Name";
            this.dgFullName.Name = "dgFullName";
            this.dgFullName.ReadOnly = true;
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnActivate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActivate.Location = new System.Drawing.Point(608, 99);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(118, 44);
            this.btnActivate.TabIndex = 27;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(91, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 32);
            this.label11.TabIndex = 33;
            this.label11.Text = "Archive";
            // 
            // accountsArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(824, 458);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "accountsArchive";
            this.Text = "accountsArchive";
            this.Load += new System.EventHandler(this.accountsArchive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFullName;
        private System.Windows.Forms.Label label11;
    }
}