using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnGreek
{
    internal class Class1
    {
        
        public String question;
        public String answer1;
        public String answer2;
        public String answer3;

        public int answerGiven;
        public int correctAnswer;

        public Class1(String q,String a1,String a2,String a3,int correct)
        {
            question = q;
            answer1 = a1;
            answer2 = a2;
            answer3 = a3;
            correctAnswer = correct;
        }
        
    }
}
