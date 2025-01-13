using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnGreek
{
    public partial class Theory1 : Form
    {
        
        int counter = 0;
        string question1 = "# Java was invented by James Gosling";
        string question2 = "# Java is a platform-independent programming language";
        string question3 = "# Java uses JDK to compile programms";
        string question4 = "# Pointers is not a java feature";
        string question5 = "# Keywords can not be used for a variable name";
        string question6 = "# The extension of java code files is .java";
        string question7 = "# Compilation is not an OOPS concept in java";
        string question8 = "# OutOfMemoryError is thrown when java is out of memory";
        string question9 = "# if() is a selection statement";
        string question10 = "# interface keyword is used to define interfaces in Java";


        int[] q = new int[10];
        
        public Theory1(int[] questions)
        {
            q = questions;
            
            InitializeComponent();
        }

        private void Theory1_Load(object sender, EventArgs e)
        {
            if (q[0]==1)
                label3.ForeColor = Color.Green;
            else { label3.ForeColor = Color.Red; }
            if (q[1] == 1)
                label4.ForeColor = Color.Green;
            else { label4.ForeColor = Color.Red; }
            if (q[2] == 1)
                label5.ForeColor = Color.Green;
            else { label5.ForeColor = Color.Red; }
            if (q[3] == 1)
                label6.ForeColor = Color.Green;
            else { label6.ForeColor = Color.Red; }
            if (q[4] == 1)
                label7.ForeColor = Color.Green;
            else { label7.ForeColor = Color.Red; }
            if (q[5] == 1)
                label8.ForeColor = Color.Green;
            else { label8.ForeColor = Color.Red; }
            if (q[6] == 1)
                label9.ForeColor = Color.Green;
            else { label9.ForeColor = Color.Red; }
            if (q[7] == 1)
                label10.ForeColor = Color.Green;
            else { label10.ForeColor = Color.Red; }
            if (q[8] == 1)
                label11.ForeColor = Color.Green;
            else { label11.ForeColor = Color.Red; }
            if (q[9] == 1)
                label12.ForeColor = Color.Green;
            else { label12.ForeColor = Color.Red; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs25.htm");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
