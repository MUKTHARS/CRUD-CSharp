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

namespace CRUD__C_
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-01EO653\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserTable values(@ID,@Name,@Age)",con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(metroTextBox1.Text));
            cmd.Parameters.AddWithValue("@Name",metroTextBox2.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(metroTextBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully!");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-01EO653\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTable set Name=@Name, Age=@Age where ID=@ID",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox1.Text));
            cmd.Parameters.AddWithValue("@Name", metroTextBox2.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(metroTextBox3.Text));
            cmd.ExecuteNonQuery(); 
            con.Close();
            MessageBox.Show("Updated Successfully!");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-01EO653\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete UserTable where ID=@ID",con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(metroTextBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully!");
            



        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-01EO653\\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserTable where ID=@ID ",con);
            cmd.Parameters.AddWithValue("ID", int.Parse(metroTextBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
