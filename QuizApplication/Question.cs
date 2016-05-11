using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    public class Question
    {
        public int questionNumber { get; set; }
        public string questionString { get; set; }
        public string questionType { get; set; }
        public List<string> answers;
        public List<int> answerIndex;
        public string studentAnswer { get; set; }
        public string correctAnswer { get; set; }
    }
}
