using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;
using HJV_2ndSemesterProject.Data;

namespace HJV_2ndSemesterProject.ViewModels
{
    //This class supplies a list of all the Vessels from the database. Used by LogEntryViewModel for databinding a combobox.
    public class VesselRepository
    {
        public Vessel vessel;

        public ObservableCollection<Vessel> Vessels { get; }

        public VesselRepository()
        {
            Vessels = new ObservableCollection<Vessel>();
            GetVessels();
        }
        private void GetVessels()
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                DataAccess.conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from VESSEL", DataAccess.conn)) 
                {
                    using SqlDataReader reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Vessel v = new(reader["VesselID"].ToString(), reader["VesselName"].ToString());
                            Vessels.Add(v);
                        }
                    }
                }

            }
        }
    }
}
