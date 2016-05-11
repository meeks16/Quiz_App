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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace QuizApplication
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<Quiz> Quizzes;

        public MainWindow()
        {
            InitializeComponent();
            //Quizzes = new ObservableCollection<Quiz>();
            //Quiz quiz = new Quiz { name = "math", questionamount = 0 };
        }

        private void btnFaculty_Click(object sender, RoutedEventArgs e)
        {
            FacultyLogin facultylogin = new FacultyLogin();
            //facultylogin.Quizzes = new ObservableCollection<Quiz>();
           // facultylogin.Quizzes = Quizzes;
            facultylogin.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin studentlogin = new StudentLogin();
            //studentlogin.availableQuizzes = new ObservableCollection<Quiz>();
            //studentlogin.availableQuizzes = Quizzes;
            studentlogin.Show();
            this.Hide();
        }
    }
}
