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
    /// Interaction logic for ansSA.xaml
    /// </summary>
    public partial class ansSA : Window
    {
        public Question question;
        public Quiz quiz;
        public TakeQuiz tQuiz;

        public ansSA()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string cAns = question.answers.ElementAt<string>(0);
            question.correctAnswer = cAns;
            question.studentAnswer = txtSA.Text;

            if (txtSA.Text == "")
            {
                lblError.Content = "Your Answer is Empty";
            }
            else
            {
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
}
