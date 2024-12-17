using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            query = "select * from employee  ";
            ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {

                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                {
                    labelError.Visible = false;
                    Dashboard db = new Dashboard();
                    db.Show();
                    this.Hide();

                }
                else
                {
                    labelError.Visible = true;
                    //MessageBox.Show("Your Username & Password is Wrong", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                }
            }
            else
            {
                query = "select * from employee where username ='" + txtUsername.Text + "' and password ='" + txtPassword.Text + "'";
                ds = fn.getData(query);
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string role = ds.Tables[0].Rows[0][9].ToString();
                    if (role == "Manager")
                    {
                        labelError.Visible = false;
                        Dashboard db = new Dashboard();
                        db.Show();
                        this.Hide();
                    }
                }
                else
                {
                    labelError.Visible = true;
                    //MessageBox.Show("Your Username & Password is Wrong", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(ch == 13)
            {
                btnLogin_Click(this, null);
            }
        }
    }
}
