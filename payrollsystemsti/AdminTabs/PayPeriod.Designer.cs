namespace payrollsystemsti.AdminTabs
{
    partial class PayPeriod
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnl_totalEmployee = new System.Windows.Forms.Panel();
            this.lb1st = new System.Windows.Forms.Label();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.lb2nd = new System.Windows.Forms.Label();
            this.pnl_totalEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(46, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 87;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // tb1
            // 
            this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(46, 131);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(118, 32);
            this.tb1.TabIndex = 83;
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb1_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Location = new System.Drawing.Point(46, 169);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 44);
            this.btnUpdate.TabIndex = 81;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnl_totalEmployee
            // 
            this.pnl_totalEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(244)))), ((int)(((byte)(221)))));
            this.pnl_totalEmployee.Controls.Add(this.rb2);
            this.pnl_totalEmployee.Controls.Add(this.lb2nd);
            this.pnl_totalEmployee.Controls.Add(this.lb1st);
            this.pnl_totalEmployee.Controls.Add(this.rb1);
            this.pnl_totalEmployee.Location = new System.Drawing.Point(46, 32);
            this.pnl_totalEmployee.Name = "pnl_totalEmployee";
            this.pnl_totalEmployee.Size = new System.Drawing.Size(198, 70);
            this.pnl_totalEmployee.TabIndex = 88;
            // 
            // lb1st
            // 
            this.lb1st.AutoSize = true;
            this.lb1st.BackColor = System.Drawing.Color.Transparent;
            this.lb1st.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1st.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb1st.Location = new System.Drawing.Point(24, 33);
            this.lb1st.Name = "lb1st";
            this.lb1st.Size = new System.Drawing.Size(46, 23);
            this.lb1st.TabIndex = 5;
            this.lb1st.Text = "169";
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.rb1.Location = new System.Drawing.Point(5, 10);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(80, 20);
            this.rb1.TabIndex = 90;
            this.rb1.TabStop = true;
            this.rb1.Text = "1st Cutoff";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.rb2.Location = new System.Drawing.Point(104, 10);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(84, 20);
            this.rb2.TabIndex = 93;
            this.rb2.TabStop = true;
            this.rb2.Text = "2nd Cutoff";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // lb2nd
            // 
            this.lb2nd.AutoSize = true;
            this.lb2nd.BackColor = System.Drawing.Color.Transparent;
            this.lb2nd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2nd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb2nd.Location = new System.Drawing.Point(125, 33);
            this.lb2nd.Name = "lb2nd";
            this.lb2nd.Size = new System.Drawing.Size(46, 23);
            this.lb2nd.TabIndex = 92;
            this.lb2nd.Text = "169";
            // 
            // PayPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 297);
            this.Controls.Add(this.pnl_totalEmployee);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.btnUpdate);
            this.Name = "PayPeriod";
            this.Text = "PayPeriod";
            this.Load += new System.EventHandler(this.PayPeriod_Load);
            this.pnl_totalEmployee.ResumeLayout(false);
            this.pnl_totalEmployee.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel pnl_totalEmployee;
        private System.Windows.Forms.Label lb1st;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.Label lb2nd;
    }
}