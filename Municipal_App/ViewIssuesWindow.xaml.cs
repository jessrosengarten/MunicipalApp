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


namespace Municipal_App
{
    /// <summary>
    /// Interaction logic for ViewIssuesWindow.xaml
    /// </summary>
    public partial class ViewIssuesWindow : Window
    {
        private DoublyLinkedList<Issue>.Node currentIssue;

        public ViewIssuesWindow()
        {
            InitializeComponent();
            currentIssue = ReportIssuesWindow.reportedIssues.GetFirstNode();
            DisplayIssue(currentIssue?.Data); // Display the first issue if exists
        }

        private void DisplayIssue(Issue issue)
        {
            if (issue != null)
            {
                txtLocation.Text = issue.Location;
                txtCategory.Text = issue.Category;
                txtDescription.Text = issue.Description;

                if (!string.IsNullOrEmpty(issue.MediaAttachmentPath))
                {
                    if (issue.MediaAttachmentPath.EndsWith(".jpg") || issue.MediaAttachmentPath.EndsWith(".png") || issue.MediaAttachmentPath.EndsWith(".jpeg"))
                    {
                        imgMedia.Source = new BitmapImage(new Uri(issue.MediaAttachmentPath));
                        txtMediaPath.Text = "File Path: " + issue.MediaAttachmentPath;
                    }
                    else
                    {
                        MessageBox.Show("File Path: " + issue.MediaAttachmentPath);
                    }
                }
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentIssue != null && currentIssue.Next != null)
            {
                currentIssue = currentIssue.Next;
                DisplayIssue(currentIssue.Data);
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (currentIssue != null && currentIssue.Previous != null)
            {
                currentIssue = currentIssue.Previous;
                DisplayIssue(currentIssue.Data);
            }
        }

        private void btnBackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

