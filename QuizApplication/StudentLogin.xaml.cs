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
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window
    {
        public ObservableCollection<Quiz> availableQuizzes;
        public ObservableCollection<StudenMember> quizzesTaken;
        public CreateQuiz faculty;

        public StudentLogin()
        {
            InitializeComponent();
            quizSelectionLbl.Visibility = System.Windows.Visibility.Hidden;
            comboBoxQuiz.Visibility = System.Windows.Visibility.Hidden;
            btnTakeQuiz.Visibility = System.Windows.Visibility.Hidden;
            lblNoQuizes.Visibility = System.Windows.Visibility.Hidden;
            btnCreateQuiz.Visibility = System.Windows.Visibility.Hidden;
            quizzesTaken = new ObservableCollection<StudenMember>();
            lstQuizzesTaken.ItemsSource = quizzesTaken;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != null && txtLastName.Text != null)
            {
                quizSelectionLbl.Visibility = System.Windows.Visibility.Visible;
                comboBoxQuiz.Visibility = System.Windows.Visibility.Visible;
                btnTakeQuiz.Visibility = System.Windows.Visibility.Visible;
                lblNoQuizes.Visibility = System.Windows.Visibility.Visible;
                btnCreateQuiz.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btnTakeQuiz_Click(object sender, RoutedEventArgs e)
        {

            if (comboBoxQuiz.SelectedIndex >= 0)
            {                
                TakeQuiz takeQuiz = new TakeQuiz();
                takeQuiz.quiz = new Quiz();
                takeQuiz.student = this;
                takeQuiz.lblFirstName.Content = txtFirstName.Text;
                takeQuiz.lblLastName.Content = txtLastName.Text;
                takeQuiz.quiz = (Quiz)comboBoxQuiz.SelectedItem;
                takeQuiz.quiz.numCorrectAns = 0;
                takeQuiz.lblQuizName.Content = takeQuiz.quiz.name;
                takeQuiz.lstBoxQuestions.ItemsSource = takeQuiz.quiz.QuestionsList;
                takeQuiz.Show();
                
            }
        }

        private void btnCreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            faculty.Show();
            this.Hide();
        }

    }
}
