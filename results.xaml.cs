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
using System.Data;
using GoogleForms.DataSet1TableAdapters;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace GoogleForms
{
    /// <summary>
    /// Логика взаимодействия для results.xaml
    /// </summary>
    public partial class results : Window
    {
        public string prepod;
        DataSet1 dataSet;
        Prohojdenie_testaTableAdapter prohojdenie;
        Test_testTableAdapter test;
        solvedTestTableAdapter solved;
        public results()
        {
            InitializeComponent();
            dataSet = new DataSet1();
            prohojdenie = new Prohojdenie_testaTableAdapter();
            test = new Test_testTableAdapter();
            solved = new solvedTestTableAdapter();

            prohojdenie.Fill(dataSet.Prohojdenie_testa);
            test.Fill(dataSet.Test_test);
            solved.Fill(dataSet.solvedTest);

            DATA.ItemsSource = dataSet.solvedTest.DefaultView;
            DATA.SelectionMode = DataGridSelectionMode.Single;
            DATA.SelectedValuePath = "Nomer_testa";
            DATA.CanUserAddRows = false;
            DATA.CanUserDeleteRows = false;
            DATA.IsReadOnly = true;
        }


        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DATA.Columns[0].Visibility = Visibility.Hidden;
            DATA.Columns[1].Visibility = Visibility.Hidden;
        }
    }
}
