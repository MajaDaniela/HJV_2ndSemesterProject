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
        
        public int TaskID {  get; set; }
        public Task(string type, int id)
        {   
            TaskType = type;
            TaskID = id;
        }
    }
}
