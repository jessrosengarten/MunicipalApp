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

namespace Municipal_App
{
    /// <summary>
    /// Represents the main window of the Municipal App.
    /// Provides navigation to various modules of the application.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Service request manager instance to handle service requests
        public static ServiceRequestManager serviceRequestManager = new ServiceRequestManager();

        public MainWindow()
        {
            InitializeComponent(); 
        }

        /// <summary>
        /// Handles the click event of the "Report Issues" button.
        /// </summary>
        private void btnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssuesWindow reportIssuesWindow = new ReportIssuesWindow();
            reportIssuesWindow.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the click event of the "View Issues" button.
        /// </summary>
        public void btnViewIssues_Click(object sender, RoutedEventArgs e) 
        {
            ViewIssuesWindow viewIssuesWindow = new ViewIssuesWindow();
            viewIssuesWindow.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the click event of the "Events and Announcements" button.
        /// </summary>
        public void btnEventsAndAnnouncements_Click(object sender, RoutedEventArgs e)
        {
            EventsAndAnnouncementsWindow eventsAndAnnouncementsWindow = new EventsAndAnnouncementsWindow();
            eventsAndAnnouncementsWindow.Show();
            this.Close(); 
        }

        /// <summary>
        /// Handles the click event of the "Service Request Status" button.
        /// </summary>
        private void btnServiceRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow serviceRequestStatusWindow = new ServiceRequestStatusWindow();
            serviceRequestStatusWindow.Show();
            this.Close(); 
        }

    }
}
