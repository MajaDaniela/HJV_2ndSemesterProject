using HJV_2ndSemesterProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class LogEntryRepository
    {

        public LogEntryRepository() { }

        public void CreateLogEntry(LogEntry entry)
        {
            using (DBConnectionManager.conn)
            {
                SqlCommand cmd = new SqlCommand("CreateLogEntry", DBConnectionManager.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Role", (int)entry.Role);
                cmd.Parameters.AddWithValue("@NumberOfMinutes", entry.NumberofMinutes);
                cmd.Parameters.AddWithValue("@Comment", entry.Comment);
                cmd.Parameters.AddWithValue("@MA_Number", entry.MA_Number);
                cmd.Parameters.AddWithValue("@SailingID", entry.SailingID);

                DBConnectionManager.conn.Open();
                cmd.ExecuteNonQuery();


            }   }
    }
}
