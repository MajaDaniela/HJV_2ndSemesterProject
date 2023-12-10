using HJV_2ndSemesterProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Data;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class LogEntryRepository
    {

        public LogEntryRepository() { }

        public void CreateLogEntry(LogEntry entry)
        {
            int newID;
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
                    newID= Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (Models.Task t in entry.Tasks)
                {
                    LinkTaskToLogEntry(newID, t.TaskType, DataAccess.conn);
                }
            }
        }

        public void UpdateLogentry( LogEntry updated )
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateLogEntry", DataAccess.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogID", updated.Id);
                    cmd.Parameters.AddWithValue("@Role", (int)updated.Role);
                    cmd.Parameters.AddWithValue("@NumberOfMinutes", updated.NumberofMinutes);
                    cmd.Parameters.AddWithValue("@Comment", updated.Comment);
                    cmd.Parameters.AddWithValue("@MA_Number", updated.MA_Number);
                    cmd.Parameters.AddWithValue("@SailingID", updated.SailingID);
                    DataAccess.conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLogEntry(int id)
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            {

                using (SqlCommand cmd = new SqlCommand("sp_DeleteLogEntry", DataAccess.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogID", id);
                    DataAccess.conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<LogEntry> GetLogsByMA (string MA_NUmber)
        {
            List<LogEntry> result= new();
            DataAccess.NewConn();
            using (DataAccess.conn)
            {

                using (SqlCommand cmd = new SqlCommand("sp_GetLogEntriesByMa_Number", DataAccess.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MA_NUmber",MA_NUmber);
                    DataAccess.conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            LogEntry entry = new((Role)(int)reader["Role"], (int)reader["NumberOFMinutes"],
                                reader["Comment"].ToString(), MA_NUmber, (int)reader["SailingID"],
                                (int)reader["LogID"]);

                            result.Add(entry);
                        }
                        return result;
                    }
                }
            }
        }

        private void LinkTaskToLogEntry(int logId, string taskType,SqlConnection connection) 
        {
            using (SqlCommand cmd= new("sp_CreateLogEntryTask",connection))
            {
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogID",logId);
                cmd.Parameters.AddWithValue("@TaskType", taskType);
                cmd.ExecuteNonQuery();
            }      
        }
    }
}
