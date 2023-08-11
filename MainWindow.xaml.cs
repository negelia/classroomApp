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
using GoogleForms.DataSet1TableAdapters;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace GoogleForms
{
    public partial class MainWindow : Window
    {
        SqlConnectionStringBuilder stringBuilder;
        DataSet1 dataSet;
        PrepodavatelTableAdapter prepodavatel;
        Students_predstavlenieTableAdapter student;
        public int it;
        public int it2;

        public MainWindow()
        {
            InitializeComponent();
            stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.ConnectionString = Properties.Settings.Default.googleformsConnectionString;
            dataSet = new DataSet1();
            prepodavatel = new PrepodavatelTableAdapter();
            student = new Students_predstavlenieTableAdapter();

            prepodavatel.Fill(dataSet.Prepodavatel);
            student.Fill(dataSet.Students_predstavlenie);

            DATA2.ItemsSource = dataSet.Prepodavatel.DefaultView;
            DATA2.SelectionMode = DataGridSelectionMode.Single;
            DATA2.SelectedValuePath = "ID_Prepoda";
            DATA2.CanUserAddRows = false;
            DATA2.CanUserDeleteRows = false;
            DATA2.IsReadOnly = true;

            DATA3.ItemsSource = dataSet.Students_predstavlenie.DefaultView;
            DATA3.SelectionMode = DataGridSelectionMode.Single;
            DATA3.SelectedValuePath = "ID_Studenta";
            DATA3.CanUserAddRows = false;
            DATA3.CanUserDeleteRows = false;
            DATA3.IsReadOnly = true;
        }

        private void vhodBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text == "ADMIN" && passTB.Text == "admin")
            {
                admin ad = new admin();
                ad.Show();
                this.Close();
            }

            it = 0;
            for (int i = 0; i < DATA3.Items.Count; i++)
            {
                DataRowView dataRowView = (DataRowView)DATA3.Items[index: i];
                string log = dataRowView.Row.Field<String>("Login_studenta");
                string pass = dataRowView.Row.Field<String>("Pass_studenta");
                string fam = dataRowView.Row.Field<String>("Familia_students");
                if (loginTB.Text == log && passTB.Text == pass)
                {
                    student st = new student();
                    st.Show();
                    this.Close();
                }
                if (loginTB.Text != log)
                {
                    it = it + 1;
                }
            }

            it2 = 0;
            for (int i = 0; i < DATA2.Items.Count; i++)
            {
                DataRowView dataRowView2 = (DataRowView)DATA2.Items[index: i];
                if (dataRowView2 != null)
                {
                    string log1 = dataRowView2.Row.Field<String>("Login_prepoda");
                    string pass1 = dataRowView2.Row.Field<String>("Pass_prepoda");
                    string fam1 = dataRowView2.Row.Field<String>("Familia_prepoda");
                    if (loginTB.Text == log1 && passTB.Text == pass1)
                    {
                        prepod pr = new prepod();
                        pr.Show();
                        this.Close();
                    }
                    if (loginTB.Text != log1)
                    {
                        it2 = it2 + 1;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stringBuilder.IntegratedSecurity = true;
            var config = ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var conStrSect = (ConnectionStringsSection)config.GetSection("connectionStrings");
            conStrSect.ConnectionStrings["GoogleForms.Properties.Settings.googleformsConnectionString"].ConnectionString = stringBuilder.ConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Application.Current.Shutdown();
        }

        private void vhodBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
