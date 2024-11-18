using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Municipal_App
{
    /// <summary>
    /// Interaction logic for ReportIssuesWindow.xaml
    /// </summary>
    public partial class ReportIssuesWindow : Window
    {
        // Use the generic doubly linked list to store issues
        public static DoublyLinkedList<Issue> reportedIssues = new DoublyLinkedList<Issue>();

        private string mediaPath = "";

        public ReportIssuesWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Collect form data and create a new Issue object
            string location = txtLocation.Text;
            string category = cmbCategory.Text;
            string description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim();
            string mediaPath = this.mediaPath;

            if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please complete all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Generate a unique ID for the service request
            int newRequestID = GenerateUniqueRequestID();


            string progressDescription = "Issue reported and awaiting processing"; // Define progress description


            // Convert the Issue to a ServiceRequest with status "Pending"
            ServiceRequest newRequest = new ServiceRequest(newRequestID, "Pending", progressDescription, description, category);
            MainWindow.serviceRequestManager.InsertServiceRequest(newRequest);

            MessageBox.Show($"Your issue has been reported successfully. Request ID: {newRequestID}");

            // Reset the form
            txtLocation.Clear();
            rtbDescription.Document.Blocks.Clear();
            cmbCategory.SelectedIndex = -1;
            this.mediaPath = "";
            txtMediaPath.Text = "No media attached.";
            progressIssueCompletion.Value = 0;

            // Navigate back to the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }



        // Generate a unique ID for the new service request
        private int GenerateUniqueRequestID()
        {
            Random random = new Random();
            int newID;

            // Ensure the generated ID does not exist in the current requests
            do
            {
                newID = random.Next(10000, 99999); // Generate a random 5-digit number
            } while (MainWindow.serviceRequestManager.SearchServiceRequest(newID) != null);

            return newID;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.docx"
            };
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                mediaPath = dlg.FileName;
                MessageBox.Show("Media Attached: " + mediaPath);
                txtMediaPath.Text = mediaPath;
                UpdateProgress();
            }
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 25;

            if (cmbCategory.SelectedItem != null)
                progress += 25;

            if (!string.IsNullOrWhiteSpace(new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text))
                progress += 25;

            if (!string.IsNullOrWhiteSpace(mediaPath))
                progress += 25;

            progressIssueCompletion.Value = progress;
        }

        private void txtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProgress();
        }

    }
}
