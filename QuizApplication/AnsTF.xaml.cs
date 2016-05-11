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
    /// Interaction logic for AnsTF.xaml
    /// </summary>
    public partial class AnsTF : Window
    {
        public Question question;
        public Quiz quiz;
        public TakeQuiz tQuiz;

        public AnsTF()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string cAns = question.answers.ElementAt<string>(0);
            question.correctAnswer = cAns;

            if (rBtnTrue.IsChecked == true)
            {
                question.studentAnswer = "true";
            }
            else if (rBtnFalse.IsChecked == true)
            {
                question.studentAnswer = "false";
            }
            else
            {
                lblError.Content = "Please select an answer";
            }

            if (question.correctAnswer != question.studentAnswer)
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
