using HJV_2ndSemesterProject.ViewModels;
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


namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;  // Assuming you have a Controller instance

        public MainWindow()
        {
            InitializeComponent();
            InitializeController();  // Call a method to initialize your Controller instance
        }

        private void InitializeController()
        {
            // Replace the arguments with your actual database connection details
            controller = new Controller("your_server", "your_database", "your_username", "your_password");
        }

        private void ShowLogEntryPage()
        {
            // Pass the LogEntryRepo instance to the LogEntryPage constructor
            LogEntryRepo logEntryRepo = new LogEntryRepo(controller);
            LogEntryPage logEntryPage = new LogEntryPage(logEntryRepo);

            // Navigate to the LogEntryPage
            MainFrame.Navigate(logEntryPage);
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control LogEntryPage
            ShowLogEntryPage();
        }
    }
}
