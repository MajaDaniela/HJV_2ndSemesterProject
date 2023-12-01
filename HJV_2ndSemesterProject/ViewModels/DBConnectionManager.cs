using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HJV_2ndSemesterProject.ViewModels
{
    public static class DBConnectionManager
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        
        public static SqlConnection conn = new($"Data Source=10.56.8.36;Initial Catalog=DB_F23_TEAM_14;User Id={Username};Password={Password};");

        public static bool TestConn(string username, string password)
        {
            Username = username;
            Password = password;
             conn = new($"Data Source=10.56.8.36;Initial Catalog=DB_F23_TEAM_14;User Id={Username};Password={Password};");
            try
            {
                using (conn)
                {
                    conn.Open();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Username = ""; Password = "";
                return false;
            }
        }
    }
}
