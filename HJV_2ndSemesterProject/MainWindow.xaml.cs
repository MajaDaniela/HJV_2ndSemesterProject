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
using HJV_2ndSemesterProject.Views; 


namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowLogEntryPage()
        {
            MainFrame.Navigate(new LogEntryPage());
        }

        private void ShowProfilePage()
        {
            MainFrame.Navigate(new ProfilePage());
        }




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

        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            // Skift til User Control ProfilePage
            MainFrame.Navigate (new ProfilePage());
        }
    }
}
