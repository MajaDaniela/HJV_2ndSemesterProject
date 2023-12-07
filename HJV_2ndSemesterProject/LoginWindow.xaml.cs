using HJV_2ndSemesterProject.ViewModels;
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

namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 

    public class TestAdmin
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class TestUser
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }



    public partial class LoginWindow : Window
    {
        private TestAdmin testAdmin;
        private TestUser testUser;
        public bool IsConneceted = false;

        public LoginWindow()
        {
            InitializeComponent();
            InitializeTestUser();
            InitializeTestAdmin();
        }
        

        

        private void InitializeTestAdmin()
        {
            testAdmin = new TestAdmin
            {
                Username = "Admin",
                Name = "AdminName",
                Password = "admin"
            };
        }

        private void InitializeTestUser()
        {
            testUser = new TestUser
            {
                Username = "568493",
                Name = "Egon",
                Password = "testpassword"
            };
        }



        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = emailTextBox.Text;
            string enteredPassword = passwordBox.Password;

            if (IsValidLogin(enteredUsername, enteredPassword, testUser))
            {
                // Navigate to the user profile. HAS TO BE CHANGED TO PAGE instead of window
                if (IsConneceted)
                {
                    MainWindow main = new MainWindow(enteredUsername);
                    main.Show();
                    this.Close();
                }
            }
            else if (IsValidLogin(enteredUsername, enteredPassword, testAdmin))
            {
                if (IsConneceted)
                {
                    MainWindow main = new MainWindow(enteredUsername);
                    main.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Forkert email eller adgangskode. Prøv igen..");
            }
        }

        private bool IsValidLogin(string enteredUsername, string enteredPassword, object user)
        {
            if (user is TestUser)
            {
                return enteredUsername == ((TestUser)user).Username && enteredPassword == ((TestUser)user).Password;
            }
            else if (user is TestAdmin)
            {
                return enteredUsername == ((TestAdmin)user).Username && enteredPassword == ((TestAdmin)user).Password;
            }

            return false;
        }



        private void ConnectToDbBtn_Click(object sender, RoutedEventArgs e)
        {

            IsConneceted = DataAccess.TestConn(DatabaseTb.Text, DatabasePswdTb.Password); //Skiftet fra PasswordBox
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
