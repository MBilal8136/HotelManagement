using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        string query;
        //DataSet ds;

        Regex r = new Regex(@"^[0-9]{11}$");
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void Showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*' ;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select an Image";
           // op.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg";
           

            if (op.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = new Bitmap(op.FileName);
                txtImagePath.Text = op.FileName;

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txtDOB.ResetText();
            txtEmailID.Clear();
            txtGender.SelectedIndex = -1;
            txtMobile.Clear();
            txtName.Clear();
            txtPassword.Clear();   
            txtUserName.Clear();
            PictureBox.Image = Hotel_Management_System.Properties.Resources.mman;
            txtImagePath.Clear();
            Showpass.Checked = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Employee where Username='" + txtUserName.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                PhotoBox.ImageLocation = @"F:\C# project\Pharmacy Management System in C#\yes.png";
            }
            else
            {
                PhotoBox.ImageLocation = @"F:\C# project\Pharmacy Management System in C#\no.png";
            }
        }

        private void Showpass_CheckedChanged_1(object sender, EventArgs e)
        {
            if(Showpass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            txtImagePath.Visible=false;
            txtImagePa.Visible = false;
            loadData();
            loadedData();
            Showpass.Checked = false;
            if (Showpass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }

            getMax();
            ShowPassE.Checked = false;
            showpas();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text !=""&& txtMobile.Text !="" && txtGender.Text !="" && txtDOB.Text !="" && txtEmailID.Text !="" )
            {
                if (txtImagePath.Text != "")
                {
                    string name = txtName.Text;
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    string gender = txtGender.Text;
                    string dob = txtDOB.Text;
                    string email = txtEmailID.Text;
                    string username = txtUserName.Text;
                    string pass = txtPassword.Text;
                    string photo = txtImagePath.Text;
                    string role = txtRole.Text;

                    query = "insert into employee(Name,MobileNo,Gender,DOB,EmailID,Username,Password,Photo,Role) values('" + name + "'," + mobile + ",'" + gender + "','" + dob + "','" + email + "','" + username + "','" + pass + "','" + photo + "','"+role+"')";
                    fn.setData(query, "Registration Successfull.");
                    ClearAll();
                    getMax();

                }
                else
                {
                    MessageBox.Show("Please Select Image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill all Boxes.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void txtRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtRole.SelectedIndex ==0)
            {
                LableName.Visible = true;
                txtUserName.Visible = true;
                txtPassword.Visible = true;
                LabelPassword.Visible = true;
                Showpass.Visible = true;
                PhotoBox.Visible = true;
            }
            else if(txtRole.SelectedIndex ==1) 
            {
                LableName.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                LabelPassword.Visible = false;
                Showpass.Visible= false;
                PhotoBox.Visible = false;

            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtIDSearch.Text);
            string name = txtNameE.Text;
            Int64 mobile = Int64.Parse(txtMobileE.Text);
            string gender = txtGenderE.Text;
            string dob = txtDOBE.Text;
            string email = txtEmailIDE.Text;
            string username = txtUserNameE.Text;
            string pass = txtPasswordE.Text;
            string photo = txtImagePa.Text;
            string role = txtRoleE.Text;

            query = "update Employee set name='"+name+"',MobileNo="+mobile+",Gender='"+gender+ "',DOB='"+dob+ "',EmailID='"+email+ "',Username ='"+username+ "',Password='"+pass+"',Role='"+role+"',Photo='"+photo+"' where ID="+id+"";
            fn.setData(query, "Data Update Successfully.");
        }
        string file;
        private void btnSerach_Click(object sender, EventArgs e)
        {
           

            if (txtIDSearch.Text != ""    )
            {
                query = "select * from Employee where ID ='" + txtIDSearch.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtNameE.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtMobileE.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtGenderE.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtDOBE.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEmailIDE.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtUserNameE.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtPasswordE.Text = ds.Tables[0].Rows[0][7].ToString();
                    txtImagePa.Text = ds.Tables[0].Rows[0][8].ToString();
                    txtRoleE.Text = ds.Tables[0].Rows[0][9].ToString();

                    //op.FileName = txtImagePa.Text;
                    //Bitmap bitmap = new Bitmap(op.FileName);
                    //PictureBo.Image = bitmap;
                    file = @"" + txtImagePa.Text + "";
                    PictureBo.ImageLocation = file;


                }
                else
                {
                    MessageBox.Show("There is No ID :" + txtIDSearch.Text + " Exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                MessageBox.Show("Please Enter ID :", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void getMax()
        {
            query = "select max(ID) from Employee";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtlableID.Text = (num + 1).ToString();
            }
        }

        private void txtUserNameE_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ShowPassE_CheckedChanged(object sender, EventArgs e)
        {
            showpas();
        }

        public void showpas()
        {
            if (ShowPassE.Checked)
            {
                txtPasswordE.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordE.UseSystemPasswordChar = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Employee where name like'" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        public void loadData()
        {
            query = "select * from Employee" ;
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }


        public void loadedData()
        {
            query = "select * from Employee";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Employee where name like'" + txtSerch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want Delete ?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                query="delete from employee where ID ="+id+"";
                fn.setData(query, "Employee Delete Successfully.");
                UC_Employee_Load(this, null);
            }
        }

        private void btnSyno_Click(object sender, EventArgs e)
        {
            loadedData();
        }

        private void btnSyco_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnEReset_Click(object sender, EventArgs e)
        {
            txtIDSearch.Clear();
            txtNameE.Clear();
            txtMobileE.Clear();
            txtGenderE.SelectedIndex = -1;
             txtDOBE.ResetText();
             txtEmailIDE.Clear();
             txtUserNameE.Clear();
             txtPasswordE.Clear();
             txtImagePa.Clear();
            PictureBo.ImageLocation = @"F:\C# project\mman.jpg";
            txtRoleE.SelectedIndex = -1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtUserNameE_TextChanged_1(object sender, EventArgs e)
        {
            query = "select * from Employee where Username='" + txtUserNameE.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                PicBox.ImageLocation = @"F:\C# project\Pharmacy Management System in C#\yes.png";
            }
            else
            {
              PicBox.ImageLocation = @"F:\C# project\Pharmacy Management System in C#\no.png";
            }
        }

        private void PictureBo_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if(op.ShowDialog() == DialogResult.OK)
            {
                PictureBo.Image = new Bitmap(op.FileName);
                txtImagePa.Text = op.FileName;
            }
        }
    }
}
