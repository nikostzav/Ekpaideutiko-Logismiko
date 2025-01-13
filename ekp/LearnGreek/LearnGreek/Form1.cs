using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;

namespace LearnGreek
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {           
            SqlConnection con = new SqlConnection();
            con.ConnectionString =
            "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            InitializeComponent();
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True");
            con.Open();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Επιτυχής σύνδεση");
                Form2 f2 = new Form2(username, password);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Μη έγκυρη σύνδεση, ελέγξτε το username και το password");
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SignUp s = new SignUp();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs10.htm");
        }
    }
}