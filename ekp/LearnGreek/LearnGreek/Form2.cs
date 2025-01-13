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

    public partial class Form2 : Form
    {
        bool chapter2Locked = false;
        bool chapter3Locked = false;
        bool allChaptersLocked = false; 

        double average1;
        int chapt1_counter;
        double average2;
        int chapt2_counter;
        double average3;
        int chapt3_counter;
        double average4;
        int chapt4_counter;

        private string myusername;
        private string mypassword;

        int gradeChapter1=0;
        int gradeChapter2=0;
        int gradeChapter3=0;

        int[] chapter1 = new int[10];
        int[] chapter2 = new int[10];
        int[] chapter3 = new int[10];

        int counterTest1 = 2;
        int counterTest2 = 2;
        int counterTest3 = 2;
        int counterTest4 = 2;
        int selected = 0;

        public void getChapterGrade()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con.Open();
            string query;
            string ans = "quest_1";

            SqlCommand cmd = new SqlCommand("select * from student where username = @username",con);
            cmd.Parameters.AddWithValue("@username", myusername);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                chapter1[0] = Convert.ToInt16(rdr["quest_1"]);
                chapter1[1] = Convert.ToInt16(rdr["quest_2"]);
                chapter1[2] = Convert.ToInt16(rdr["quest_3"]);
                chapter1[3] = Convert.ToInt16(rdr["quest_4"]);
                chapter1[4] = Convert.ToInt16(rdr["quest_5"]);
                chapter1[5] = Convert.ToInt16(rdr["quest_6"]);
                chapter1[6] = Convert.ToInt16(rdr["quest_7"]);
                chapter1[7] = Convert.ToInt16(rdr["quest_8"]);
                chapter1[8] = Convert.ToInt16(rdr["quest_9"]);
                chapter1[9] = Convert.ToInt16(rdr["quest_10"]);

                chapter2[0] = Convert.ToInt16(rdr["quest_11"]);
                chapter2[1] = Convert.ToInt16(rdr["quest_12"]);
                chapter2[2] = Convert.ToInt16(rdr["quest_13"]);
                chapter2[3] = Convert.ToInt16(rdr["quest_14"]);
                chapter2[4] = Convert.ToInt16(rdr["quest_15"]);
                chapter2[5] = Convert.ToInt16(rdr["quest_16"]);
                chapter2[6] = Convert.ToInt16(rdr["quest_17"]);
                chapter2[7] = Convert.ToInt16(rdr["quest_18"]);
                chapter2[8] = Convert.ToInt16(rdr["quest_19"]);
                chapter2[9] = Convert.ToInt16(rdr["quest_20"]);

                chapter3[0] = Convert.ToInt16(rdr["quest_21"]);
                chapter3[1] = Convert.ToInt16(rdr["quest_22"]);
                chapter3[2] = Convert.ToInt16(rdr["quest_23"]);
                chapter3[3] = Convert.ToInt16(rdr["quest_24"]);
                chapter3[4] = Convert.ToInt16(rdr["quest_25"]);
                chapter3[5] = Convert.ToInt16(rdr["quest_26"]);
                chapter3[6] = Convert.ToInt16(rdr["quest_27"]);
                chapter3[7] = Convert.ToInt16(rdr["quest_28"]);
                chapter3[8] = Convert.ToInt16(rdr["quest_29"]);
                chapter3[9] = Convert.ToInt16(rdr["quest_30"]);
            }
            con.Close();           
        }

        public void getAverage1()
        {
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con2.Open();
            SqlCommand cmd = new SqlCommand("Select * from statistic where username = @username",con2);
            cmd.Parameters.AddWithValue("@username", myusername);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                average1 = Convert.ToDouble(rdr["chapter1"]);
                chapt1_counter = Convert.ToInt32(rdr["chapter1_counter"]);
                average2 = Convert.ToDouble(rdr["chapter2"]);
                chapt2_counter = Convert.ToInt32(rdr["chapter2_counter"]);
                average3 = Convert.ToDouble(rdr["chapter3"]);
                chapt3_counter = Convert.ToInt32(rdr["chapter3_counter"]);
                average4 = Convert.ToDouble(rdr["all_chapters"]);
                chapt4_counter = Convert.ToInt32(rdr["all_chapters_counter"]);
            }
            con2.Close();
        }

        public Form2(string username)
        {
            myusername = username;           
            InitializeComponent();
        }

        public Form2(string username, string password)
        {
            myusername = username;
            mypassword = password;
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            getChapterGrade();
            getAverage1();
           // label20.Text = label20.Text + average1;
           // label21.Text = label21.Text + average2;
           // label22.Text = label22.Text + average3;
            label23.Text = label23.Text + average4;
            label2.Text = myusername;

            if (average1 < 50)
                chapter2Locked = true;
            if (average2 < 50)
                chapter3Locked = true;
            if (average3 < 50)
                allChaptersLocked = true;


            if (chapter2Locked)
            {
                pictureBox1.Visible = true;
                panel3.BackColor = Color.Black;
                panel3.Enabled = false;
                button2.Visible = false;               
            }

            if (chapter3Locked)
            {
                pictureBox2.Visible = true;
                panel4.BackColor = Color.Black;
                panel4.Enabled = false;
                button4.Visible = false;
            }

            if (allChaptersLocked)
            {
                pictureBox3.Visible = true;
                panel5.BackColor = Color.Black;
                panel5.Enabled = false;
               
            }          

            for (int i = 0; i < 10; i++)
            {
                if (chapter1[i] == 1)
                    gradeChapter1++;
                if (chapter2[i] == 1)
                    gradeChapter2++;
                if (chapter3[i] == 1)
                    gradeChapter3++;
            }

            if (gradeChapter1 >= 8)
            {
                label9.ForeColor = Color.DarkGreen;
                label10.Text = "ΑΡΙΣΤΑ";
                label10.ForeColor = Color.DarkGreen;
            }
            if ((gradeChapter1 >= 5) && (gradeChapter1 < 8))
            {
                label9.ForeColor = Color.Orange;
                label10.Text = "ΚΑΛΑ";
                label10.ForeColor = Color.Orange;
            }
            if (gradeChapter1 < 5)
            {
                label9.ForeColor = Color.Red;
                label10.Text = "ΔΙΑΒΑΣΕ ΞΑΝΑ!";
                label10.ForeColor = Color.Red;
            }

            if (gradeChapter2 >= 8)
            {
                label4.ForeColor = Color.DarkGreen;
                label4.Text = "ΑΡΙΣΤΑ";
                label5.ForeColor = Color.DarkGreen;
            }
            if ((gradeChapter2 >= 5) && (gradeChapter2 < 8))
            {
                label4.ForeColor = Color.Orange;
                label4.Text = "ΚΑΛΑ";
                label5.ForeColor = Color.Orange;
            }
            if (gradeChapter2 < 5)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "ΔΙΑΒΑΣΕ ΞΑΝΑ";
                label5.ForeColor = Color.Red;
            }

            if (gradeChapter3 >= 8)
            {
                label12.ForeColor = Color.DarkGreen;
                label12.Text = "ΑΡΙΣΤΑ";
                label13.ForeColor = Color.DarkGreen;
            }
            if ((gradeChapter3 >= 5) && (gradeChapter3 < 8))
            {
                label13.ForeColor = Color.Orange;
                label12.Text = "ΚΑΛΑ";
                label12.ForeColor = Color.Orange;
            }
            if (gradeChapter3 < 5)
            {
                label12.ForeColor = Color.Red;
                label12.Text = "ΔΙΑΒΑΣΕ ΞΑΝΑ!";
                label13.ForeColor = Color.Red;
            }

            label9.Text = (gradeChapter1 * 10).ToString() + "/100";
            label5.Text = (gradeChapter2 * 10).ToString() + "/100";
            label13.Text = (gradeChapter3 * 10).ToString() + "/100";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            
            counterTest1++;
            
            if ((counterTest1 % 2) == 1)
            {
                panel2.BackColor = Color.Green;
                if (!chapter2Locked)
                {
                    panel3.BackColor = Color.Silver;
                    counterTest2 = 2;
                    if (!chapter3Locked)
                    {
                        panel4.BackColor = Color.Silver;
                        counterTest3 = 2;
                        if (!allChaptersLocked)
                        {
                            panel5.BackColor = Color.Silver;
                            counterTest4 = 2;
                        }
                    }                                        
                }
                selected = 1;
            }
            if ((counterTest1 % 2) == 0)
            {
                panel2.BackColor = Color.Silver;
                selected = 0;
            }           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Theory1 th1 = new Theory1(chapter1);
            th1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(selected.ToString());
                       
            switch (selected)
            {
                case 1:
                    Test1 t1 = new Test1(1,myusername);
                    t1.Show();
                    Hide();
                    break;
                case 2:
                    Test1 t2 = new Test1(2,myusername);
                    t2.Show();
                    Hide();
                    break;
                case 3:
                    Test1 t3 = new Test1(3,myusername);
                    t3.Show();
                    Hide();
                    break;
                case 4:
                    Test1 t4 = new Test1(4,myusername);
                    t4.Show();
                    Hide();
                    break;
                case 0:
                    MessageBox.Show("Select a test please!");
                    break;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            counterTest2++;
            if ((counterTest2 % 2) == 1 )
            {
                panel3.BackColor = Color.Green;
                panel2.BackColor = Color.Silver;
                if (!chapter3Locked)
                {
                    panel4.BackColor = Color.Silver;
                    counterTest3 = 2;
                    if (!allChaptersLocked)
                    {
                        panel5.BackColor = Color.Silver;
                        counterTest4 = 2;
                    }
                }                              
                counterTest1 = 2;
                
                selected = 2;
            }
            if ((counterTest2 % 2) == 0)
            {
                panel3.BackColor = Color.Silver;
                selected = 0;
            }            
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            counterTest3++;
            if ((counterTest3 % 2) == 1)
            {
                panel4.BackColor = Color.Green;
                if (!allChaptersLocked)
                {
                    panel5.BackColor = Color.Silver;
                    counterTest4 = 2;
                }
                panel2.BackColor = Color.Silver;
                panel3.BackColor = Color.Silver;
                
                counterTest1 = 2;
                
                counterTest2 = 2;

                selected = 3;
            }
            if ((counterTest3 % 2) == 0)
            {
                panel4.BackColor = Color.Silver;
                selected = 0;
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            counterTest4++;

            if ((counterTest4 % 2) == 1)
            {
                panel5.BackColor = Color.Green;

                panel2.BackColor = Color.Silver;
                panel4.BackColor = Color.Silver;
                panel3.BackColor = Color.Silver;
                counterTest1 = 2;
                counterTest3 = 2;
                counterTest2 = 2;

                selected = 4;
            }
            if ((counterTest4 % 2) == 0)
            {
                panel5.BackColor = Color.Silver;
                selected = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Theory2 th2 = new Theory2(chapter2);
            th2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Theory3 the3 = new Theory3(chapter3);
                the3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Proodos p = new Proodos(myusername);
            p.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Proodos p = new Proodos(myusername);
            p.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\niktz\\Downloads\\help_ekp.chm", HelpNavigator.Topic, "html\\hs15.htm");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs15.htm");
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
