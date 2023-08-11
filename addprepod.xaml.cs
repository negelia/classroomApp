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
    /// Логика взаимодействия для addprepod.xaml
    /// </summary>
    public partial class addprepod : Window
    {
        DataSet1 dataset;
        PrepodavatelTableAdapter prepodavatel;
        //public int dolj = 1;
        public addprepod()
        {
            InitializeComponent();
            dataset = new DataSet1();
            prepodavatel = new PrepodavatelTableAdapter();

            //view and filling tables
            prepodavatel.Fill(dataset.Prepodavatel);

            //adding objects to CB
            idPrepod.ItemsSource = dataset.Prepodavatel.DefaultView;
            idPrepod.DisplayMemberPath = "ID_Prepoda";
            idPrepod.SelectedValuePath = "ID_Prepoda";
            idPrepod.SelectedItem = 0;

            idDolj.ItemsSource = dataset.Prepodavatel.DefaultView;
            idDolj.DisplayMemberPath = "doljnost_id";
            idDolj.SelectedValuePath = "doljnost_id";
            idDolj.SelectedItem = 0;

            DATA.ItemsSource = dataset.Prepodavatel.DefaultView;
            DATA.SelectionMode = DataGridSelectionMode.Single;
            DATA.SelectedValuePath = "ID_Prepoda";
            DATA.CanUserAddRows = false;
            DATA.CanUserDeleteRows = false;
            DATA.IsReadOnly = true;
        }

        private void famTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!imayTB.Text.Equals("") && !famTB.Text.Equals("") && !loginTB.Text.Equals("") && !passTB.Text.Equals("") && !otchTB.Text.Equals(""))
            {
                prepodavatel.Insert(imayTB.Text,
                    famTB.Text,
                    otchTB.Text,
                    loginTB.Text,
                    passTB.Text,
                    (int)idDolj.SelectedValue);
                prepodavatel.Fill(dataset.Prepodavatel);
            }


        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!imayTB.Text.Equals("") && !famTB.Text.Equals("") && !loginTB.Text.Equals("") && !passTB.Text.Equals("") && !otchTB.Text.Equals(""))
            {
                prepodavatel.UpdateQuery(imayTB.Text,
                    famTB.Text,
                    otchTB.Text,
                    loginTB.Text,
                    passTB.Text,
                    (int)idDolj.SelectedValue,
                    (int)idPrepod.SelectedValue);
                prepodavatel.Fill(dataset.Prepodavatel);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DATA.SelectedItem != null)
            {
                prepodavatel.DeleteQuery((int)DATA.SelectedValue);
                prepodavatel.Fill(dataset.Prepodavatel);
            }
        }
        private void DATA_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)DATA.SelectedItem;

            if (dataRowView != null)
            {
                imayTB.Text = dataRowView.Row.Field<String>("Imya_prepoda");
                famTB.Text = dataRowView.Row.Field<String>("Familia_prepoda");
                otchTB.Text = dataRowView.Row.Field<String>("Otchestvo_prepoda");
                loginTB.Text = dataRowView.Row.Field<String>("Login_prepoda");
                passTB.Text = dataRowView.Row.Field<String>("Pass_prepoda");

                idPrepod.SelectedValue = dataRowView.Row.Field<int>("ID_Prepoda");
                idDolj.SelectedValue = dataRowView.Row.Field<int>("doljnost_id");
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
            DATA.Columns[6].Visibility = Visibility.Hidden;
        }
    }
}
