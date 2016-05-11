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
    /// Interaction logic for AnsMultQ.xaml
    /// </summary>
    public partial class AnsMultQ : Window
    {
        public Question question;
        public Quiz quiz;
        public TakeQuiz tQuiz;

        public AnsMultQ()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string cAns = "";
            for (int i = 0; i < question.answerIndex.Count; i++)
            {
                int correctanswer = question.answerIndex.ElementAt<int>(i);
                cAns += question.answers.ElementAt<string>(correctanswer - 1) + " ";
            }
            question.correctAnswer = cAns;

            if (chkBox1.IsChecked == true)
            {
                question.studentAnswer = question.answers[0];
            }
            else if (chkBox2.IsChecked == true)
            {
                question.studentAnswer = question.answers[1];
            }
            else if (chkBox3.IsChecked == true)
            {
                question.studentAnswer = question.answers[2];
            }
            else if (chkBox4.IsChecked == true)
            {
                question.studentAnswer = question.answers[3];
            }
            else 
            {
                lblError.Content = "Please select answer";
            }

            if (question.studentAnswer != cAns)
            {
                tQuiz.missedQuestions.Add(question as Question);
               
            }
            else
            {
                tQuiz.quiz.numCorrectAns++;
            }
            this.Hide();
        }
    }
}
