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
    public partial class Test1 : Form
    {
        int chapter1_counter;
        int chapter2_counter;
        int chapter3_counter;
        int allChapters_counter;
        double chapter1;
        double chapter2;
        double chapter3;
        double allChapters;

        private string username;
        int[] indexes = new int[15];
        int chosenTest;
        bool select = false;
        int wrongAnswers = 0;
       
        int grade = 0;

        Class1[] test = new Class1[40];
        int cor;
        int counter2 = 0;
        int answerGiven;
        bool chose = false;
        int correctAnswer;
        int currentQuestion = -1;
        int[,] testResults = new int[30, 2];

        void initTest1()
        {
            String question1 = "Who invented Java Programming";
            String q1answ1 = "Guido van Rossum";
            String q1answ2 = "James Gosling";
            String q1answ3 = "Dennis Ritchie";
            int corAnsw1 = 2;
            test[0] = new Class1(question1,q1answ1,q1answ2,q1answ3,corAnsw1);

            String question2 = "Which statement is true about Java?";
            String q2answ1 = "Java is a platform-independent programming language";
            String q2answ2 = "Java is a platform-dependent programming language";
            String q2answ3 = "Java is a code dependent programming language";
            int corAnsw2 = 1;
            test[1] = new Class1(question2, q2answ1, q2answ2, q2answ3, corAnsw2);

            String question3 = "Which component is used to compile, debug and execute the java programs?";
            String q3answ1 = "JRE";
            String q3answ2 = "JVM";
            String q3answ3 = "JDK";
            int corAnsw3 = 3;
            test[2] = new Class1(question3, q3answ1, q3answ2, q3answ3, corAnsw3);

            String question4 = "Which one of the following is not a Java feature?";
            String q4answ1 = "Use of pointers";
            String q4answ2 = "Portable";
            String q4answ3 = "Object-oriented";
            int corAnsw4 = 1;
            test[3] = new Class1(question4, q4answ1, q4answ2, q4answ3, corAnsw4);

            String question5 = "Which of these cannot be used for a variable name in Java?";
            String q5answ1 = "identifier & keyword";
            String q5answ2 = "identifier";
            String q5answ3 = "keyword";
            int corAnsw5 = 3;
            test[4] = new Class1(question5, q5answ1, q5answ2, q5answ3, corAnsw5);

            String question6 = "What is the extension of java code files?";
            String q6answ1 = ".txt";
            String q6answ2 = ".java";
            String q6answ3 = ".js";
            int corAnsw6 = 2;
            test[5] = new Class1(question6, q6answ1, q6answ2, q6answ3, corAnsw6);

            String question7 = "Which of the following is not an OOPS concept in Java?";
            String q7answ1 = "Inheritance";
            String q7answ2 = "Polymorphism";
            String q7answ3 = "Compilation";
            int corAnsw7 = 3;
            test[6] = new Class1(question7, q7answ1, q7answ2, q7answ3, corAnsw7);

            String question8 = "Which exception is thrown when java is out of memory?";
            String q8answ1 = "OutOfMemoryError";
            String q8answ2 = "MemoryError";
            String q8answ3 = "MemoryFullException";
            int corAnsw8 = 1;
            test[7] = new Class1(question8, q8answ1, q8answ2, q8answ3, corAnsw8);


            String question9 = "Which of these are selection statements in Java?";
            String q9answ1 = "break";
            String q9answ2 = "for()";
            String q9answ3 = "if()";
            int corAnsw9 = 3;
            test[8] = new Class1(question9, q9answ1, q9answ2, q9answ3, corAnsw9);

            String question10 = "Which of these keywords is used to define interfaces in Java?";
            String q10answ1 = "interface";
            String q10answ2 = "Interface";
            String q10answ3 = "intf";
            int corAnsw10 = 1;
            test[9] = new Class1(question10, q10answ1, q10answ2, q10answ3, corAnsw10);
        }
        void initTest2() {
            String question1 = "Number of primitive data types in Java are?";
            String q1answ1 = "6";
            String q1answ2 = "7";
            String q1answ3 = "8";
            int corAnsw1 = 3;
            test[10] = new Class1(question1, q1answ1, q1answ2, q1answ3, corAnsw1);

            String question2 = "What is the size of float and double in java?";
            String q2answ1 = "32 and 64";
            String q2answ2 = "32 and 32";
            String q2answ3 = "64 and 64";
            int corAnsw2 = 1;
            test[11] = new Class1(question2, q2answ1, q2answ2, q2answ3, corAnsw2);

            String question3 = "Automatic type conversion is possible in which of the possible cases?";
            String q3answ1 = "Byte to int";
            String q3answ2 = "Int to long";
            String q3answ3 = "Short to int";
            int corAnsw3 = 2;
            test[12] = new Class1(question3, q3answ1, q3answ2, q3answ3, corAnsw3);

            String question4 = "When an array is passed to a method, what does the method receive?";
            String q4answ1 = "A copy of the array";
            String q4answ2 = "Length of the array";
            String q4answ3 = "The reference of the array";
            int corAnsw4 = 3;
            test[13] = new Class1(question4, q4answ1, q4answ2, q4answ3, corAnsw4);

            String question5 = "Select the valid statement to declare and initialize an array.";
            String q5answ1 = "int[] A = {}";
            String q5answ2 = "int[] A = {1,2,3}";
            String q5answ3 = "int[] A = (1,2,3)";
            int corAnsw5 = 2;
            test[14] = new Class1(question5, q5answ1, q5answ2, q5answ3, corAnsw5);

            String question6 = "Arrays in java are-";
            String q6answ1 = "Object references";
            String q6answ2 = "objects";
            String q6answ3 = "Primitive data types";
            int corAnsw6 = 2;
            test[15] = new Class1(question6, q6answ1, q6answ2, q6answ3, corAnsw6);

            String question7 = "When is the object created with new keyword?";
            String q7answ1 = "At run time";
            String q7answ2 = "At compile time";
            String q7answ3 = "Depends on the code";
            int corAnsw7 = 1;
            test[16] = new Class1(question7, q7answ1, q7answ2, q7answ3, corAnsw7);

            String question8 = "The object created with new keyword during run-time.";
            String q8answ1 = "A package is a collection of editing tools";
            String q8answ2 = "A package is a collection of classes";
            String q8answ3 = "A package is a collection of classes and interfaces";
            int corAnsw8 = 3;
            test[17] = new Class1(question8, q8answ1, q8answ2, q8answ3, corAnsw8);

            String question9 = "In which of the following is toString() method defined?";
            String q9answ1 = "Java.lang.Object";
            String q9answ2 = "java.lang.String";
            String q9answ3 = "None";
            int corAnsw9 = 1;
            test[18] = new Class1(question9, q9answ1, q9answ2, q9answ3, corAnsw9);

            String question10 = "compareTo() returns";
            String q10answ1 = "True";
            String q10answ2 = "An int value";
            String q10answ3 = "False";
            int corAnsw10 = 2;
            test[19] = new Class1(question10, q10answ1, q10answ2, q10answ3, corAnsw10);
        }
        void initTest3() {

            String question1 = "Total constructor string class have?";
            String q1answ1 = "3";
            String q1answ2 = "13";
            String q1answ3 = "20";
            int corAnsw1 = 2;
            test[20] = new Class1(question1, q1answ1, q1answ2, q1answ3, corAnsw1);

            String question2 = "To which of the following does the class string belong to.";
            String q2answ1 = "java.lang";
            String q2answ2 = "java.awt";
            String q2answ3 = "java.applet";
            int corAnsw2 = 1;
            test[21] = new Class1(question2, q2answ1, q2answ2, q2answ3, corAnsw2);

            String question3 = "Identify the return type of a method that does not return any value.";
            String q3answ1 = "int";
            String q3answ2 = "void";
            String q3answ3 = "double";
            int corAnsw3 = 2;
            test[22] = new Class1(question3, q3answ1, q3answ2, q3answ3, corAnsw3);

            String question4 = "Output of Math.floor(3.6)?";
            String q4answ1 = "3";
            String q4answ2 = "3.0";
            String q4answ3 = "4";
            int corAnsw4 = 2;
            test[23] = new Class1(question4, q4answ1, q4answ2, q4answ3, corAnsw4);

            String question5 = "Where does the system stores parameters and local variables whenever a method is invoked ? ";
            String q5answ1 = "Stack";
            String q5answ2 = "Heap";
            String q5answ3 = "Tree";
            int corAnsw5 = 1;
            test[24] = new Class1(question5, q5answ1, q5answ2, q5answ3, corAnsw5);

            String question6 = "Identify the modifier which cannot be used for constructor.";
            String q6answ1 = "public";
            String q6answ2 = "protected";
            String q6answ3 = "static";
            int corAnsw6 = 3;
            test[25] = new Class1(question6, q6answ1, q6answ2, q6answ3, corAnsw6);

            String question7 = "What is the variables declared in a class for the use of all methods of the class called?";
            String q7answ1 = "Object";
            String q7answ2 = "Reference variable";
            String q7answ3 = "Instance variables";
            int corAnsw7 = 3;
            test[26] = new Class1(question7, q7answ1, q7answ2, q7answ3, corAnsw7);

            String question8 = "What is the implicit return type of constructor?";
            String q8answ1 = "A class in which it is defined";
            String q8answ2 = "void";
            String q8answ3 = "None";
            int corAnsw8 = 1;
            test[27] = new Class1(question8, q8answ1, q8answ2, q8answ3, corAnsw8);

            String question9 = "When is the finalize() method called?";
            String q9answ1 = "Before garbage collection";
            String q9answ2 = "Before variable goes out of scope";
            String q9answ3 = "Before object goes out of scope";
            int corAnsw9 = 1;
            test[28] = new Class1(question9, q9answ1, q9answ2, q9answ3, corAnsw9);

            String question10 = "What is Runnable?";
            String q10answ1 = "Abstract class";
            String q10answ2 = "Class";
            String q10answ3 = "Interface";
            int corAnsw10 = 3;
            test[29] = new Class1(question10, q10answ1, q10answ2, q10answ3, corAnsw10);

        }
        public Test1(int test,String username)
        {
            this.username = username;
            for (int i=0;i<30;i++)
            {
                for (int j=0;j<2; j++)
                {
                    testResults[i, j] = -1;
                }
            }
            switch (test)
            {
                case 1:
                    initTest1();
                    break;
                case 2:
                    initTest2();
                    break;
                case 3:
                    initTest3();
                    break;
                case 4:
                    initTest1();
                    initTest2();
                    initTest3();
                    break;
            }
            chosenTest = test;
            
            InitializeComponent();

            label7.Text = "Username: " + username;
            label6.Visible = false;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
            con.Open();
            Random rand = new Random();
            int index =-1;
            chose = false;
            if (counter2 > 0)
            {
                if (select)
                {
                    while (true)
                    {
                        if (chosenTest == 1) 
                            index = rand.Next(0, 10);
                        if (chosenTest ==2)
                            index = rand.Next(10, 20);
                        if (chosenTest == 3)
                            index = rand.Next(20, 30);
                        if (chosenTest == 4)
                        {
                            index = rand.Next(0, 30);
                            indexes[counter2] = index;
                        }
                        
                        if (testResults[index, 0].Equals(-1))
                        {
                            
                            counter2++;
                            testResults[index, 0] = index;

                            currentQuestion = index;
                            label2.Text = test[index].question;
                            label3.Text = test[index].answer1;
                            label4.Text = test[index].answer2;
                            label5.Text = test[index].answer3;
                            correctAnswer = test[index].correctAnswer;
                            cor = correctAnswer;
                            panel2.BackColor = Color.White;
                            panel3.BackColor = Color.White;
                            panel4.BackColor = Color.White;
                            break;
                        }
                        if (counter2 >= 10)
                        {
                            grade = (10 - wrongAnswers) * 10;
                            
                            int i = 0;
                            switch (chosenTest)
                            {
                                case 1:
                                    i = 0;
                                    break;
                                case 2:
                                    i = 10;
                                    break;
                                case 3:
                                    i = 20;
                                    break;
                                case 4:
                                    for (int c = 0; c < 10; c++)
                                    {
                                        String q2 = "Update student set quest_" +(testResults[indexes[c],0]+1).ToString() +"=@quest where username = @user";
                                        SqlCommand cmd2 = new SqlCommand(q2, con);
                                        cmd2.Parameters.AddWithValue("@quest",testResults[indexes[c],1]+1);
                                        cmd2.Parameters.AddWithValue("@user", username);
                                        cmd2.ExecuteNonQuery();                                        
                                    }                                   
                                    break;
                            }
                            if (chosenTest != 4)
                            {
                                SqlConnection con2 = new SqlConnection();
                                con2.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                con2.Open();

                                SqlCommand cmd2 = new SqlCommand("select chapter1,chapter1_counter,chapter2,chapter2_counter,chapter3,chapter3_counter from statistic where username = @username", con2);
                                cmd2.Parameters.AddWithValue("@username", username);
                                SqlDataReader rdr = cmd2.ExecuteReader();
                                while (rdr.Read())
                                {
                                    chapter1_counter = Convert.ToInt16(rdr["chapter1_counter"]);
                                    chapter2_counter = Convert.ToInt16(rdr["chapter2_counter"]);
                                    chapter3_counter = Convert.ToInt16(rdr["chapter3_counter"]);
                                    
                                    chapter1 = Convert.ToDouble(rdr["chapter1"]);
                                    chapter2 = Convert.ToDouble(rdr["chapter2"]);
                                    chapter3 = Convert.ToDouble(rdr["chapter3"]);
                                                                        
                                }
                                con2.Close();
                                

                                SqlConnection con3 = new SqlConnection();
                                con3.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                con3.Open();
                                SqlCommand cmd3 = new SqlCommand("Update statistic set chapter"+chosenTest.ToString()+"_counter=@chapter where username = @username",con3);
                                if (chosenTest == 1) {
                                    cmd3.Parameters.AddWithValue("@chapter",chapter1_counter+1);
                                    cmd3.Parameters.AddWithValue("username", username);
                                    cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    SqlConnection con4 = new SqlConnection();
                                    con4.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                    con4.Open();
                                    SqlCommand cmd4 = new SqlCommand("Update statistic set chapter"+chosenTest.ToString()+"=@chapter where username = @username",con4);
                                    cmd4.Parameters.AddWithValue("@chapter",((chapter1*chapter1_counter)+grade)/(chapter1_counter+1));
                                    cmd4.Parameters.AddWithValue("@username", username);
                                    cmd4.ExecuteNonQuery();
                                    con4.Close();                                 

                                }
                                if (chosenTest == 2)
                                {
                                    cmd3.Parameters.AddWithValue("@chapter", chapter2_counter + 1);
                                    cmd3.Parameters.AddWithValue("username", username);
                                    cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    SqlConnection con4 = new SqlConnection();
                                    con4.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                    con4.Open();
                                    SqlCommand cmd4 = new SqlCommand("Update statistic set chapter" + chosenTest.ToString() + "=@chapter where username = @username", con4);
                                    cmd4.Parameters.AddWithValue("@chapter", ((chapter2*chapter2_counter) + grade) / (chapter2_counter+1));
                                    cmd4.Parameters.AddWithValue("@username", username);
                                    cmd4.ExecuteNonQuery();
                                    con4.Close();
                                }
                                if (chosenTest == 3)
                                {
                                    cmd3.Parameters.AddWithValue("@chapter", chapter3_counter + 1);
                                    cmd3.Parameters.AddWithValue("username", username);
                                    cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    SqlConnection con4 = new SqlConnection();
                                    con4.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                    con4.Open();
                                    SqlCommand cmd4 = new SqlCommand("Update statistic set chapter" + chosenTest.ToString() + "=@chapter where username = @username", con4);
                                    cmd4.Parameters.AddWithValue("@chapter", ((chapter3*chapter3_counter) + grade) / (chapter3_counter+1));
                                    cmd4.Parameters.AddWithValue("@username", username);
                                    cmd4.ExecuteNonQuery();
                                    con4.Close();
                                }
                                                               
                                for (int j = i; j < i + 10; j++)
                                {
                                    String query = "Update student set quest_" + (testResults[j,0]+1).ToString() + "=@question where username = @username";
                                    SqlCommand cmd = new SqlCommand(query, con);
                                    cmd.Parameters.AddWithValue("@question", testResults[j, 1] + 1);
                                    cmd.Parameters.AddWithValue("@username", username);
                                    cmd.ExecuteNonQuery();
                                }
                                Grade g = new Grade(username, grade,chosenTest);
                                g.Show();
                                Close();
                            }
                            if (chosenTest == 4)
                            {

                                SqlConnection con10 = new SqlConnection();
                                con10.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                con10.Open();
                                SqlCommand cmd10 = new SqlCommand("Select all_chapters,all_chapters_counter from statistic where username=@username",con10);
                                cmd10.Parameters.AddWithValue("@username", username);
                                SqlDataReader reader = cmd10.ExecuteReader();
                                while (reader.Read())
                                {
                                    allChapters = Convert.ToDouble(reader["all_chapters"]);
                                    allChapters_counter = Convert.ToInt16(reader["all_chapters_counter"]);                                    
                                }
                               
                                SqlConnection con5 = new SqlConnection();
                                con5.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                con5.Open();
                                SqlCommand cmd6 = new SqlCommand("Update statistic set all_chapters_counter=@chapter where username = @username", con5);
                                cmd6.Parameters.AddWithValue("@chapter", allChapters_counter + 1);
                                cmd6.Parameters.AddWithValue("@username", username);
                                cmd6.ExecuteNonQuery();
                                con5.Close();
                                SqlConnection con7 = new SqlConnection();
                                con7.ConnectionString = "Data Source=LAPTOP-M2KT8KSS\\DANAH;Initial Catalog=school;Integrated Security=True";
                                con7.Open();
                                SqlCommand cmd8 = new SqlCommand("Update statistic set all_chapters=@chapter where username = @username", con7);
                                cmd8.Parameters.AddWithValue("@chapter", ((allChapters*allChapters_counter) + grade) / (allChapters_counter+1) ) ;
                                cmd8.Parameters.AddWithValue("@username", username);
                                cmd8.ExecuteNonQuery();
                                con7.Close();

                                Grade g = new Grade(username, grade, chosenTest);
                                g.Show();
                                Close(); 
                            }
                            break;                           
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Επίλεξε μία απάντηση!");
                }
            }

            else
            {
                button1.Text = "ΕΠΟΜΕΝΟ";
                counter2++;
               
                if (chosenTest == 1)
                    index = rand.Next(0, 10);
                if (chosenTest == 2)
                    index = rand.Next(10, 20);
                if (chosenTest == 3)
                    index = rand.Next(20, 30);
                if (chosenTest == 4)
                {
                    index = rand.Next(0, 30);
                    indexes[0] = index;
                }

                testResults[index, 0] = index;

                currentQuestion = index;
                label2.Text = test[index].question;
                label3.Text = test[index].answer1;
                label4.Text = test[index].answer2;
                label5.Text = test[index].answer3;
                correctAnswer = test[index].correctAnswer;
                cor = correctAnswer;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.White;
                panel4.BackColor = Color.White;

                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
            }
            label6.Visible = true;
            label6.Text = counter2.ToString();
            select = false;

            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {          
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            select = true;
            if (chose == false)
            {
                
                answerGiven = 1;
                
                if (cor == answerGiven)
                {
                    panel2.BackColor = Color.Green;
                    testResults[currentQuestion,1] = 0; 
                }
                else { wrongAnswers++; 
                    testResults[currentQuestion, 1] = 1; }
                if (cor == 2)
                {
                    panel3.BackColor = Color.Green;
                    panel2.BackColor = Color.Red;
                }
                if (cor == 3)
                {
                    panel4.BackColor = Color.Green;
                    panel2.BackColor = Color.Red;
                }
                chose = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            select = true;
            if (chose == false)
            {
                
                answerGiven = 2;
                if (cor == answerGiven)
                {
                    testResults[currentQuestion, 1] = 0;
                    panel3.BackColor = Color.Green;
                }
                else { wrongAnswers++; testResults[currentQuestion, 1] = 1; }
                if (cor == 1)
                {
                    panel2.BackColor = Color.Green;
                    panel3.BackColor = Color.Red;
                }
                if (cor == 3)
                {
                    panel4.BackColor = Color.Green;
                    panel3.BackColor = Color.Red;
                }
                chose = true;
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            select = true;
            if (chose == false) {
                
                answerGiven = 3;
                if (cor == answerGiven)
                {
                    panel4.BackColor = Color.Green;
                    testResults[currentQuestion, 1] = 0;
                }
                else { wrongAnswers++; testResults[currentQuestion, 1] = 1; }
                if (cor == 1)
                {
                    panel2.BackColor = Color.Green;
                    panel4.BackColor = Color.Red;
                }
                if (cor == 2)
                {
                    panel3.BackColor = Color.Green;
                    panel4.BackColor = Color.Red;
                }
                chose = true;
            }
        }
        private void Test1_Load(object sender, EventArgs e)
        {
            button1.Text = "ΞΕΚΙΝΑ!";
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Users\\danah\\Desktop\\help_ekp.chm", HelpNavigator.Topic, "html\\hs20.htm");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
