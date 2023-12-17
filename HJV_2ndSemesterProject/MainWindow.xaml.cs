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
using HJV_2ndSemesterProject.Models;
using System.Data.SqlClient;



namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainVM;
        private Volunteer volunteer;

        public MainWindow(string MA_Number)
        {
            InitializeComponent();
            mainVM = new(MA_Number);

            usernameLabel.Content = $"Velkommen, \n {mainVM.CurrentUser.MA_Number} \n {mainVM.CurrentUser.Name}"; 
        }
        private void ShowLogEntryPage()
        {
            MainFrame.Navigate(new LogEntryPage(mainVM.CurrentUser.MA_Number));
        }

        private void ShowProfilePage()
        {
            MainFrame.Navigate(new ProfilePage(mainVM));
        }

        private void GoToLoginWindow()
        {
            MainFrame.Navigate(new LoginWindow());
        }

        private void OpenLoginWindowAndCloseMainWindow()
        {
            // Create an instance of LoginWindow
            LoginWindow loginWindow = new LoginWindow();

            // Show LoginWindow
            loginWindow.Show();

            // Close the current MainWindow
            this.Close();
        }

       /*
       Funtions and methods..
        -----------------
       UI clicks..
        */
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            ShowLogEntryPage();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            ShowLogEntryPage();
        }

        private void DataMapBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            //
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowProfilePage();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginWindowAndCloseMainWindow();
        }
    }
}
