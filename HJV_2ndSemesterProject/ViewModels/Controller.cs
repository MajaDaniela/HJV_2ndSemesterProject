using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class Controller
    {
        public string connectionString;
        LogEntryRepo logEntryRepo;
        SailingRepo sailingRepo;
        VesselRepo vesselRepo;
        VolunteerRepo volunteerRepo;

        public Controller(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            logEntryRepo = new LogEntryRepo(this); // Make sure to replace with your actual repository
            sailingRepo = new SailingRepo(); // Replace with your repository
            vesselRepo = new VesselRepo(); // Replace with your repository
            volunteerRepo = new VolunteerRepo(); // Replace with your repository
        }
    }
}
