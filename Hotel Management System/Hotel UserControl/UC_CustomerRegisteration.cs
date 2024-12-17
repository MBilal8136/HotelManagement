using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Hotel_UserControl
{
    public partial class UC_CustomerRegisteration : UserControl
    {
        function fn = new function();
        string query;
        public UC_CustomerRegisteration()
        {
            InitializeComponent();
        }

        public void setComboBox(string query, ComboBox combo)
        {
            SqlDataReader sdr= fn.getForCombo(query);
            while(sdr.Read())
            {
                for(int i=0; i<sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i)); 
                }
            }
            sdr.Close();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Clear();
            txtRoomNo.Items.Clear();
            query = "select RoomNo from rooms where Bed='" + txtRoomBed.Text + "' and RoomType='"+txtRoomType.Text+"'and Booked='NO'";
            setComboBox(query, txtRoomNo);
        }

        private void txtRoomBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();

        }
        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select Price ,RoomID from rooms where RoomNo='" + txtRoomNo.Text + "'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllote_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobileNo.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDOB.Text != "" && txtIDProof.Text != "" && txtAddrees.Text != "" && txtCheckIn.Text != "" && txtRoomBed.Text != "" && txtRoomNo.Text != "" && txtRoomType.Text != "" && txtPrice.Text != "")
            {
                if (txtImagePath.Text != "")
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

                query = "insert into customer(Name, MobileNo,Nationality,Gender,DOB,IDProof,Addresses,CheckIn,RoomID,Image) values('" + name + "'," + mobileNo + ",'" + nationality + "','" + gender + "','" + dob + "','" + idProof + "','" + address + "','" + checkin + "'," + rid + ",'" + iamge + "') update rooms set Booked='YES' where RoomNo ='" + txtRoomNo.Text + "'";
                fn.setData(query, "Room No" + txtRoomNo.Text + " Booked Successflly.");
                ResetData();
                getMax();
                }
                else
                {
                    MessageBox.Show("Please Select Image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            }
            else
            {
                MessageBox.Show("Please Fill All Boxes ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you Want to Reset ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
               ResetData();
            
            }


        }
        public void ResetData()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDOB.ResetText();
            txtCheckIn.ResetText();
            txtIDProof.Clear();
            txtAddrees.Clear();

            txtRoomBed.SelectedIndex = -1;
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.SelectedIndex = -1;
            txtPrice.Clear();
            txtImagePath.Clear();
            PictureBox.Image = Hotel_Management_System.Properties.Resources.mman;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";

            if(op.ShowDialog()== DialogResult.OK )
            {
                PictureBox.Image= new Bitmap(op.FileName );
                txtImagePath.Text= op.FileName;
            }
        }

        private void UC_CustomerRegisteration_Load(object sender, EventArgs e)
        {
            getMax();
            txtImagePath.Visible = false;
        }
        public void getMax()
        {
            query = "select max(CID) from customer";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtlableID.Text = (num + 1).ToString();
            }
        }
    }
}
