﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJV_2ndSemesterProject.Models;

namespace HJV_2ndSemesterProject.ViewModels
{
    public class VesselRepository
    {
        public Vessel vessel;

        public ObservableCollection<Vessel> vessels;

        public VesselRepository()
        {
            vessels = new ObservableCollection<Vessel>();
            GetVessels();
        }
        public void GetVessels()
        {
            DataAccess.NewConn();
            using (DataAccess.conn)
            {
                DataAccess.conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Vessel", DataAccess.conn)) 
                {
                    using SqlDataReader reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Vessel v = new(reader["VesselID"].ToString(), reader["VesselName"].ToString());
                            vessels.Add(v);
                        }
                    }
                }

            }
        }













        public void CreateVessel()
        {

        }

        public void DeleteVessel()
        {

        }

        public void UpdateVessel()
        {

        }
    }
}