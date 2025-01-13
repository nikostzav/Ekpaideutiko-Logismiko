using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace LearnGreek
{
    public partial class Login : Form
    {
       
        SqlConnection con = new SqlConnection();
        public Login()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString =
            "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from student where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess Welcome to Homepage ");
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }
    }
}
