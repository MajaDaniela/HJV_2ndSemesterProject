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
using System.Data.SqlClient;
using HJV_2ndSemesterProject.ViewModels;
usinf
using System.Threading.Channels;

namespace HJV_2ndSemesterProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 

    public class TestAdmin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class TestUser
    {
        public string Email { get; set; }
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
                Email = "admin@example.com",
                Password = "adminpassword"
            };
        }

        private void InitializeTestUser()
        {
            testUser = new TestUser
            {
                Email = "test@example.com",
                Password = "testpassword"
            };
        }



        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            if (IsConneceted)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }


            //string enteredEmail = emailTextBox.Text;
            //string enteredPassword = passwordBox.Password;

            //if (IsValidLogin(enteredEmail, enteredPassword, testUser))
            //{
            //    // Navigate to the user profile. HAS TO BE CHANGED TO PAGE instead of window
            //    UserProfileWindow userProfileWindow = new UserProfileWindow();
            //    userProfileWindow.Show();


            //    Window parentWindow = Window.GetWindow(this);
            //    if (parentWindow != null)
            //    {
            //        parentWindow.Close();
            //    }
            //}
            //else if (IsValidLogin(enteredEmail, enteredPassword, testAdmin))
            //{
            //    // Navigate to the admin profile  HAS TO BE CHANGED TO PAGE instead of window
            //    AdminProfileWindow adminProfileWindow = new AdminProfileWindow();
            //    adminProfileWindow.Show();

            //    Window parentWindow = Window.GetWindow(this);
            //    if (parentWindow != null)
            //    {
            //        parentWindow.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Forkert email eller adgangskode. Prøv igen..");
            //}
        }

        private bool IsValidLogin(string enteredEmail, string enteredPassword, object user)
        {
            if (user is TestUser)
            {
                return enteredEmail == ((TestUser)user).Email && enteredPassword == ((TestUser)user).Password;
            }
            else if (user is TestAdmin)
            {
                return enteredEmail == ((TestAdmin)user).Email && enteredPassword == ((TestAdmin)user).Password;
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
