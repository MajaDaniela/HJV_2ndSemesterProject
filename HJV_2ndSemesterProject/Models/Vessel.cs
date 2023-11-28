using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    internal class Vessel
    {
        public string VesselNumber {  get; set; }
        public string Name { get; set; }

        public Vessel(string vesselNumber, string name) 
        { 
            VesselNumber = vesselNumber;             
            Name = name;        
        }
    }
}
