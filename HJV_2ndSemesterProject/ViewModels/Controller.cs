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
        private DateTime st;
        private DateTime et;
        private Sailing sailing;
        public Controller() 
        {
            string s = DataAccess.conn.ConnectionString;
            st = new DateTime(2018, 01, 18, 12, 30, 0);
            et = new DateTime(2018, 01, 18, 14, 0, 0);
            sailing = new(st, et, (SailingType)5, "MHV 807");
            CurrentUser = new Volunteer("568493","Egon", "HVF 131", (Rank) 1);
            taskRepo = new TaskRepository();
            vesselRepo = new VesselRepository();
            logEntryRepo = new LogEntryRepository();
            sailingRepo = new SailingRepository();
        }

        public void AddLogEntry()
        {
             int id = sailingRepo.CreateSailing(sailing);
            LogEntry entry = new((Role)2, 120, "Test", CurrentUser.MA_Number, id);
            logEntryRepo.CreateLogEntry(entry);

        }


    }
}
