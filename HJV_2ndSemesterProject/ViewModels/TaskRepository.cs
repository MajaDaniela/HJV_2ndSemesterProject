using HJV_2ndSemesterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class TaskRepository
    {
        public ObservableCollection <Models.Task> tasks { get; set; }

        public void GetTasks()
        {
            using (DBConnectionManager.conn)
            {
                DBConnectionManager.conn.Open();
                SqlCommand cmd = new SqlCommand("Select tasktype from TaSk", DBConnectionManager.conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Models.Task t = new(reader["TaskType"].ToString());
                        tasks.Add(t);
                    }
                }


            }
        }
        public TaskRepository() 
        { 
            tasks = new ObservableCollection<Models.Task>();
            GetTasks();
        }
}
