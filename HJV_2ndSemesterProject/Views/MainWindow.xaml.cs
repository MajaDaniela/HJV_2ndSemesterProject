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



namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainVM;

        public MainWindow(string MA_Number)
        {
            InitializeComponent();
            mainVM = new(MA_Number);

            usernameLabel.Content = $"Velkommen, \n {mainVM.CurrentUser.MA_Number} \n {mainVM.CurrentUser.Name}";
            ShowLogEntryPage();
            //This will start the program showing the LogEntryPage.
        }

        //The following methods navigate between the different UserControls.
        private void ShowLogEntryPage()
        {
            MainFrame.Navigate(new LogEntryPage(mainVM.CurrentUser.MA_Number));
        }

        private void ShowProfilePage()
        {
            MainFrame.Navigate(new ProfilePage(mainVM.CurrentUser.MA_Number));
        }
        private void ShowLogViewPage()
        {
            MainFrame.Navigate(new LogView(mainVM.CurrentUser.MA_Number));
        }

        //returns to LoginPage.
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
       UI Button clicks..
        */

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowLogEntryPage();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowProfilePage();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginWindowAndCloseMainWindow();
        }

        private void LogViewBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowLogViewPage();
        }
    }
}
