using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class MainViewModel
    {
        private VolunteerRepository VolunteerRepo { get; set; }    
        public Volunteer CurrentUser { get; set; }
       
        public MainViewModel( string MA_Number) 
        {
            VolunteerRepo = new VolunteerRepository();

            CurrentUser = VolunteerRepo.GetVolunteer(MA_Number);
        }


        //public void EditLogEntry()
        //{
        //    LogEntryRepo.UpdateLogentry(CurrentLogEntry);
        //}

        //public void DeleteLogEntry()
        //{
        //    LogEntryRepo.DeleteLogEntry(CurrentLogEntry.Id);
        //}


    }
}
