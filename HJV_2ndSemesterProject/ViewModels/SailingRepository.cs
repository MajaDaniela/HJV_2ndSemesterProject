using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using HJV_2ndSemesterProject.Models;
using HJV_2ndSemesterProject.Data;
using System.ComponentModel;

namespace HJV_2ndSemesterProject.ViewModels
{
    internal class SailingRepository
    {
        public Sailing sailing;

        //Checks if the userinputs in the LogEntryPage match a saling in the database.
        //If not it adds a saling and returns the new sailingID.
        public int CreateSailing(Sailing s)
        {
            int newId;
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                using SqlCommand cmd1 = new SqlCommand("sp_GetSailing", DataAccess.conn);
                { cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@VesselID", s.VesselID);
                    cmd1.Parameters.AddWithValue("@StartTime", s.StartTime);
                    DataAccess.conn.Open();
                    var v = cmd1.ExecuteScalar();
                    if (v != null) return  Convert.ToInt32(v);
                }

                using SqlCommand cmd2 = new SqlCommand("sp_CreateSailing", DataAccess.conn);
                {
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@SailingType", (int)s.SailingType);
                    cmd2.Parameters.AddWithValue("@StartTime", s.StartTime);
                    cmd2.Parameters.AddWithValue("@EndTime", s.EndTime);
                    cmd2.Parameters.AddWithValue("@VesselID", s.VesselID);

                    newId = Convert.ToInt32(cmd2.ExecuteScalar());

                    foreach (Waters waters in s.Waters)
                    {
                        LinkWatersToSailing(waters.Name,newId,DataAccess.conn);
                    }
                    return newId;
                }  
            }
        }
        //Adds rows to the SAILING_WATERS linking table in the database.
        private void LinkWatersToSailing(string watersName,int sailingId,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("sp_CreateSailingWaters", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SailingID", sailingId);
                cmd.Parameters.AddWithValue("@WatersName", watersName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
