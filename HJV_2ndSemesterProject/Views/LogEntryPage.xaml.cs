using HJV_2ndSemesterProject.Models;
using HJV_2ndSemesterProject.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Xml.Linq;

namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for LogEntryPage.xaml
    /// </summary>
    public partial class LogEntryPage : UserControl
    {
        LogEntryViewModel logEntryVM;

        public LogEntryPage(string MA_Number)
        {
            logEntryVM = new(MA_Number);
            InitializeComponent();
            StartDatePicker.SelectedDate = DateTime.Today; //Default value for datepicker is the current day.
            EndDatePicker.SelectedDate = DateTime.Today;
            DataContext = logEntryVM;

            //Fills in the values of the Hour and Minute Comboboxes. Each Hour of the day and every ten minutes.
            for(int i = 0; i<24; i++)
            {
                StartHour.Items.Add((i).ToString("D2"));
                EndHour.Items.Add((i).ToString("D2"));

                if (StartMinute.Items.Count <6) 
                {
                    StartMinute.Items.Add((i*10).ToString("D2"));
                    EndMinute.Items.Add((i*10).ToString("D2"));
                }
            }
        }

       
        //  The following Events Update the ViewModel, when the user selects an item in the UI.
        private void VesselPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = VesselPicker.SelectedItem.ToString().Split(' ');
            logEntryVM.VesselID = parts[0] + " " + parts[1];
        }

        private void TypePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.SailingType = (SailingType)TypePicker.SelectedIndex;
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.StartTimes[0] = StartDatePicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.EndTimes[0] = EndDatePicker.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void StartHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.StartTimes[1] = StartHour.SelectedItem.ToString();
        }

        private void StartMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.StartTimes[2] = StartMinute.SelectedItem.ToString();
        }

        private void EndMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.EndTimes[2] = EndMinute.SelectedItem.ToString();
        }

        private void EndHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.EndTimes[1] = EndHour.SelectedItem.ToString();
        }

        private void WatersPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.SelectedWaters.Clear();
            foreach (object o in WatersPicker.SelectedItems)
            {
                logEntryVM.SelectedWaters.Add((Waters)o);
            }
        }

        private void RolePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.Role = (Role)RolePicker.SelectedIndex;
        }

        private void HourNumberBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Checks for incorrect input.
            try
            {
                logEntryVM.NumberofHours = double.Parse(HourNumberBox.Text);
            }
            catch
            {
                HourNumberBox.Text = "";
                HourNumberBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void TaskPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            logEntryVM.SelectedTasks.Clear();
            foreach (object o in TaskPicker.SelectedItems)
            {
                logEntryVM.SelectedTasks.Add((Models.Task) o);
            }
        }


        private void LogEntrybtn_Click(object sender, RoutedEventArgs e)
        { 
            //Creates a new log entry if all required fields have an input- otherwise display error message.
            try
            {
                logEntryVM.AddLogEntry();
                LogEntrybtn.Content = "Logget";
                LogEntrybtn.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Udfyld venligst alle påkrævede felter.");
            }
        }

        private void HourNumberBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HourNumberBox.Clear();
        }
    }
}
