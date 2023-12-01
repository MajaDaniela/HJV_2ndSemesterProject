using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    internal class SailingRepository
    {
        public Sailing sailing;

        public void CreateSailing(Sailing s)
        {
            using (DBConnectionManager.conn)
            {
                SqlCommand cmd = new SqlCommand("CreateSailing",DBConnectionManager.conn);
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SailingType", (int)s.SailingType);
                cmd.Parameters.AddWithValue("@StartTime", s.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", s.EndTime);
                cmd.Parameters.AddWithValue("@VesselID", s.VesselID);
                
                DBConnectionManager.conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteSailing()
        {

        }

        public void UpdateSailing()
        {

        }
    }
}
