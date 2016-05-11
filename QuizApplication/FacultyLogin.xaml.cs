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
    /// Interaction logic for FacultyLogin.xaml
    /// </summary>
    public partial class FacultyLogin : Window
    {
        public FacultyLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "password")
            {
                CreateQuiz createquiz = new CreateQuiz();
                createquiz.Show();
                this.Hide();
            }
            else
            {
                lblError.Content = "Invalid username or password";
            }
        }
    }
}
