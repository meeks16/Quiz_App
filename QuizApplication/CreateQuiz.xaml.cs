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
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Window
    {
        public ObservableCollection<Quiz> Quizzes;

        public CreateQuiz()
        {
            InitializeComponent();
            Quizzes = new ObservableCollection<Quiz>();
            lstCreatedQuizzes.ItemsSource = Quizzes;
        }

        private void btnCreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuizName.Text != "")
            {
                Quiz quiz = new Quiz { name = txtQuizName.Text, questionamount = 0 };
                Quizzes.Add(quiz);
                CreateQuestion createquestions = new CreateQuestion();
                createquestions.cq = this;
                createquestions.quiz = new Quiz();
                createquestions.quiz = quiz;
                createquestions.quiz.QuestionsList = new ObservableCollection<Question>();
                createquestions.lblQuizName.Content = ("Quiz Name: " + quiz.name);
                createquestions.lblQuestionNumber.Content = quiz.questionamount;
                this.Hide();
                createquestions.Show();
            }

            if (Quizzes.Count >= 3)
            {
                btnCreateQuiz.IsEnabled = false;
            }
        }

        private void btnDeleteQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (lstCreatedQuizzes.SelectedIndex >= 0)
            {
                int removeIndex = lstCreatedQuizzes.SelectedIndex;
                Quizzes.RemoveAt(removeIndex);
            }

            if (Quizzes.Count < 3)
            {
                btnCreateQuiz.IsEnabled = true;
            }
        }

        //Michael
        private void btnUserSelect_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin student = new StudentLogin();
            student.Show();
            student.faculty = this;
            student.availableQuizzes = new ObservableCollection<Quiz>();
            student.availableQuizzes = Quizzes;
            student.DataContext = student.availableQuizzes;
            student.comboBoxQuiz.ItemsSource = student.availableQuizzes;
            //customer.txtblock.Text = "Modified String";
            //this.Hide();this.Hide();
            student.faculty = this;
            this.Hide();
        }

        private void btnViewQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (lstCreatedQuizzes.SelectedIndex >= 0)
            {
                EditQuiz editquiz = new EditQuiz();
                editquiz.quiz = new Quiz();
                editquiz.quiz = (Quiz)lstCreatedQuizzes.SelectedItem;
                editquiz.lstQuestions.ItemsSource = editquiz.quiz.QuestionsList;
                editquiz.cq = this;
                this.Hide();
                editquiz.Show();
            }
        }
    }
}
