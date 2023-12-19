using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    // Provides datacontext for the ProfilePage.
   public  class ProfileViewModel
    {
        public Volunteer CurrentUser { get; set; }
        public double[] LoggedHours {  get; set; }
        private VolunteerRepository VolunteerRepo;
        public string ViewRank {  get; set; }
        
        public ProfileViewModel(string MA_NUmber) 
        {
            VolunteerRepo = new();
            CurrentUser = VolunteerRepo.GetVolunteer(MA_NUmber);
            LoggedHours = VolunteerRepo.GetHours(MA_NUmber);
            ViewRank = CurrentUser.Rank.GetDescription();
        }
    }
}
