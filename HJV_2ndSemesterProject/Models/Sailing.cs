using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    internal class Sailing
    {
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public SailingType SailingType { get; set; }

        public Sailing(DateTime end, DateTime start, SailingType sailingType)
        {
            EndTime = end;
            StartTime = start;
            SailingType = sailingType;
        }
    }
}
