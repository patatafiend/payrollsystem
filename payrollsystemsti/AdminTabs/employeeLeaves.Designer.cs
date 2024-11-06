namespace payrollsystemsti.AdminTabs
{
	partial class employeeLeaves
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dgv_empLeaves = new System.Windows.Forms.DataGridView();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lb_empLeaves = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empLeaves)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(808, 65);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 44);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Back";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btn_back);
            // 
            // dgv_empLeaves
            // 
            this.dgv_empLeaves.AllowUserToAddRows = false;
            this.dgv_empLeaves.AllowUserToDeleteRows = false;
            this.dgv_empLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_empLeaves.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_empLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_empLeaves.Location = new System.Drawing.Point(93, 116);
            this.dgv_empLeaves.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_empLeaves.Name = "dgv_empLeaves";
            this.dgv_empLeaves.ReadOnly = true;
            this.dgv_empLeaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_empLeaves.Size = new System.Drawing.Size(833, 408);
            this.dgv_empLeaves.TabIndex = 30;
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(194)))));
            this.pnl_top.Controls.Add(this.lb_empLeaves);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1047, 45);
            this.pnl_top.TabIndex = 29;
            // 
            // lb_empLeaves
            // 
            this.lb_empLeaves.AutoSize = true;
            this.lb_empLeaves.BackColor = System.Drawing.Color.Transparent;
            this.lb_empLeaves.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_empLeaves.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_empLeaves.Location = new System.Drawing.Point(3, 11);
            this.lb_empLeaves.Name = "lb_empLeaves";
            this.lb_empLeaves.Size = new System.Drawing.Size(170, 23);
            this.lb_empLeaves.TabIndex = 0;
            this.lb_empLeaves.Text = "Available Leaves";
            // 
            // employeeLeaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1047, 654);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgv_empLeaves);
            this.Controls.Add(this.pnl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "employeeLeaves";
            this.Load += new System.EventHandler(this.departmentList_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empLeaves)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridView dgv_empLeaves;
		private System.Windows.Forms.Panel pnl_top;
		private System.Windows.Forms.Label lb_empLeaves;
	}
}