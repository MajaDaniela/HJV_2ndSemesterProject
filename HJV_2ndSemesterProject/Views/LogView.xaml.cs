using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SailingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VesselName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Waters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WatersType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StartTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddLogBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateLogBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteLogBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearLogBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchLogTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string x = SearchLogTxt.Text;



            ////SearchTask.Content = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
            //SqlCommand cmd = new SqlCommand("select * from SAILING where SailingType = " + "'" + x + "'", DataAccess.conn);
            //DataTable dt = new DataTable();
            //DataAccess.conn.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();
            //dt.Load(sdr);
            //DataAccess.conn.Close();
            //datagrid1.ItemsSource = dt.DefaultView;
        }
    }
}
