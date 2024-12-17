using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Hotel_UserControl
{
    public partial class UC_CustomerDetails : UserControl
    {
        function fn = new function();
        string query;
        //DataSet ds;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        //private void txtSearch_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtNameSearch_TextChanged(object sender, EventArgs e)
        //{
        //    query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,customer.Checkout,customer.Chcekout,customer.Photo,rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID where Name like'" + txtNameSearch.Text + "%'";
        //    DataSet ds = fn.getData(query);
        //    guna2DataGridView1.DataSource = ds.Tables[0];
        //}

        private void UC_CustomerDetails_Load(object sender, EventArgs e)
        {
            txtSearch.SelectedIndex = 0;
            query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,customer.Checkout,customer.Chcekout,rooms.RoomNo,rooms.RoomType,customer.Image,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID ";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            txtImagePath.Visible = false;
            txtfile.Visible = false;
        }

        private void btnSyno_Click(object sender, EventArgs e)
        {
            UC_CustomerDetails_Load(this, null);
        }

        private void txtSearch_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.SelectedIndex == 0)
            {
                query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,customer.Checkout,customer.Chcekout,rooms.RoomNo,rooms.RoomType,customer.Image,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID ";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else if (txtSearch.SelectedIndex == 1)
            {
                query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,customer.Chcekout,rooms.RoomNo,rooms.RoomType,customer.Image,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID  where checkout is NULL";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];

            }
            else if (txtSearch.SelectedIndex == 2)
            {
                query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn ,customer.Checkout,customer.Chcekout,customer.Image,rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID where checkout is not null";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }
        string file;
        //byte[] photo_aray;
        private void btnSerach_Click(object sender, EventArgs e)
        {
            if (txtIDSearch.Text != "")
            {
                query = "select * from customer where CID ='" + txtIDSearch.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtNationality.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtDOB.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtIDProof.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtAddrees.Text = ds.Tables[0].Rows[0][7].ToString();
                    txtCheckIn.Text = ds.Tables[0].Rows[0][8].ToString();
                    txtImagePath.Text = ds.Tables[0].Rows[0][12].ToString();

                    if (txtImagePath.Text != "")
                    {
                        file = @"" + txtImagePath.Text + "";
                        PictureBox.ImageLocation = file;
                    }
                    else
                    {
                        PictureBox.ImageLocation = @"F:\\C# project\\mman.jpg";
                    }
                    //PictureBox.Location = new System.Drawing.Point();

                    //if (ds.Tables[0].Rows[0][12] != System.DBNull.Value)
                    //{
                    //    photo_aray = (byte[])ds.Tables[0].Rows[0][12];
                    //    MemoryStream ms = new MemoryStream(photo_aray);
                    //    PictureBox.Image = Image.FromStream(ms);
                    //}



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
                private void btnUpdate_Click(object sender, EventArgs e)
                {

            string name = txtName.Text;
            Int64 mobileNo = Int64.Parse(txtMobileNo.Text);
            string nationality = txtNationality.Text;
            string gender = txtGender.Text;
            string dob = txtDOB.Text;
            Int64 idProof = Int64.Parse(txtIDProof.Text);
            string address = txtAddrees.Text;
            string checkin = txtCheckIn.Text;
            string iamge = txtImagePath.Text;

            
            query = "update customer set name='"+name+"',MobileNo="+mobileNo+ ",Nationality='"+nationality+"',Gender='"+gender+"',DOB='"+dob+"',IDProof="+idProof+",Addresses='"+address+"',CheckIn='"+checkin+"',Image='"+iamge+"' Where CID ="+txtIDSearch.Text+"";
            fn.setData(query, "Data Successfully Update.");

            ClearAll();

        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";

            if (op.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = new Bitmap(op.FileName);
                txtImagePath.Text = op.FileName;
            }
        }
        public void ClearAll()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDOB.ResetText();
            txtCheckIn.ResetText();
            txtIDProof.Clear();
            txtAddrees.Clear();
            txtImagePath.Clear();
            PictureBox.Image = Hotel_Management_System.Properties.Resources.mman;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtNameSearch_TextChanged_1(object sender, EventArgs e)
        {

            query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,customer.Checkout,customer.Chcekout,customer.Image,rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID where Name like'" + txtNameSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        
        private void btnSech_Click(object sender, EventArgs e)
        {
            if (txtsech.Text != "")
            {
                query = "select * from customer where  CID    ='" + txtsech.Text + "'";
                DataSet ds = fn.getData(query);
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    {
                        labName.Text = ds.Tables[0].Rows[0][1].ToString();
                        labMobileNo.Text = ds.Tables[0].Rows[0][2].ToString();
                        labNation.Text = ds.Tables[0].Rows[0][3].ToString();
                        labGender.Text = ds.Tables[0].Rows[0][4].ToString();
                        labDOB.Text = ds.Tables[0].Rows[0][5].ToString();
                        labIDProof.Text = ds.Tables[0].Rows[0][6].ToString();
                        labAddress.Text = ds.Tables[0].Rows[0][7].ToString();
                        labCheckIn.Text = ds.Tables[0].Rows[0][8].ToString();

                        labCheckOut.Text = ds.Tables[0].Rows[0][9].ToString();
                        txtfile.Text = ds.Tables[0].Rows[0][12].ToString();
                    }

                    query = "select  rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from rooms inner join customer on  rooms.RoomID = customer.RoomID where  IDProof=" + labIDProof.Text + "";
                         ds = fn.getData(query);
                    labRoomNo.Text = ds.Tables[0].Rows[0][0].ToString();
                    labRoomType.Text = ds.Tables[0].Rows[0][1].ToString();
                    labBedRoom.Text = ds.Tables[0].Rows[0][2].ToString();
                   labPrice.Text = ds.Tables[0].Rows[0][3].ToString();

                    if (txtfile.Text != "")
                    {
                        file = @"" + txtfile.Text + "";
                        picbox.ImageLocation = file;
                    }
                    else
                    {
                        picbox.ImageLocation = @"F:\\C# project\\mman.jpg";
                    }

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

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //labName.Text= guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Int64 mobile = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //labNation.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labGender.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labDOB.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labIDProof.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labAddress.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labCheckIn.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labBedRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            //labRoomNo.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //labRoomType.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           
            //Int64 price = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            //labPrice.Text = price.ToString();
        }

        private void txtIDSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(ch ==13)
            {
                btnSerach_Click(this, null);
            }
        }

        private void txtsech_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 13)
            {
                btnSech_Click(this, null);
            }
        }
    }
  }

    
        
    

