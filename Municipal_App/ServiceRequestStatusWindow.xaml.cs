using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Municipal_App
{
    /// <summary>
    /// Interaction logic for ServiceRequestStatusWindow.xaml
    /// Allows users to search, sort, and filter service requests based on various criteria
    /// </summary>
    public partial class ServiceRequestStatusWindow : Window
    {
        public ServiceRequestStatusWindow()
        {
            InitializeComponent();            
            RefreshServiceRequests(); // Load and display all service requests, including dummy data
        }

        /// <summary>
        /// Refreshes the list of service requests displayed in the DataGrid
        /// </summary>
        private void RefreshServiceRequests()
        {
            var serviceRequestManager = MainWindow.serviceRequestManager;
            if (serviceRequestManager.GetAllServiceRequests().Count == 0)
            {
                AddDummyData(serviceRequestManager);
            }

            // Retrieve all service requests and display them in the DataGrid
            var allRequests = serviceRequestManager.GetAllServiceRequests();
            LoadServiceRequests(allRequests);
        }

        /// <summary>
        /// Adds dummy data to the ServiceRequestManager 
        /// </summary>
        private void AddDummyData(ServiceRequestManager serviceRequestManager)
        {
            var request1 = new ServiceRequest(1001, "Pending", "Awaiting approval", "Broken pipe near Main Street", "Utilities");
            var request2 = new ServiceRequest(1002, "In Progress", "Assigned to technician", "Potholes on 5th Avenue", "Roads");
            var request3 = new ServiceRequest(1003, "Completed", "Request fulfilled", "Overflowing garbage bins", "Sanitation");
            var request4 = new ServiceRequest(1004, "Pending", "Awaiting approval", "Power outage in Willow Creek", "Electricity");
            var request5 = new ServiceRequest(1005, "In Progress", "Technician on-site", "Streetlight not working on Pine Street", "Electricity");
            var request6 = new ServiceRequest(1006, "Completed", "Request fulfilled", "Leaking water tank in Birchwood", "Water");
            var request7 = new ServiceRequest(1007, "Pending", "Awaiting approval", "Damaged water pipeline in Elm Park", "Water");
            var request8 = new ServiceRequest(1008, "In Progress", "Scheduled for repair", "Cracked sidewalk outside Library", "Roads");
            var request9 = new ServiceRequest(1009, "Completed", "Issue resolved", "Tree trimming near Oak Lane", "Other");
            var request10 = new ServiceRequest(1010, "Pending", "Awaiting approval", "Overflowing drainage on Maple Street", "Sanitation");
            var request11 = new ServiceRequest(1011, "In Progress", "Inspection in progress", "Road blockage due to construction on Cedar Avenue", "Roads");
            var request12 = new ServiceRequest(1012, "Completed", "Request fulfilled", "Illegal dumping at Riverbank", "Sanitation");

            // Insert all dummy data into the ServiceRequestManager
            serviceRequestManager.InsertServiceRequest(request1);
            serviceRequestManager.InsertServiceRequest(request2);
            serviceRequestManager.InsertServiceRequest(request3);
            serviceRequestManager.InsertServiceRequest(request4);
            serviceRequestManager.InsertServiceRequest(request5);
            serviceRequestManager.InsertServiceRequest(request6);
            serviceRequestManager.InsertServiceRequest(request7);
            serviceRequestManager.InsertServiceRequest(request8);
            serviceRequestManager.InsertServiceRequest(request9);
            serviceRequestManager.InsertServiceRequest(request10);
            serviceRequestManager.InsertServiceRequest(request11);
            serviceRequestManager.InsertServiceRequest(request12);
        }

        /// <summary>
        /// Loads the list of service requests into the DataGrid
        /// </summary>
        private void LoadServiceRequests(List<ServiceRequest> requests)
        {
            dgServiceRequests.ItemsSource = null; // Clear the DataGrid binding
            dgServiceRequests.ItemsSource = requests; // Bind the combined list of requests
        }

        /// <summary>
        /// Handles the event when the user clicks the "Search by ID" button
        /// Searches for a service request by ID and displays the result
        /// </summary>
        private void btnSearchByID_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchByID.Text, out int requestId))
            {
                var result = MainWindow.serviceRequestManager.SearchServiceRequest(requestId);
                if (result != null)
                {
                    LoadServiceRequests(new List<ServiceRequest> { result });
                }
                else
                {
                    MessageBox.Show($"No service request found with ID: {requestId}.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the event when the user clicks the "Sort by Category" button
        /// Sorts the service requests by category and displays the result
        /// </summary>
        private void btnSortByCategory_Click(object sender, RoutedEventArgs e)
        {
            var sortedRequests = MainWindow.serviceRequestManager.SortByCategory();
            LoadServiceRequests(sortedRequests);
        }

        /// <summary>
        /// Handles the event when the user clicks the "Sort by Status" button
        /// Sorts the service requests by status and displays the result
        /// </summary>
        private void btnSortByStatus_Click(object sender, RoutedEventArgs e)
        {
            var sortedRequests = MainWindow.serviceRequestManager.SortByStatus();
            LoadServiceRequests(sortedRequests);
        }

        /// <summary>
        /// Handles the event when the user clicks the "Search by Category" button
        /// Searches for service requests by category and displays the result
        /// </summary>
        private void btnSearchByCategory_Click(object sender, RoutedEventArgs e)
        {
            var category = txtSearchByCategory.Text;
            if (!string.IsNullOrWhiteSpace(category))
            {
                var results = MainWindow.serviceRequestManager.SearchByCategory(category);
                if (results.Any())
                {
                    LoadServiceRequests(results);
                }
                else
                {
                    MessageBox.Show($"No service requests found for category: {category}.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a category to search.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the event when the user clicks the "Sort by Request ID" button
        /// </summary>
        private void btnSortByRequestID_Click(object sender, RoutedEventArgs e)
        {
            var sortedRequests = MainWindow.serviceRequestManager.SortByRequestID();
            LoadServiceRequests(sortedRequests);
        }

        /// <summary>
        /// Handles the event when the user clicks the "Search by Status" button
        /// Searches for service requests by status and displays the result
        /// </summary>
        private void btnSearchByStatus_Click(object sender, RoutedEventArgs e)
        {
            var status = txtSearchByStatus.Text;
            if (!string.IsNullOrWhiteSpace(status))
            {
                var results = MainWindow.serviceRequestManager.SearchByStatus(status);
                if (results.Any())
                {
                    LoadServiceRequests(results);
                }
                else
                {
                    MessageBox.Show($"No service requests found with status: {status}.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a status to search.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the event when the user clicks the "Clear" button
        /// Clears all search fields and resets the DataGrid to display the default prioritized list
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSearchByID.Text = string.Empty;
            txtSearchByCategory.Text = string.Empty;
            txtSearchByStatus.Text = string.Empty;

            RefreshServiceRequests();
        }


        /// <summary>
        /// Handles the event when the user clicks the "Back" button
        /// Navigates back to the main window
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
