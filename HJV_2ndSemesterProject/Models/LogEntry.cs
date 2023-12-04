using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
     public class LogEntry
    {
        public Role Role {  get; set; }
        public int NumberofMinutes { get; set; }
        public string Comment { get; set; }

        public string MA_Number { get; set; }
        public int SailingID { get; set; }

        public LogEntry(Role role, int minutes, string comment, string ma, int sailingID ) 
        {
            Role = role;
            NumberofMinutes = minutes;
            Comment = comment;
            MA_Number = ma;
            SailingID = sailingID;
        }
    }
}
