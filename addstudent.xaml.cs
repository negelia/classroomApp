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

namespace GoogleForms
{
    /// <summary>
    /// Логика взаимодействия для addstudent.xaml
    /// </summary>
    public partial class addstudent : Window
    {
        DataSet1 dataset;
        StudentsTableAdapter students;
        GroupTableAdapter group;
        Students_predstavlenieTableAdapter students_predstavlenie;
        public addstudent()
        {
            InitializeComponent();

            dataset = new DataSet1();
            students = new StudentsTableAdapter();
            group = new GroupTableAdapter();
            students_predstavlenie = new Students_predstavlenieTableAdapter();

            //view and filling tables
            students.Fill(dataset.Students);
            group.Fill(dataset.Group);
            students_predstavlenie.Fill(dataset.Students_predstavlenie);

            //adding objects to CB
            idDolj.ItemsSource = dataset.Students.DefaultView;
            idDolj.DisplayMemberPath = "doljnost_id";
            idDolj.SelectedValuePath = "doljnost_id";
            idDolj.SelectedItem = 0;

            idGroup.ItemsSource = dataset.Students.DefaultView;
            idGroup.DisplayMemberPath = "Grupa_id";
            idGroup.SelectedValuePath = "Grupa_id";
            idGroup.SelectedItem = 0;

            idStudent.ItemsSource = dataset.Students.DefaultView;
            idStudent.DisplayMemberPath = "ID_Studenta";
            idStudent.SelectedValuePath = "ID_Studenta";
            idStudent.SelectedItem = 0;

            DATA.ItemsSource = dataset.Students_predstavlenie.DefaultView;
            DATA.SelectionMode = DataGridSelectionMode.Single;
            DATA.SelectedValuePath = "ID_Studenta";
            DATA.CanUserAddRows = false;
            DATA.CanUserDeleteRows = false;
            DATA.IsReadOnly = true;
        }

        private void famTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!imayTB.Text.Equals("") && !famTB.Text.Equals("") && !loginTB.Text.Equals("") && !passTB.Text.Equals("") && !otchTB.Text.Equals("")
                )
            {
                students.Insert(imayTB.Text,
                    famTB.Text,
                    otchTB.Text,
                    (int)idGroup.SelectedValue,
                    loginTB.Text,
                    passTB.Text,
                    (int)idDolj.SelectedValue);
                students_predstavlenie.Fill(dataset.Students_predstavlenie);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!imayTB.Text.Equals("") && !famTB.Text.Equals("") && !loginTB.Text.Equals("") && !passTB.Text.Equals("") && !otchTB.Text.Equals("")
                )
            {
                students.UpdateQuery(imayTB.Text,
                    famTB.Text,
                    otchTB.Text,
                    (int)idGroup.SelectedValue,
                    loginTB.Text,
                    passTB.Text,
                    (int)idDolj.SelectedValue,
                    (int)idStudent.SelectedValue);
                students_predstavlenie.Fill(dataset.Students_predstavlenie);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DATA.SelectedItem != null)
            {
                students.DeleteQuery((int)DATA.SelectedValue);
                students_predstavlenie.Fill(dataset.Students_predstavlenie);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DATA.Columns[0].Visibility = Visibility.Hidden;
            DATA.Columns[1].Header = "Имя";
            DATA.Columns[2].Header = "Фамилия";
            DATA.Columns[3].Header = "Отчество";
            DATA.Columns[4].Header = "Логин";
            DATA.Columns[5].Header = "Пароль";
            DATA.Columns[6].Header = "Группа";
            DATA.Columns[7].Visibility = Visibility.Hidden;
        }
        private void DATA_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)DATA.SelectedItem;

            if (dataRowView != null)
            {
                imayTB.Text = dataRowView.Row.Field<String>("Imya_studenta");
                famTB.Text = dataRowView.Row.Field<String>("Familia_students");
                otchTB.Text = dataRowView.Row.Field<String>("Otchestvo_studenta");
                loginTB.Text = dataRowView.Row.Field<String>("Login_studenta");
                passTB.Text = dataRowView.Row.Field<String>("Pass_studenta");
                idGroup.SelectedValue = dataRowView.Row.Field<int>("Grupa_id");
            }
        }
    }
}
