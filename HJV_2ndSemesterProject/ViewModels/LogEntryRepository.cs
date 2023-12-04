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
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateLogEntry", DataAccess.conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Role", (int)entry.Role);
                    cmd.Parameters.AddWithValue("@NumberOfMinutes", entry.NumberofMinutes);
                    cmd.Parameters.AddWithValue("@Comment", entry.Comment);
                    cmd.Parameters.AddWithValue("@MA_Number", entry.MA_Number);
                    cmd.Parameters.AddWithValue("@SailingID", entry.SailingID);

                    DataAccess.conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
