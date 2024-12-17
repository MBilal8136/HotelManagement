using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System.Hotel_UserControl
{
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           txtRoomNo.Clear();
            txtRoomType.StartIndex = -1;
            txtRoomBed.StartIndex = -1;
            txtPrice.Clear();   
            txtSearch.Clear();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Delete ?","Conformation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "delete from rooms where RoomID=" + id + "";
                fn.setData(query, "Room Delete Successfully.");
                loadData();
            }

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtRoomBed.Text != "" && txtPrice.Text != "")
            {
                string roomNo = txtRoomNo.Text;
                string roomType = txtRoomType.Text;
                string bed = txtRoomBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into rooms (RoomNo, RoomType, Bed, Price) values('" + roomNo + "','" + roomType + "','" + bed + "'," + price + ")";
                fn.setData(query, "Room Add Successfully .");
                UC_AddRoom_Load(this, null);
                btnReset_Click(this, null);
            }
            else
            {
                MessageBox.Show("Please Fill All Boxes","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            ds=fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            
        }
        public void loadData()
        {
            query = "select * from rooms";
            ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        
        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           

           txtRoomNo.Text =guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRoomType.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRoomBed.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Int64 price = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            txtPrice.Text=price.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtRoomBed.Text != "" && txtPrice.Text != "")
            {
                query = "update rooms set RoomNo='" + txtRoomNo.Text + "',RoomType='" + txtRoomType.Text + "',Bed='" + txtRoomBed.Text + "',Price=" + txtPrice.Text + " where RoomID=" + id + "";
                fn.setData(query, "Room Update Successfully .");
                loadData();
            }
            else
            {
                MessageBox.Show("Please Fill All Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from rooms where Booked like'" + txtSearch.Text + "%' OR RoomNo like'" + txtSearch.Text + "%'";
            ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
               
                //query = "select * from rooms where RoomNo like'" + txtSearch.Text + "%'";
                //ds = fn.getData(query);
                //guna2DataGridView1.DataSource = ds.Tables[0];
            
            
        }

        private void btnSyno_Click(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
    }
}
