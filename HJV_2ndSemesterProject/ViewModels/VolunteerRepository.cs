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
    public class VolunteerRepository
    {
        private Volunteer volunteer;

        public Volunteer GetVolunteer(string MA_Number)
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetVolunteer", DataAccess.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MA_Number", MA_Number);
                    DataAccess.conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string volunteerName = reader["VolunteerName"] != DBNull.Value ? reader["VolunteerName"].ToString() : string.Empty;
                            string flotilla = reader["Flottila"] != DBNull.Value ? reader["Flottila"].ToString() : string.Empty;

                            // Checking rank.
                            if (int.TryParse(reader["VolunteerRank"].ToString(), out int volunteerRankValue)) //Laver værdien om til en int. 
                            {
                                int volunteerRank = volunteerRankValue;
                                volunteer = new Volunteer(MA_Number, volunteerName, flotilla, (Rank)volunteerRank);
                            }
                            else
                            {
                                Console.WriteLine("Problem, fejl i indtastningen..");
                            }
                        }

                        //while (reader.Read())
                        //{
                        //    volunteer = new(MA_Number, reader["VolunteerName"].ToString(),
                        //     reader["Flotilla"].ToString(), (Rank)(int)reader["VolunteerRank"]);
                        //}
                        return volunteer;
                    }

                }

            }
        }




        public void CreateVolunteer()
        {

        }

        public void DeleteVolunteer()
        {

        }

        public void UpdateVolunteer()
        {

        }
    }
}
