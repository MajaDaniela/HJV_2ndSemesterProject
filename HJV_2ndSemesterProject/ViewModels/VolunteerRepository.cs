using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;
using HJV_2ndSemesterProject.Data;
using System.Dynamic;
using System.Data.SqlClient;
using System.Data;

namespace HJV_2ndSemesterProject.ViewModels
{
    //Gets a volunteer from the database, based on the MA_Number. Is used by the MainViewModel to get the current user.
    public class VolunteerRepository
    {
        private Volunteer volunteer;

        public Volunteer GetVolunteer(string MA_Number)
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            using (SqlCommand cmd = new SqlCommand("sp_GetVolunteer", DataAccess.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MA_Number", MA_Number);
                DataAccess.conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        volunteer = new(MA_Number, reader["VolunteerName"].ToString(),
                         reader["Flotilla"].ToString(), (Rank)(int)reader["VolunteerRank"]);
                    }
                    return volunteer;
                }
            }
        }

        //Returns an Array containing a volunteer's logged hours for each role.
        public double[] GetHours(string MA_Number)
        {
            double[] result = new double[5];
            DataAccess.NewConn();
            using (DataAccess.conn)
            using (SqlCommand cmd = new SqlCommand("sp_GetHourSum", DataAccess.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MA_Number", MA_Number);
                DataAccess.conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[(int)reader["Role"]] = (double)reader["Total"];

                    }
                    return result;
                }
            }
        }
    }
}
