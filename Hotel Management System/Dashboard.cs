using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            btnAddRoom.PerformClick();
            uC_CustomerRegisteration1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnCustResgis_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustResgis.Left+19;

            uC_CustomerRegisteration1.Visible = true;
            uC_CustomerRegisteration1.BringToFront();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnAddRoom.Left + 19;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCheckout.Left + 19;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront() ;
        }

        private void btnCustDetail_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustDetail.Left + 19;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnEmployee.Left + 19;
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm= new Form1();
            fm.Show();
            this.Hide();
        }
    }
}
