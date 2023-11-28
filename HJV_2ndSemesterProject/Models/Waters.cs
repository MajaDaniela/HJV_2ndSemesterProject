using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    internal class Waters
    {
        public string Name {  get; set; }
        public string WatersType { get; set; }

        public Waters(string name, string watersType)
        {
            Name = name;
            WatersType = watersType;
        }
    }
}
