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
        public bool IsConnected = false; //Starting with a not active connection to the database.

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) //Checking if the application is conncted to the database. Also takes the inputs from the user. Opens mainwindow if entered username is valid.
        {
            string enteredUsername = emailTextBox.Text;
            string enteredPassword = passwordBox.Password;

            if (!IsConnected)
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

        //It checks if database is connected and executes a SQL query, checking for the MA_Number.
        //If a matching record is found (reader.HasRows is true) the method returns true.
        private bool IsValidLogin(string enteredUsername)
        {

            if (string.IsNullOrEmpty(DataAccess.connectionString))
            {
                MessageBox.Show("Ingen forbindelse til databasen..");
                return false;
            }

            DataAccess.NewConn(); // Set the connection string

            if (!IsConnected) //If IsConnected is false. 
            {
                MessageBox.Show("Ingen forbindelse til databasen..");
                return false;
            }

            using (SqlConnection sqlConnection = DataAccess.conn) 
            { 
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM VOLUNTEER WHERE MA_Number = '{enteredUsername}'", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MA_Number", enteredUsername);

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true; // Username exist as a MA-number in the database
                    }
                }
            }

            return false; // Invalid login 
        }

        private void ConnectToDbBtn_Click(object sender, RoutedEventArgs e)
        {

            IsConnected = DataAccess.TestConn(DatabaseTb.Text, DatabasePswdTb.Password); 
            if (!IsConnected)
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
