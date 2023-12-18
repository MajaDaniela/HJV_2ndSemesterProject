using HJV_2ndSemesterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class LogEntryViewModel
    {
        public Role Role { get; set; }
        public double NumberofHours { get; set; }
        public string? Comment { get; set; }
        public string MA_Number { get;}
        public List<Models.Task> SelectedTasks { get; }
        public string[] EndTimes { get; set; }
        public string[] StartTimes { get; set; }
        public SailingType SailingType { get; set; }
        public string? VesselID { get; set; }
        public List<Waters> SelectedWaters { get; }

        private Sailing UserSailing;
        private LogEntry UserLogEntry; 

        private LogEntryRepository LogRepo { get; set; }
        private SailingRepository SailingRepo { get; set; }
        public VesselRepository Vessels{ get;}
        public TaskRepository Tasks{ get;}
        public WatersRepository Waters{ get;}

       
        
        public LogEntryViewModel (string MA_Number)
        {
            LogRepo = new();
            SailingRepo = new();
            Vessels = new();
            Tasks = new();
            Waters = new();
            this.MA_Number = MA_Number;
            StartTimes = new string[3];
            EndTimes = new string[3];
            SelectedTasks = new();
            SelectedWaters = new();
        }


        public void AddLogEntry()
        {
            DateTime StartTime = DateTime.Parse($"{StartTimes[0]} {StartTimes[1]}:{StartTimes[2]}");
            DateTime EndTime = DateTime.Parse($"{EndTimes[0]} {EndTimes[1]}:{EndTimes[2]}");
            
            UserSailing = new(StartTime, EndTime, SailingType, VesselID, SelectedWaters);
            int id = SailingRepo.CreateSailing(UserSailing);

            UserLogEntry = new(Role, NumberofHours, Comment, MA_Number,id,SelectedTasks);
            LogRepo.CreateLogEntry(UserLogEntry);
        }


    }
}
