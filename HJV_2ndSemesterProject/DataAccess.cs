using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HJV_2ndSemesterProject.Data
{
    //This class handles the connection to the database. So it can be used by other classes.
    public static class DataAccess
    {
        public static string connectionString { get; set; }

        public static SqlConnection conn;
        public static bool TestConn(string username, string password) //Gets database username and password from the logInWindow. And tests for connection.
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
        //Resets the connection, ready for use.
        public static void NewConn()
        {
            conn = new SqlConnection(connectionString);
        }
    }
}
