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

        private Volunteer CurrentUser {  get; set; }
        private ObservableCollection<LogEntry> UsersLogs { get; set; }
        private Sailing sailing;
        public Controller() // MA_NUmber from login as parameter?
        {
            TaskRepo = new TaskRepository();
            VesselRepo = new VesselRepository();
            LogEntryRepo = new LogEntryRepository();
            SailingRepo = new SailingRepository();
            VolunteerRepo = new VolunteerRepository();
            // CurrentUser = VolunteerRepo.GetVolunteer(MA_numberLOGIN);
            //UserLogs = LogEntryRepo.GetlogsByMA
        }

        public void AddLogEntry()
        {
             int id = SailingRepo.CreateSailing(sailing);
            LogEntry entry = new((Role)2, 120, "Test", CurrentUser.MA_Number, id);
            LogEntryRepo.CreateLogEntry(entry);
        }


    }
}
