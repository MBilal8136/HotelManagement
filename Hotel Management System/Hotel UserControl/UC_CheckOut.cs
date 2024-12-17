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
    public partial class UC_CheckOut : UserControl
    {
        function fn = new function();
        string query;
        public UC_CheckOut()
        {
            InitializeComponent();
        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID where chcekout ='NO'";
            //query = "select * from customer";
            DataSet ds=fn.getData(query);
            guna2DataGridView1.DataSource= ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.CID,customer.Name,customer.MobileNo,customer.Nationality,customer.Gender,customer.DOB,customer.IDProof,customer.Addresses,customer.CheckIn,rooms.RoomNo,rooms.RoomType,rooms.Bed,rooms.Price from customer inner join rooms on customer.RoomID = rooms.RoomID where Name like'"+txtSearch.Text+"%'and chcekout ='NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNo.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(txtName.Text !="" && txtRoomNo.Text !="")
            {
                if(MessageBox.Show("Are You sure for Check Out ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    string cdate= txtCheckOut.Text;
                    query = "update customer set Chcekout='YES',Checkout='" + cdate + "'where CID=" + id + " update rooms set Booked='No' where RoomNo='" + txtRoomNo.Text + "'";
                    fn.setData(query, "Check Out Successfull.");
                    UC_CheckOut_Load(this, null);
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearAll()
        {
            txtName.Clear();
            txtRoomNo.Clear();
            txtSearch.Clear();
            txtCheckOut.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSyno_Click(object sender, EventArgs e)
        {
            UC_CheckOut_Load(this, null);
        }
    }
}
