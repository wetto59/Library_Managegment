﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Managegment_App
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=KHALID\SQLEXPRESS;Initial Catalog=library_management_system;Integrated Security=True;Pooling=False");
        int count = 0;

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"select * from library_person where username='{textBox1.Text}' and password='{textBox2.Text}'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0) 
            {
                MessageBox.Show("username password does not match");
            }
            else 
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
            }
        }
    }
}
