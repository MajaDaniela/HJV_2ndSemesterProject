using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class LogEntryRepo
    {
        private Controller controller;

        public LogEntryRepo(Controller controller)
        {
            this.controller = controller;
        }

        public DataTable GetLogEntries()
        {
            using (SqlConnection connection = new SqlConnection(controller.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * LOG_ENTRY", connection);
                DataTable dt = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                return dt;
            }
        }
    }
}
