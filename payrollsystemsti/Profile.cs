﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollsystemsti
{
    public partial class Profile : Form
    {
        Methods m = new Methods();
        //draggable panel shit
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        int loggedInID = 0;

        public static Profile profile;

        public Profile()
        {
            InitializeComponent();
            profile = this;
        }


        private void back_Click(object sender, EventArgs e)
        {
            
            this.Close();
         
        }

        public int LoggedInEmpID
        {
            set
            {
                loggedInID = value;
            }
            get
            {
                return loggedInID;
            }
        }



        private void lb_curDepartment_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            
        }
    }
}
