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
            StartDatePicker.SelectedDate = DateTime.Today;
            EndDatePicker.SelectedDate = DateTime.Today;
            DataContext = logEntryVM;

            for(int i = 0; i<23; i++)
            {
                StartHour.Items.Add((i+1).ToString("D2"));
                EndHour.Items.Add((i+1).ToString("D2"));

                if (StartMinute.Items.Count <6) 
                {
                    StartMinute.Items.Add(i*10);
                    EndMinute.Items.Add(i * 10);
                }
            }
        }

        #region Maja
        //string SailingTypeString;
        //string VesselString;
        //string WatersString;
        //string WatersTypeString;
        //DateTime StartDate_date;
        //DateTime EndDate_date;
        //string HourString;
        //string MinutString;
        //string HourStringEnd;
        //string MinutStringEnd;
        //string RoleString;
        //public LogEntryPage()
        //{
        //    InitializeComponent();
        //    //StartTime.Format = DateTimePickerFormat.Custom;
        //    //StartTime.CustomFormat = "MM/dd/yyyy hh:mm:ss";

        //    //StartTime = new DatePicker();
        //    //StartTime.SelectedDateFormat = DatePickerFormat.;
        //    //timePicker.ShowUpDown = true;

        //    var WatersListNames = new List<string>()
        //            {
        //                //"Brandrulle", "Havarirulle", "Bjærgningsrulle", "Intern SAR-øvelse", "Intern miljø-øvelse", "Investigering af andet skib",
        //                "Als Sund", "Bornholmsgat", "Bælthavet", "Farvandet nord for Fyn", "Farvandet syd for Fyn"
        //            };

        //    foreach (var name in WatersListNames)
        //    {
        //        WatersList.Items.Add(new ListBoxItem() { Content = name });
        //    }

        //    var TaskNames = new List<string>()
        //    {
        //        "Brandrulle", "Havarirulle", "Bjærgningsrulle", "Intern SAR-øvelse", "Intern miljø-øvelse", "Investigering af andet skib",
        //    };

        //    foreach (var name in TaskNames)
        //    {
        //        TaskList.Items.Add(new ListBoxItem() { Content = name });
        //    }

        //    for (int i = 00; i < 400; i++)
        //    {
        //        //LogHours.Items.Add(new ComboBoxItem() { Content = i });
        //        HourEnd.Items.Add(new ComboBoxItem() { Content = i });
        //    }

        //    for (int i = 00; i<24; i++)
        //    {
        //        Hour.Items.Add(new ComboBoxItem() { Content = i });
        //    }
        //    for (int i = 00; i < 60; i+=10)
        //    {
        //        Minut.Items.Add(new ComboBoxItem() { Content = i });
        //        MinutEnd.Items.Add(new ComboBoxItem() { Content = i });
        //        //LogMinutes.Items.Add(new ComboBoxItem() { Content = i });
        //    }


        //    var RoleNames = new List<string>()
        //            {
        //                "Motorpasser", "FARF",
        //            };

        //    foreach (var name in RoleNames)
        //    {
        //        //Role.Items.Add(new ComboBoxItem() { Content = name });
        //    }


        //    //var TaskNames = new List<string>()
        //    //        {
        //    //            "Brandrulle", "Havarirulle",
        //    //        };

        //    //foreach (var name in TaskNames)
        //    //{
        //    //    Task.Items.Add(new ComboBoxItem() { Content = name });
        //    //}


        //    var SailingTypeNames = new List<string>()
        //            {
        //                "Forlægningssejllads", "MAS", "Patruljesejlads", "SAR", "SAREX",                
        //            };

        //    foreach (var name in SailingTypeNames)
        //    {
        //        //SailingType.Items.Add(new ComboBoxItem() { Content = name });
        //    }

        //    var WatersTypeNames = new List<string>()
        //            {
        //                "Bugt", "Fjord", "Stræde", "Sund",
        //            };

        //    foreach (var name in WatersTypeNames)
        //    {
        //        WatersType.Items.Add(new ComboBoxItem() { Content = name });
        //    }




        //    //var WatersNames = new List<string>()
        //    //        {
        //    //            "Als Sund", "Bornholmsgat", "Bælthavet", "Farvandet nord for Fyn", "Farvandet syd for Fyn"
        //    //        };

        //    //foreach (var name in WatersNames)
        //    //{
        //    //    Waters.Items.Add(new ComboBoxItem() { Content = name });
        //    //}

        //    var VesselNames = new List<string>()
        //            {
        //                "MHV 807", "MHV 808", "MHV 809", "MHV 810", "MHV 811"
        //            };

        //    foreach (var name in VesselNames)
        //    {
        //        VesselName.Items.Add(new ComboBoxItem() { Content = name });               
        //    }
        //}

        //private void Waters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //WatersString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void VesselName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //VesselString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void SailingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //SailingTypeString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();


        //}

        //private void StartTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //   // StartDate_date = (DateTime)StartTime.SelectedDate;
        //    //DateTime EndDate_date;
        //    //DateTime myDate = StartTime.DisplayDate.Date +
        //    //        StartTime.DisplayDate.TimeOfDay;
        //    //Debug.WriteLine(StartTime.DisplayDate.Day);
        //    //Debug.WriteLine(StartTime.DisplayDate.TimeOfDay);
        //}

        //private void AddLogBtn_Click(object sender, RoutedEventArgs e)
        //{
        ////    TimeSpan end = new TimeSpan(int.Parse(HourStringEnd), int.Parse(MinutStringEnd), 0);
        ////    EndDate_date = EndDate_date.Date + end;

        ////    TimeSpan start = new TimeSpan(int.Parse(HourString), int.Parse(MinutString), 0);
        ////    StartDate_date = StartDate_date.Date + start;

        ////    Sailing currentSailing = new Sailing(StartDate_date, EndDate_date, (SailingType)1, VesselString);
        ////    Debug.WriteLine($"{currentSailing.StartTime}, {currentSailing.EndTime},{currentSailing.SailingType},{currentSailing.VesselID}");

        //}

        //private void WatersType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //WatersTypeString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void EndTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //EndDate_date = (DateTime)EndTime.SelectedDate;
        //}

        //private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //RoleString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void Hour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //HourString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void Minut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //MinutString = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}
        //private void HourEnd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //   // HourStringEnd = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void MinutEnd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //   // MinutStringEnd = ((ComboBoxItem)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString();
        //}

        //private void Task_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void WatersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void LogHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void LogMinutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void LogTime_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
        #endregion

        private void VesselPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = VesselPicker.SelectedItem.ToString().Split(' ');
            logEntryVM.VesselID = parts[0] + "" + parts[1];
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
           string temp = HourNumberBox.Text.Replace(',', '.');
            try
            {
                logEntryVM.NumberofHours = double.Parse(temp);
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
            try
            {
                logEntryVM.AddLogEntry();

            }
            catch
            {
                MessageBox.Show("Udfyld venligst alle feter.");
            }
        }
    }
}
