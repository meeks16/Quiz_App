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
    /// Interaction logic for TFQuestion.xaml
    /// </summary>
    public partial class TFQuestion : Window
    {
        public Question question;
        public Quiz quiz;
        public CreateQuestion cq;

        public TFQuestion()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text == "")
            {
                lblError.Content = "Please enter a question";
            }
            else if (radTrue.IsChecked == false && radFalse.IsChecked == false)
            {
                lblError.Content = "Please select an answer";
            }
            else
            {
                if (radTrue.IsChecked == true)
                {
                    question.answers.Add("true");
                }
                else if (radFalse.IsChecked == true)
                {
                    question.answers.Add("false");
                }

                question.questionString = txtQuestion.Text;
                quiz.QuestionsList.Add(question);
                this.Hide();
                cq.Show();
            }
        }
    }
}
