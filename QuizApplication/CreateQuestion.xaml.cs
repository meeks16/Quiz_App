using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for CreateQuestion.xaml
    /// </summary>
    public partial class CreateQuestion : Window
    {
        public Quiz quiz;
        public CreateQuiz cq;

        public CreateQuestion()
        {
            InitializeComponent();
        }

        private void btnSA_Click(object sender, RoutedEventArgs e)
        {
            quiz.questionamount++;
            lblQuestionNumber.Content = quiz.questionamount;
            Question question = new Question { questionNumber = quiz.questionamount };
            question.questionType = "Short Answer";
            question.answers = new List<string>();
            SAQuestion saquestion = new SAQuestion();
            saquestion.question = question;
            saquestion.quiz = quiz;
            saquestion.lblQuestionNumber.Content = question.questionNumber;
            saquestion.cq = this;
            this.Hide();
            saquestion.Show(); 
        }

        private void btnTF_Click(object sender, RoutedEventArgs e)
        {
            quiz.questionamount++;
            lblQuestionNumber.Content = quiz.questionamount;
            Question question = new Question { questionNumber = quiz.questionamount };
            question.questionType = "True or False";
            question.answers = new List<string>();
            TFQuestion tfquestion = new TFQuestion();
            tfquestion.question = question;
            tfquestion.quiz = quiz;
            tfquestion.lblQuestionNumber.Content = question.questionNumber;
            tfquestion.cq = this;
            this.Hide();
            tfquestion.Show();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            quiz.questionamount++;
            lblQuestionNumber.Content = quiz.questionamount;
            Question question = new Question { questionNumber = quiz.questionamount };
            question.questionType = "Multiple Choice";
            question.answers = new List<string>();
            question.answerIndex = new List<int>();
            MultQuestion multquestion = new MultQuestion();
            multquestion.question = question;
            multquestion.quiz = quiz;
            multquestion.lblQuestionNumber.Content = question.questionNumber;
            multquestion.cq = this;
            this.Hide();
            multquestion.Show();
        }

        private void btnSubmitQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.questionamount < 3)
            {
                lblError.Content = "Please enter at least three questions";
            }
            else
            {
                this.Hide();
                cq.Show();
            }
        }
    }
}
