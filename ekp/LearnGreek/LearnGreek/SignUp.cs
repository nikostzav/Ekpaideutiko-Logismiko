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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(String.IsNullOrEmpty(textBox1.Text)) &&(textBox2.Text == textBox3.Text ) && !(String.IsNullOrEmpty(textBox2.Text)))
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                MessageBox.Show("Επιτυχής εγγραφή");

                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                con2.Open();

                SqlCommand cmd2 = new SqlCommand("insert into student(student_id,username,password) values (@student_id,@username,@password)", con2);
                cmd2.Parameters.AddWithValue("@student_id", username);
                cmd2.Parameters.AddWithValue("@username", username);
                cmd2.Parameters.AddWithValue("@password", password);
                cmd2.ExecuteNonQuery();


                con2.Close();

                SqlConnection con3 = new SqlConnection();
                con3.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                con3.Open();
                SqlCommand cmd3 = new SqlCommand("insert into statistic(username) values(@username)",con3);
                cmd3.Parameters.AddWithValue("@username", username);
                cmd3.ExecuteNonQuery();
                con3.Close();
                Form1 f1 = new Form1();
                f1.Show();
                Close();

            }
            else
            {
                MessageBox.Show("Προσπάθησε ξανά!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs40.htm");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
