using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    public class Waters
    {
        public string Name {  get; set; }
        public int WatersType { get; set; }

        public Waters(string name, int watersType)
        {
            Name = name;
            WatersType = watersType;
        }
    }
}
