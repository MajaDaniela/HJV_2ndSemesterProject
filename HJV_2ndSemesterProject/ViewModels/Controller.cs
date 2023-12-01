using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class Controller
    {
        private TaskRepository taskRepo { get; set; }
        private VesselRepository vesselRepo { get; set; }
        private SailingRepository sailingRepo { get; set; }

        private LogEntryRepository logEntryRepo { get; set; }

        private Volunteer CurrentUser {  get; set; }
      
        public Controller() 
        {
            CurrentUser = new Volunteer("568493","Egon", "HVF 131", (Rank) 1);
            taskRepo = new TaskRepository();
            vesselRepo = new VesselRepository();
            logEntryRepo = new LogEntryRepository();
            sailingRepo = new SailingRepository();
        }

        public void AddLogEntry()
        {
            AddSailing();

        }

        public void AddSailing() 
        {

        }
    }
}
