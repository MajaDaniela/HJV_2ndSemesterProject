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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HJV_2ndSemesterProject.Views
{
    /// <summary>
    /// Interaction logic for LogEntryPage.xaml
    /// </summary>
    public partial class LogEntryPage : UserControl
    {
        private LogEntryRepo logEntryRepo;

        public LogEntryPage(LogEntryRepo logEntryRepo)
        {
            InitializeComponent();
            this.logEntryRepo = logEntryRepo;
            LoadEntriesIntoGrid();
        }

        private void LoadEntriesIntoGrid()
        {
            
            EntryLogDatagrid.ItemsSource = logEntryRepo.GetLogEntries().DefaultView;
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }
    }
}
