using HJV_2ndSemesterProject.ViewModels;
using HJV_2ndSemesterProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Threading.Channels;


namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 


    public partial class LoginWindow : Window
    {
        public bool IsConneceted = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        //TestPassword string TestPassword


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = emailTextBox.Text;
            string enteredPassword = passwordBox.Password;

            if (!IsConneceted)
            {
                MessageBox.Show("Ingen forbindelse til databasen..");
                return;
            }

            if (IsValidLogin(enteredUsername))
            {
                MainWindow main = new MainWindow(enteredUsername);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Forkert email eller adgangskode. Prøv igen..");
            }
        }

        private bool IsValidLogin(string enteredUsername)
        {
            const string enteredPassword = "Test123"; // Set password to "Test123"

            if (string.IsNullOrEmpty(DataAccess.connectionString))
            {
                MessageBox.Show("Ingen forbindelse til databasen..");
                return false;
            }

            DataAccess.NewConn(); // Set the connection string

            if (!IsConneceted)
            {
                MessageBox.Show("Ingen forbindelse til databasen..");
                return false;
            }

            using (SqlConnection sqlConnection = DataAccess.conn) // Use the existing connection
            { //Dette afsnit fungerer efter hensigten, men kalder på VolunteerRepositoriet hvor den kalder fejl på GetVolunteer (String MA-Number = unknown)
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM VOLUNTEER WHERE MA_Number = '{enteredUsername}'", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MA_Number", enteredUsername);

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true; // Valid login

                    }
                }
            }

            return false; // Invalid login 
        }








        private void ConnectToDbBtn_Click(object sender, RoutedEventArgs e)
        {

            IsConneceted = DataAccess.TestConn(DatabaseTb.Text, DatabasePswdTb.Password); 
            if (!IsConneceted)
            {
                MessageBox.Show($"Fejl under oprettelse af forbindelse"); DatabaseTb.Clear(); DatabasePswdTb.Clear();
            }
            else
            {
                MessageBox.Show($"Login virkede");
            }
        }
    }
}
