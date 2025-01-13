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
    public partial class Theory2 : Form
    {
        int[] q = new int[10];
        public Theory2(int[] questions)
        {
            q = questions;
            InitializeComponent();
        }

        private void Theory2_Load(object sender, EventArgs e)
        {
            if (q[0] == 1)
                label2.ForeColor = Color.Green;
            else { label2.ForeColor = Color.Red; }
            if (q[1] == 1)
                label3.ForeColor = Color.Green;
            else { label3.ForeColor = Color.Red; }
            if (q[2] == 1)
                label4.ForeColor = Color.Green;
            else { label4.ForeColor = Color.Red; }
            if (q[3] == 1)
                label5.ForeColor = Color.Green;
            else { label5.ForeColor = Color.Red; }
            if (q[4] == 1)
                label6.ForeColor = Color.Green;
            else { label6.ForeColor = Color.Red; }
            if (q[5] == 1)
                label7.ForeColor = Color.Green;
            else { label7.ForeColor = Color.Red; }
            if (q[6] == 1)
                label8.ForeColor = Color.Green;
            else { label8.ForeColor = Color.Red; }
            if (q[7] == 1)
                label9.ForeColor = Color.Green;
            else { label9.ForeColor = Color.Red; }
            if (q[8] == 1)
                label10.ForeColor = Color.Green;
            else { label10.ForeColor = Color.Red; }
            if (q[9] == 1)
                label11.ForeColor = Color.Green;
            else { label11.ForeColor = Color.Red; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs30.htm");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
