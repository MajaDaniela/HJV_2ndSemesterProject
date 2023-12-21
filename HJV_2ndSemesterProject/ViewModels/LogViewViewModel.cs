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
        private List<Object> _selectedtasks;
        public List<Object> SelectedTasks 
        {
            get { return _selectedtasks; }
            set
            {
                _selectedtasks = value;
                if (SelectedLogEntry != null)
                {
                    SelectedLogEntry.Tasks.Clear();
                    foreach (var task in _selectedtasks)
                    {
                        SelectedLogEntry.Tasks.Add((Models.Task)task);
                    }
                }
                OnPropertyChanged(nameof(SelectedTasks));
            }
        }

       private ObservableCollection<LogEntry> _userLogs; //The current users log entries.
        public ObservableCollection<LogEntry> UserLogs //The current users log entries.
        {
            get { return _userLogs; }
            set {  _userLogs = value; OnPropertyChanged(nameof(UserLogs)); }
        }
        
        private string _hourString;
        public string HourString // NumberOfHours as a string to go in textbox.
        {
            get { return _hourString; } 
            set { _hourString = value; OnPropertyChanged(nameof(HourString)); }
        }
       
            private int _roleIndex;
        public int RoleIndex // the index (int-value) of the role selected in the Ui.
        {
            get { return _roleIndex; }
            set { _roleIndex = value; SelectedLogEntry.Role = (Role)RoleIndex; OnPropertyChanged(nameof(RoleIndex));}
        }
        
        private LogEntry _selectedLogEntry;
        public LogEntry SelectedLogEntry //The LogEntry selected from the listbox in the UI.
        {  
            get { return _selectedLogEntry; }
            set {  _selectedLogEntry= value; OnPropertyChanged(nameof(SelectedLogEntry));
                if (SelectedLogEntry != null)
                {
                    HourString = SelectedLogEntry.NumberofHours.ToString();
                    RoleIndex = (int)SelectedLogEntry.Role;
                }
                }     
        }

        private LogEntryRepository LogRepo { get; set; } = new(); 
        private TaskRepository TaskRepo { get; set; } = new(); // Gets Tasks
        public List<Models.Task> Tasks { get;}
        
        public LogViewViewModel(string MA_Number) 
        {
            UserLogs = new(LogRepo.GetLogsByMA(MA_Number));
            SelectedLogEntry = UserLogs[0];
            Tasks =TaskRepo.Tasks.ToList();
            SelectedTasks = new();
        }

        public void DeleteLogEntry () 
        {
            LogRepo.DeleteLogEntry(SelectedLogEntry.Id);
            UserLogs.Remove(SelectedLogEntry);
        }

        public void UpdateLogEntry()
        {
            LogRepo.UpdateLogEntry(SelectedLogEntry);
            List<LogEntry> list =UserLogs.OrderBy(x => x.Id).ToList(); //Calls the Userlogs setter for OnPropertyChanged.
            UserLogs = new(list);
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
