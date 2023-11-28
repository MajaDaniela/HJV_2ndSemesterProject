using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    internal class Sailing
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string SailingType { get; set; }

        public Sailing(DateTime endDate, DateTime startDate, string sailingType)
        {
            EndDate = endDate;
            StartDate = startDate;
            SailingType = sailingType;
        }
    }
}
