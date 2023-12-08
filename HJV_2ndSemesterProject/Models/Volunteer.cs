using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    public class Volunteer
    {
        public string MA_Number { get; set; }
        public string Name { get; set; }
        public string Flotilla { get; set; }
        public Rank Rank { get; set; }

        public Volunteer(string ma_number, string name, string flotilla, Rank rank)
        {
            MA_Number = ma_number;
            Name = name;
            Flotilla = flotilla;
            Rank = rank;
        }
    }
}
