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

namespace GoogleForms
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
        }

        private void prepod_Click(object sender, RoutedEventArgs e)
        {
            addprepod addprepod = new addprepod();
            addprepod.Show();
            this.Close();
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            addstudent addstudent = new addstudent();
            addstudent.Show();
            this.Close();
        }
    }
}
