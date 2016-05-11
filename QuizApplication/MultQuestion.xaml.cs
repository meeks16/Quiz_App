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
    /// Interaction logic for MultQuestion.xaml
    /// </summary>
    public partial class MultQuestion : Window
    {

        public Question question;
        public Quiz quiz;
        int checkboxnum = 1;
        public CreateQuestion cq;

        public MultQuestion()
        {
            InitializeComponent();
        }

        private void btnCheckbox_Click(object sender, RoutedEventArgs e)
        {
            if (txtCheckboxAnswers.Text == "")
            {
                lblError.Content = "Please enter a question";
            }
            else
            {
                if (checkboxnum == 4)
                {
                    chkAnswerFour.Content = txtCheckboxAnswers.Text;
                    question.answers.Add(txtCheckboxAnswers.Text);
                    lblError.Content = "";
                    btnCheckbox.IsEnabled = false;
                    txtCheckboxAnswers.Text = "";
                }
                else if (checkboxnum == 3)
                {
                    chkAnswerThree.Content = txtCheckboxAnswers.Text;
                    question.answers.Add(txtCheckboxAnswers.Text);
                    lblError.Content = "";
                    btnCheckbox.Content = "Checkbox Four";
                    lblAnswer.Content = "Please enter an answer for checkbox four";
                    txtCheckboxAnswers.Text = "";
                    checkboxnum = 4;
                }
                else if (checkboxnum == 2)
                {
                    chkAnswerTwo.Content = txtCheckboxAnswers.Text;
                    question.answers.Add(txtCheckboxAnswers.Text);
                    lblError.Content = "";
                    btnCheckbox.Content = "Checkbox Three";
                    lblAnswer.Content = "Please enter an answer for checkbox three";
                    txtCheckboxAnswers.Text = "";
                    checkboxnum = 3;
                }
                else
                {
                    chkAnswerOne.Content = txtCheckboxAnswers.Text;
                    question.answers.Add(txtCheckboxAnswers.Text);
                    lblError.Content = "";
                    btnCheckbox.Content = "Checkbox Two";
                    lblAnswer.Content = "Please enter an answer for checkbox two";
                    txtCheckboxAnswers.Text = "";
                    checkboxnum = 2;
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text == "")
            {
                lblError.Content = "Please enter a question";
            }
            else if (chkAnswerOne.IsChecked == false && chkAnswerTwo.IsChecked == false && chkAnswerThree.IsChecked == false && chkAnswerFour.IsChecked == false)
            {
                lblError.Content = "Select at least one answer";
            }
            else
            {
                if (chkAnswerOne.IsChecked == true)
                {
                    question.answerIndex.Add(1);
                }

                if (chkAnswerTwo.IsChecked == true)
                {
                    question.answerIndex.Add(2);
                }

                if (chkAnswerThree.IsChecked == true)
                {
                    question.answerIndex.Add(3);
                }

                if (chkAnswerFour.IsChecked == true)
                {
                    question.answerIndex.Add(4);
                }

                question.questionString = txtQuestion.Text;
                quiz.QuestionsList.Add(question);
                this.Hide();
                cq.Show();
            }
        }
    }
}
