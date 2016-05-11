using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QuizApplication
{
    public class Quiz
    {
        public string name { get; set; }
        public int questionamount { get; set; }
        public ObservableCollection<Question> QuestionsList;
        public int numCorrectAns { get; set; }
        public int progCount { get; set; }
    }
}
