using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
     public class LogEntry
    {
        public int Id { get; set; }
        public Role Role {  get; set; }
        public double NumberofHours { get; set; }
        public string Comment { get; set; }

        public string MA_Number { get; set; }
        public int SailingID { get; set; }
        public List<Task> Tasks { get; }

        public LogEntry(Role role, double hours, string comment, string ma, int sailingID, int id =0 ) 
        {
            Role = role;
            NumberofHours = hours;
            Comment = comment;
            MA_Number = ma;
            SailingID = sailingID;
            Id = id;
            Tasks = new List<Task>();
        }

    }
}
