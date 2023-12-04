using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HJV_2ndSemesterProject.ViewModels
{
    public static class DataAccess
    {
        public static string connectionString { get; set; }

        public static SqlConnection conn;
        public static bool TestConn(string username, string password)
        {
            connectionString = $"Data Source=10.56.8.36;Initial Catalog=DB_F23_TEAM_14;User Id={username};Password={password};";
            using (conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }

                catch (Exception ex)
                {
                    connectionString = "";
                    return false;
                }
            }
        }
        public static void NewConn()
        {
            conn = new SqlConnection(connectionString);
        }


    }
}
