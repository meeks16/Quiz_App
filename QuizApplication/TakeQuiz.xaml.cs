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
using System.Collections.ObjectModel;

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for TakeQuiz.xaml
    /// </summary>
    public partial class TakeQuiz : Window
    {
        public Quiz quiz;
        public ObservableCollection<Question> missedQuestions;
        public StudentLogin student;
       
        public TakeQuiz()
        {
            InitializeComponent();
            missedQuestions = new ObservableCollection<Question>();
            lstAnswers.ItemsSource = missedQuestions;
        }

        public void checkQuestionType(Question question)
        {
            if (question.questionType == "Short Answer")
            {
                ansSA ansQuestion = new ansSA();
                ansQuestion.question = question;
                ansQuestion.quiz = quiz;
                ansQuestion.tQuiz = this;
                ansQuestion.lblQuestion.Content = question.questionString;
                ansQuestion.lblQuestionNum.Content = "Q." + question.questionNumber + " out of " + quiz.questionamount;
                double percentage = (double)(question.questionNumber - 1) / quiz.questionamount;
                ansQuestion.lblProgress.Content = (percentage).ToString("0.00%");
                ansQuestion.ShowDialog();
            }

            if (question.questionType == "Multiple Choice")
            {
                AnsMultQ ansQuestion = new AnsMultQ();
                ansQuestion.question = question;
                ansQuestion.quiz = quiz;
                ansQuestion.tQuiz = this;
                ansQuestion.lblQuestion.Content = question.questionString;
                ansQuestion.lblQuestionNum.Content = "Q." + question.questionNumber + " out of " + quiz.questionamount;
                double percentage = (double)(question.questionNumber - 1) / quiz.questionamount;
                ansQuestion.lblProgress.Content = (percentage).ToString("0.00%");
                ansQuestion.chkBox1.Content = question.answers[0];
                ansQuestion.chkBox2.Content = question.answers[1];
                ansQuestion.chkBox3.Content = question.answers[2];
                ansQuestion.chkBox4.Content = question.answers[3];
                ansQuestion.ShowDialog();
            }

            if (question.questionType == "True or False")
            {
                AnsTF ansQuestion = new AnsTF();
                ansQuestion.question = question;
                ansQuestion.quiz = quiz;
                ansQuestion.tQuiz = this;
                ansQuestion.lblQuestion.Content = question.questionString;
                ansQuestion.lblQuestionNum.Content = "Q." + question.questionNumber + " out of " + quiz.questionamount;
                double percentage = (double)(question.questionNumber - 1) / quiz.questionamount;
                ansQuestion.lblProgress.Content = (percentage).ToString("0.00%");
                
                ansQuestion.ShowDialog();
            }
        }

        public void submitQuiz(Quiz quiz)
        {
            QzSubmition qSubmit = new QzSubmition();
            qSubmit.tQuiz = this;

            double percentage = (double)(quiz.progCount) / quiz.progCount;
            qSubmit.lblPercent.Content = (percentage).ToString("0.00%");
            qSubmit.lblProg1.Content = quiz.progCount + " / " + quiz.questionamount;
            qSubmit.quiz = quiz;
            qSubmit.ShowDialog();
            
        }

        private void lstBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question question = (Question)lstBoxQuestions.SelectedItem;
        }

        private void btnStartQuiz_Click(object sender, RoutedEventArgs e)
        {
            Quiz quiz = new Quiz();
            quiz.progCount = 0;
            quiz.numCorrectAns = 0;
            quiz.QuestionsList = new ObservableCollection<Question>();
            this.Hide();
            for (int i = 0; i < lstBoxQuestions.Items.Count; i++)
            {   
                Question question = (Question)lstBoxQuestions.Items[i];
               
                string cAns = question.answers.ElementAt<string>(0);
                checkQuestionType(question);
                quiz.progCount++;
                quiz.questionamount++;
            }
            quiz.numCorrectAns = quiz.questionamount - this.missedQuestions.Count;
            submitQuiz(quiz);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            double percent = (double)(quiz.numCorrectAns) / quiz.questionamount;
           
            string fName = student.txtFirstName.Text;
            string lName = student.txtLastName.Text;
            string qName = quiz.name;
            string score = (percent).ToString("0.00%");
            student.quizzesTaken.Add(new StudenMember { QuizName = quiz.name, FirstName = fName, LastName = lName, Score = score });
            this.Hide();
            student.Show();
        }

    }
}
