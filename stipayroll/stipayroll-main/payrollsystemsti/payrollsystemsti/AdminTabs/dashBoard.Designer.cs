namespace payrollsystemsti
{
    partial class dashBoard
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
            this.label1 = new System.Windows.Forms.Label();
            this.pbEmpPic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(127, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "dashboad";
            // 
            // pbEmpPic
            // 
            this.pbEmpPic.Location = new System.Drawing.Point(3, 4);
            this.pbEmpPic.Name = "pbEmpPic";
            this.pbEmpPic.Size = new System.Drawing.Size(95, 84);
            this.pbEmpPic.TabIndex = 2;
            this.pbEmpPic.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbEmpPic);
            this.panel1.Location = new System.Drawing.Point(687, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 91);
            this.panel1.TabIndex = 3;
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashBoard";
            this.Text = "dashBoard";
            this.Load += new System.EventHandler(this.dashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbEmpPic;
        private System.Windows.Forms.Panel panel1;
    }
}