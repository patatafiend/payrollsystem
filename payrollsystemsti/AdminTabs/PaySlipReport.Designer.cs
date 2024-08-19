namespace payrollsystemsti.AdminTabs
{
    partial class PaySlipReport
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.btnSingle = new System.Windows.Forms.Button();
            this.cbPayDates = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "payrollsystemsti.AdminTabs.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(972, 531);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Enabled = false;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbSearch.Location = new System.Drawing.Point(788, 16);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(172, 23);
            this.tbSearch.TabIndex = 38;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Enabled = false;
            this.btnLoad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoad.Location = new System.Drawing.Point(260, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(130, 41);
            this.btnLoad.TabIndex = 39;
            this.btnLoad.Text = "Load Payslip";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBatch.Location = new System.Drawing.Point(136, 6);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(118, 44);
            this.btnBatch.TabIndex = 35;
            this.btnBatch.Text = "Batch";
            this.btnBatch.UseVisualStyleBackColor = false;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // btnSingle
            // 
            this.btnSingle.BackColor = System.Drawing.Color.Teal;
            this.btnSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSingle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSingle.Location = new System.Drawing.Point(12, 6);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(118, 44);
            this.btnSingle.TabIndex = 35;
            this.btnSingle.Text = "Single";
            this.btnSingle.UseVisualStyleBackColor = false;
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // cbPayDates
            // 
            this.cbPayDates.Enabled = false;
            this.cbPayDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPayDates.FormattingEnabled = true;
            this.cbPayDates.Location = new System.Drawing.Point(586, 16);
            this.cbPayDates.Name = "cbPayDates";
            this.cbPayDates.Size = new System.Drawing.Size(179, 24);
            this.cbPayDates.TabIndex = 40;
            // 
            // PaySlipReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 584);
            this.Controls.Add(this.cbPayDates);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.btnSingle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PaySlipReport";
            this.Text = "PaySlipReport";
            this.Load += new System.EventHandler(this.PaySlipReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.ComboBox cbPayDates;
    }
}