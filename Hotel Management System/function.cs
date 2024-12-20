﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    internal class function
    {
        protected SqlConnection getConnection() 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source= DESKTOP-7IUUBVC\\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True";
            return con;
        } 
        public DataSet getData(string query)
        {
            SqlConnection con= getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            cmd.CommandText = query;
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataSet ds= new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(string query,string msg)
        {
            SqlConnection con= getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            con.Open();
            cmd.CommandText= query;
            cmd.ExecuteNonQuery();
            con.Close();
           MessageBox.Show("'"+msg+"'", "Conformation", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
            
            }

        public SqlDataReader getForCombo(string query)
        {
            SqlConnection con= getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;
            con.Open();
            cmd= new SqlCommand(query,con);
            SqlDataReader sdr= cmd.ExecuteReader();
            return sdr;

        }
    }
}
