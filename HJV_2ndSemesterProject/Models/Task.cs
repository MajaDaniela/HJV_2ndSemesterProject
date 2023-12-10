using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.Models
{
    public class Task
    {
        public string TaskType { get; set; }

        public Task(string type)
        {   
            TaskType = type;
        }
    }
}
