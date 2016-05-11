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

    public partial class QzSubmition : Window
    {
        public Quiz quiz;
        public TakeQuiz tQuiz;
       

        public QzSubmition()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            double percent = (double)(quiz.numCorrectAns) / quiz.questionamount;
            tQuiz.lblScore.Content = (percent).ToString("0.00%");
            this.Hide();
            tQuiz.Show();
        }
    }
}
