using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    class LogEntry
    {
        public Role Role {  get; set; }
        public int NumberofMinutes { get; set; }
        public string Comment { get; set; }

        public LogEntry(Role role, int minutes, string comment) 
        {
            Role = role;
            NumberofMinutes = minutes;
            Comment = comment;
        }
    }
}
