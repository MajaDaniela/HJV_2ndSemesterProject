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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
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

    public partial class LogInPage : UserControl
    {
        private TestAdmin testAdmin;
        private TestUser testUser;


        public LogInPage()
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

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Indtast email")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Indtast email";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
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

            string serverIp = "10.56.8.36"; 
            string serverName = "DB_F23_TEAM_14";
            string username = DatabaseTb.Text;
            string password = PasswordBox.Password;

            string connectionString = $"Data Source={serverIp};Initial Catalog={serverName};User Id={username};Password={password};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Nu kan du udføre SQL-forespørgsler eller andre operationer

                    MessageBox.Show("Forbindelse oprettet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fejl under oprettelse af forbindelse: {ex.Message}");
            }
        }

        private void TextBlock_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
