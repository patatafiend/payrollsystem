namespace payrollsystemsti
{
    partial class BackupRestore
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
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBrowseB = new System.Windows.Forms.Button();
            this.tbLocationB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbLocationR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseR = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.Enabled = false;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBackup.Location = new System.Drawing.Point(173, 68);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(118, 44);
            this.btnBackup.TabIndex = 27;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBrowseB
            // 
            this.btnBrowseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseB.BackColor = System.Drawing.Color.Teal;
            this.btnBrowseB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseB.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseB.Location = new System.Drawing.Point(49, 68);
            this.btnBrowseB.Name = "btnBrowseB";
            this.btnBrowseB.Size = new System.Drawing.Size(118, 44);
            this.btnBrowseB.TabIndex = 26;
            this.btnBrowseB.Text = "Browse";
            this.btnBrowseB.UseVisualStyleBackColor = false;
            this.btnBrowseB.Click += new System.EventHandler(this.btnBrowseB_Click);
            // 
            // tbLocationB
            // 
            this.tbLocationB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocationB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLocationB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLocationB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocationB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbLocationB.Location = new System.Drawing.Point(102, 34);
            this.tbLocationB.Name = "tbLocationB";
            this.tbLocationB.Size = new System.Drawing.Size(172, 23);
            this.tbLocationB.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Location:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLocationB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBrowseB);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Location = new System.Drawing.Point(169, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 156);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup Database";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbLocationR);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBrowseR);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Location = new System.Drawing.Point(634, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 156);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore Database";
            // 
            // tbLocationR
            // 
            this.tbLocationR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocationR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbLocationR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbLocationR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocationR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbLocationR.Location = new System.Drawing.Point(102, 34);
            this.tbLocationR.Name = "tbLocationR";
            this.tbLocationR.Size = new System.Drawing.Size(172, 23);
            this.tbLocationR.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Location:";
            // 
            // btnBrowseR
            // 
            this.btnBrowseR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseR.BackColor = System.Drawing.Color.Teal;
            this.btnBrowseR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseR.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseR.Location = new System.Drawing.Point(49, 68);
            this.btnBrowseR.Name = "btnBrowseR";
            this.btnBrowseR.Size = new System.Drawing.Size(118, 44);
            this.btnBrowseR.TabIndex = 26;
            this.btnBrowseR.Text = "Browse";
            this.btnBrowseR.UseVisualStyleBackColor = false;
            this.btnBrowseR.Click += new System.EventHandler(this.btnBrowseR_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Enabled = false;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRestore.Location = new System.Drawing.Point(173, 68);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(118, 44);
            this.btnRestore.TabIndex = 27;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // BackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BackupRestore";
            this.Text = "BackupRestore";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBrowseB;
        private System.Windows.Forms.TextBox tbLocationB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLocationR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseR;
        private System.Windows.Forms.Button btnRestore;
    }
}