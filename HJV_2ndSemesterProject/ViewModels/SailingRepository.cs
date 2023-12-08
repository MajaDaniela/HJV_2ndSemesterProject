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

namespace HJV_2ndSemesterProject.ViewModels
{
    internal class SailingRepository
    {
        public Sailing sailing;

        public int CreateSailing(Sailing s)
        {
            
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
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@SailingType", (int)s.SailingType);
                cmd2.Parameters.AddWithValue("@StartTime", s.StartTime);
                cmd2.Parameters.AddWithValue("@EndTime", s.EndTime);
                cmd2.Parameters.AddWithValue("@VesselID", s.VesselID);
  
                return Convert.ToInt32(cmd2.ExecuteScalar());
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
