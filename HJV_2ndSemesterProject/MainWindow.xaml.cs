using HJV_2ndSemesterProject.Views;
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
using HJV_2ndSemesterProject.ViewModels;
using System.Data.SqlClient;



namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new();
        }
        private void ShowLogEntryPage()
        {
            MainFrame.Navigate(new LogEntryPage());
        }

        private void ShowProfilePage()
        {
            MainFrame.Navigate(new ProfilePage());
        }

        private void ShowLogInPage()
        {  
            MainFrame.Navigate(new LogInPage());
        }

        //private void ConnectToDbBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    string serverIp = "10.56.8.36";
        //    string serverName = "DB_F23_TEAM_14";
        //    string username = DatabaseTb.Text;
        //    string password = DatabasePswdTb.Password;

        //    string connectionString = $"Data Source={serverIp};Initial Catalog={serverName};User Id={username};Password={password};";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // Nu kan du udføre SQL-forespørgsler eller andre operationer

        //            MessageBox.Show("Forbindelse oprettet!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Fejl under oprettelse af forbindelse: {ex.Message}");
        //    }
        //}


        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            ShowLogInPage();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            ShowLogEntryPage();
        }

        
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
           //ShowLogInPage();
        }
        private void DataMapBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            //ShowLogInPage();
        }
    }
}
