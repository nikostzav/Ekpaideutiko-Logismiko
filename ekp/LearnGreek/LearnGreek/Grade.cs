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
    public partial class Grade : Form
    {

        string username;
        int grade;
        int chapter;
        double av;
        public Grade(string username,int grade,int chapter)
        {
            this.username = username;
            this.grade = grade;
            this.chapter = chapter;
            InitializeComponent();
        }

        private void Grade_Load(object sender, EventArgs e)
        {
            
            label1.Text = username;
            label2.Text = (grade/10).ToString() + "/10";

            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con2.Open();
            SqlCommand cmd = new SqlCommand("Select * from statistic where username = @username", con2);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (chapter != 4)
                {
                    av = Convert.ToDouble(rdr["chapter" + chapter.ToString()]);
                }
                
                if (chapter == 4)
                {
                    av = Convert.ToDouble(rdr["all_chapters"]);
                }
            }
            con2.Close();
            label5.Text = av.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(username);
            f2.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs50.htm");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
