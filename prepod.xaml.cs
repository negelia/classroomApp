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
using System.Data;
using System.Data.SqlClient;
using GoogleForms.DataSet1TableAdapters;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GoogleForms
{
    /// <summary>
    /// Логика взаимодействия для prepod.xaml
    /// </summary>
    public partial class prepod : Window
    {
        DataSet1 dataset;
        Test_testTableAdapter test_test;
        public int dolj = 1;
        public prepod()
        {
            InitializeComponent();
            dataset = new DataSet1();
            test_test = new Test_testTableAdapter();

            //view and filling tables
            test_test.Fill(dataset.Test_test);

            //adding objects to CB
            idNumber.ItemsSource = dataset.Test_test.DefaultView;
            idNumber.DisplayMemberPath = "ID_Voprosa";
            idNumber.SelectedValuePath = "Nomer_testa";
            idNumber.SelectedItem = 0;

            idVopros.ItemsSource = dataset.Test_test.DefaultView;
            idVopros.DisplayMemberPath = "ID_Voprosa";
            idVopros.SelectedValuePath = "ID_Voprosa";
            idVopros.SelectedItem = 0;

            DATA.ItemsSource = dataset.Test_test.DefaultView;
            DATA.SelectionMode = DataGridSelectionMode.Single;
            DATA.SelectedValuePath = "ID_Voprosa";
            DATA.CanUserAddRows = false;
            DATA.CanUserDeleteRows = false;
            DATA.IsReadOnly = true;
        }

        private void DATA_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!vopTB.Text.Equals("") && !otvTB.Text.Equals("") && !prepodTB.Text.Equals(""))
            {
                test_test.Insert(vopTB.Text,
                    otvTB.Text,
                    (int)idNumber.SelectedValue,
                    prepodTB.Text);
                test_test.Fill(dataset.Test_test);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!vopTB.Text.Equals("") && !otvTB.Text.Equals("") && !prepodTB.Text.Equals(""))
            {
                test_test.UpdateQuery(vopTB.Text,
                    otvTB.Text,
                    (int)idNumber.SelectedValue,
                    prepodTB.Text,
                    (int)idVopros.SelectedValue);
                test_test.Fill(dataset.Test_test);
            }
        }

        private void rez_Click(object sender, RoutedEventArgs e)
        {
            results mw = new results();
            mw.Show();
            this.Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)DATA.SelectedItem;

            if (dataRowView != null)
            {
                string proverka = dataRowView.Row.Field<String>("Prepod_fam");
                if (DATA.SelectedItem != null)
                {
                    test_test.DeleteQuery((int)DATA.SelectedValue);
                    test_test.Fill(dataset.Test_test);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DATA.Columns[0].Visibility = Visibility.Hidden;
            DATA.Columns[1].Header = "Вопрос";
            DATA.Columns[2].Header = "Ответ";
            DATA.Columns[3].Header = "Номер теста";
            DATA.Columns[4].Header = "Фамилия преподавателя";
            DATA.Columns[5].Visibility = Visibility.Hidden;
        }
    }
}
