namespace payrollsystemsti.AdminTabs
{
    partial class EmployeeReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbDates = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "payrollsystemsti.AdminTabs.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 58);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(787, 380);
            this.reportViewer1.TabIndex = 0;
            // 
            // cbDates
            // 
            this.cbDates.FormattingEnabled = true;
            this.cbDates.Location = new System.Drawing.Point(678, 23);
            this.cbDates.Name = "cbDates";
            this.cbDates.Size = new System.Drawing.Size(121, 21);
            this.cbDates.TabIndex = 1;
            this.cbDates.TextChanged += new System.EventHandler(this.cbDates_TextChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Enabled = false;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoad.Location = new System.Drawing.Point(12, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(130, 41);
            this.btnLoad.TabIndex = 40;
            this.btnLoad.Text = "Load Reports";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // EmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbDates);
            this.Controls.Add(this.reportViewer1);
            this.Name = "EmployeeReport";
            this.Text = "EmployeeReport";
            this.Load += new System.EventHandler(this.EmployeeReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbDates;
        private System.Windows.Forms.Button btnLoad;
    }
}