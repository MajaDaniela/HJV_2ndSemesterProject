using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class Controller
    {
        private TaskRepository TaskRepo { get; set; }
        private VesselRepository VesselRepo { get; set; }
        private SailingRepository SailingRepo { get; set; }

        private LogEntryRepository LogEntryRepo { get; set; }
        private VolunteerRepository VolunteerRepo { get; set; }
        

        public Volunteer CurrentUser { get; set; }
        public ObservableCollection<LogEntry> UsersLogs { get;}
        public Sailing CurrentSailing { get; set; }
        public LogEntry CurrentLogEntry {  get; set; }
       
        public Controller( string MA_Number) 
        {
            TaskRepo = new TaskRepository();
            VesselRepo = new VesselRepository();
            LogEntryRepo = new LogEntryRepository();
            SailingRepo = new SailingRepository();
            VolunteerRepo = new VolunteerRepository();
            CurrentUser = VolunteerRepo.GetVolunteer(MA_Number);
            UsersLogs = new (LogEntryRepo.GetLogsByMA(CurrentUser.MA_Number));
        }

        public void AddLogEntry()
        {
             int id = SailingRepo.CreateSailing(CurrentSailing);
            CurrentLogEntry.SailingID = id;
            LogEntryRepo.CreateLogEntry(CurrentLogEntry);
        }

        public void EditLogEntry()
        {
            LogEntryRepo.UpdateLogentry(CurrentLogEntry);
        }

        public void DeleteLogEntry()
        {
            LogEntryRepo.DeleteLogEntry(CurrentLogEntry.Id);
        }


    }
}
