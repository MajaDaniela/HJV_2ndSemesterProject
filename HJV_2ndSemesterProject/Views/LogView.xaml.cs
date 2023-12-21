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
        LogViewViewModel lvVM;
        Binding AllTaskBinding = new("Tasks");  //Used to switch the databinding for the TaskBox.
        Binding LogTaskBinding = new("SelectedLogEntry.Tasks"); //Used to switch the databinding for the TaskBox.
        public LogView(string MA_Number)
        {
            lvVM = new(MA_Number);
            InitializeComponent();
            DataContext = lvVM;
            AllTaskBinding.Source = lvVM;
            LogTaskBinding.Source = lvVM;
        }




        #region old
        //private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void SailingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void VesselName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void Waters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void WatersType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void StartTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void EndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void AddLogBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void UpdateLogBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void DeleteLogBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void ClearLogBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void SearchLogTxt_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //string x = SearchLogTxt.Text;



        //    ////SearchTask.Content = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //    //SqlCommand cmd = new SqlCommand("select * from SAILING where SailingType = " + "'" + x + "'", DataAccess.conn);
        //    //DataTable dt = new DataTable();
        //    //DataAccess.conn.Open();
        //    //SqlDataReader sdr = cmd.ExecuteReader();
        //    //dt.Load(sdr);
        //    //DataAccess.conn.Close();
        //    //datagrid1.ItemsSource = dt.DefaultView;
        //}
        //
        #endregion

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog dialog = new(lvVM.SelectedLogEntry.ToString()); //Dialog window to confirm delete
            if (dialog.ShowDialog() == true)
            {
                lvVM.DeleteLogEntry();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e) //Enables input to edit log entry
        {
            InputGrid.IsEnabled = true;
            TaskBox.SetBinding(ListBox.ItemsSourceProperty,AllTaskBinding); // Shows all tasks.
            Confirmationbtn.Visibility = Visibility.Visible;
        }

        private void Confirmationbtn_Click(object sender, RoutedEventArgs e) //confirms edit, then disables input boxes/ button.
        {
            try
            {
                lvVM.SelectedLogEntry.NumberofHours = double.Parse(HoursBox.Text);
                lvVM.UpdateLogEntry();
                InputGrid.IsEnabled = false;
                TaskBox.SetBinding(ListBox.ItemsSourceProperty, LogTaskBinding); //
                Confirmationbtn.Visibility = Visibility.Hidden;
            }
            catch
            {
                HoursBox.Text = "";
                HoursBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }


        private void TaskBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Collections.IEnumerable tasks = TaskBox.SelectedItems;
            lvVM.SelectedTasks = tasks.Cast<object>().ToList();
        }

        private void UserLogBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //Allows user to cancel edit by selecting a new log entry.
        {
            Confirmationbtn.Visibility = Visibility.Hidden;
            TaskBox.SetBinding(ListBox.ItemsSourceProperty, LogTaskBinding);
            InputGrid.IsEnabled = false;
        }


    }
}
