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
    /// Логика взаимодействия для student.xaml
    /// </summary>
    public partial class student : Window
    {
        DataSet1 dataset;
        Test_testTableAdapter test_test;
        Prohojdenie_testaTableAdapter prohojdenie;
        solvedTestTableAdapter solved;
        public student()
        {
            InitializeComponent();
            dataset = new DataSet1();
            test_test = new Test_testTableAdapter();
            prohojdenie = new Prohojdenie_testaTableAdapter();
            solved = new solvedTestTableAdapter();

            //view and filling tables
            test_test.Fill(dataset.Test_test);
            prohojdenie.Fill(dataset.Prohojdenie_testa);
            solved.Fill(dataset.solvedTest);

            //adding objects to CB
            idNumber.ItemsSource = dataset.Test_test.DefaultView;
            idNumber.DisplayMemberPath = "ID_Voprosa";
            idNumber.SelectedValuePath = "Nomer_testa";
            idNumber.SelectedItem = 0;

            test.ItemsSource = dataset.Test_test.DefaultView;
            test.DisplayMemberPath = "ID_Voprosa";
            test.SelectedValuePath = "ID_Voprosa";
            test.SelectedItem = 0;

            DATA.ItemsSource = dataset.solvedTest.DefaultView;
            DATA.SelectionMode = DataGridSelectionMode.Single;
            DATA.SelectedValuePath = "ID_Voprosa";
            DATA.CanUserAddRows = false;
            DATA.CanUserDeleteRows = false;
            DATA.IsReadOnly = true;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!vopTB.Text.Equals("") && !otvTB.Text.Equals("") && !prepod.Text.Equals("") && !student1.Text.Equals(""))
            {
                test_test.Insert(vopTB.Text,
                    PravotvTB.Text,
                    (int)idNumber.SelectedValue,
                    prepod.Text);

                prohojdenie.Insert(student1.Text,
                    (int)test.SelectedValue,
                    otvTB.Text
                    );

                solved.Fill(dataset.solvedTest);

            }
        }

        private void otvTB_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DATA_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)DATA.SelectedItem;
            
            if (dataRowView != null)
            {
                student1.Text = dataRowView.Row.Field<String>("Фамилия студента");
                otvTB.Text = dataRowView.Row.Field<String>("Ответ студента");
                idNumber.SelectedValue = dataRowView.Row.Field<int>("Номер теста");
                test.SelectedValue = dataRowView.Row.Field<int>("ID_Voprosa");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DATA.Columns[0].Visibility = Visibility.Hidden;
            DATA.Columns[1].Visibility = Visibility.Hidden;
        }
    }
}
