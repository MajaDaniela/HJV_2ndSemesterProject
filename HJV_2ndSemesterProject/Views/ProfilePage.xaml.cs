
using HJV_2ndSemesterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : UserControl
    {
        ProfileViewModel PVM;
        public ProfilePage(string MA_Number)
        {
            PVM = new(MA_Number);
            InitializeComponent();
            DataContext = PVM;
        }

    }
}
