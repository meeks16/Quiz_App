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
    /// Interaction logic for EditQuiz.xaml
    /// </summary>
    public partial class EditQuiz : Window
    {
        public Quiz quiz;
        public CreateQuiz cq;

        public EditQuiz()
        {
            InitializeComponent();
        }

        private void lstQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question question = (Question)lstQuestions.SelectedItem;
            if (question.questionType == "Short Answer" || question.questionType == "True or False")
            {
                txtAnswers.Text = question.answers.ElementAt<string>(0);
            }
            else
            {
                txtAnswers.Text = "";
                for (int i = 0; i < question.answerIndex.Count; i++)
                {
                    int correctanswer = question.answerIndex.ElementAt<int>(i);
                    txtAnswers.Text += question.answers.ElementAt<string>(correctanswer - 1) + " ";
                }
            }
        }

        private void btnCQ_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            cq.Show();
        }
    }
}
