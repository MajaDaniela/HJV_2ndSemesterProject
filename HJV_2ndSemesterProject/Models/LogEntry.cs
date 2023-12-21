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
        public Role Role { get; set; }
        public double NumberofHours { get; set; }
        public string Comment { get; set; }

        public string MA_Number { get; set; }
        public int SailingID { get; set; }
        public List<Task>? Tasks { get; set; } 

        public LogEntry(Role role, double hours, string comment, string ma, int sailingID, List<Task> tasks, int id = 0)
        {
            Role = role;
            NumberofHours = hours;
            Comment = comment;
            MA_Number = ma;
            SailingID = sailingID;
            Id = id;
            Tasks = tasks;
            if (Tasks==null) Tasks = new();        
        }
        public override string ToString()
        {

            return $"#{Id} {Role.GetDescription()} {NumberofHours} timer";
        }
    }
}