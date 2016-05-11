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
    /// Interaction logic for SAQuestion.xaml
    /// </summary>
    public partial class SAQuestion : Window
    {
        public Question question;
        public Quiz quiz;
        public CreateQuestion cq;

        public SAQuestion()
        {
            InitializeComponent();
        }

        private void btnSubmitQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text == "" || txtAnswer.Text == "")
            {
                lblError.Content = "Question or answer field empty";
            }
            else
            {
                question.questionString = txtQuestion.Text;
                question.answers.Add(txtAnswer.Text);
                quiz.QuestionsList.Add(question);
                this.Hide();
                cq.Show();
            }
        }
    }
}
