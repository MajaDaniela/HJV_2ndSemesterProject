using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    public class Vessel
    {
        public string VesselID {  get; set; }
        public string Name { get; set; }

        public Vessel(string vesselNumber, string name) 
        { 
            VesselID = vesselNumber;             
            Name = name;        
        }

        public override string ToString()
        {
            return $"{VesselID} {Name}";
        }
    }
}
