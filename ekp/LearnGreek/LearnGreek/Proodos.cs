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

namespace LearnGreek
{
    public partial class Proodos : Form
    {
        string username;
        double ch1=0;
        double ch2=0;
        double ch3=0;
        double ch4=0;
        int chapt1_counter;
        int chapt2_counter;
        int chapt3_counter;
        int chapt4_counter;
        public Proodos(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void Proodos_Load(object sender, EventArgs e)
        {
            label1.Text = username;
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con2.Open();
            SqlCommand cmd = new SqlCommand("Select * from statistic where username = @username", con2);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ch1 = Convert.ToDouble(rdr["chapter1"]);
                chapt1_counter = Convert.ToInt32(rdr["chapter1_counter"]);
                ch2 = Convert.ToDouble(rdr["chapter2"]);
                chapt2_counter = Convert.ToInt32(rdr["chapter2_counter"]);
                ch3 = Convert.ToDouble(rdr["chapter3"]);
                chapt3_counter = Convert.ToInt32(rdr["chapter3_counter"]);
                ch4 = Convert.ToDouble(rdr["all_chapters"]);
                chapt4_counter = Convert.ToInt32(rdr["all_chapters_counter"]);
            }
            con2.Close();
            label6.Text = ch1.ToString();
            label7.Text = ch2.ToString();
            label8.Text = ch3.ToString();
            label9.Text = ch4.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs45.htm");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
