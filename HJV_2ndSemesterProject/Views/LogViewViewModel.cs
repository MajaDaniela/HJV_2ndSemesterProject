using HJV_2ndSemesterProject.Models;
using HJV_2ndSemesterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HJV_2ndSemesterProject.Views
{
     public class LogViewViewModel: INotifyPropertyChanged
    {
       private ObservableCollection<LogEntry> _userLogs;
        public ObservableCollection<LogEntry> UserLogs 
        {
            get { return _userLogs; }
            set {  _userLogs = value; OnPropertyChanged(nameof(UserLogs)); }
        }
        public string Hourstring { get; set; }
        
        private LogEntry _selectedLogEntry;
        public LogEntry SelectedLogEntry 
        {  
            get { return _selectedLogEntry; }
            set {  _selectedLogEntry= value; OnPropertyChanged(nameof(SelectedLogEntry)); }     
        }
        
        private LogEntryRepository LogRepo { get; set; } = new LogEntryRepository();

        public LogViewViewModel(string MA_Number) 
        {
            UserLogs = new(LogRepo.GetLogsByMA(MA_Number));

        }

        public void DeleteLogEntry () 
        {
            LogRepo.DeleteLogEntry(SelectedLogEntry.Id);
            UserLogs.Remove(SelectedLogEntry);
        }

        public void UpdateLogEntry()
        {
            LogRepo.UpdateLogEntry(SelectedLogEntry);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged (string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
