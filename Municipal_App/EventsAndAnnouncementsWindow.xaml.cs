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
using System.Xml.Serialization;


namespace Municipal_App
{
    /// <summary>
    /// Interaction logic for the Events and Announcements Window.
    /// This window allows users to view, search, and filter events or announcements based on category and date.
    /// </summary>
    public partial class EventsAndAnnouncementsWindow : Window
    {
        private EventManager eventManager; // Event manager to handle events and announcements
        private Dictionary<string, int> searchCounts; // Dictionary to store search counts for each category

        /// <summary>
        /// Shows the Events and Announcements Window.
        /// </summary>
        public EventsAndAnnouncementsWindow()
        {
            InitializeComponent();
            eventManager = new EventManager();
            searchCounts = new Dictionary<string, int>();

            // Load dummy events into the event manager
            foreach (var dummyEvent in DummyEventData.GetDummyEvents()) 
            {
                eventManager.AddEvent(dummyEvent);
            }

            // Load recent events into the DataGrid
            LoadEvents(new Stack<eventsAndAnnouncements>(eventManager.GetRecentEvents()));
            LoadRecommendations();
        }

        /// <summary>
        /// Load a stack of events into the DataGrid.
        /// </summary>
        private void LoadEvents(Stack<eventsAndAnnouncements> events)
        {
            dgEvents.ItemsSource = events; 
        }

        /// <summary>
        /// Filter events based on the selected category and date.
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = (cbCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? selectedDate = dpSearchByDate.SelectedDate;

            HashSet<string> categories = null;

            // Add selected category to the filter
            if (!string.IsNullOrEmpty(selectedCategory)) 
            {
                categories = new HashSet<string> { selectedCategory };

                // Update the search frequency for the selected category
                if (searchCounts.ContainsKey(selectedCategory))
                {
                    searchCounts[selectedCategory]++;
                }
                else
                {
                    searchCounts[selectedCategory] = 1;
                }
            }

            // Define the date range for the search using selected date as both start ad end date
            DateTime? startDate = selectedDate;
            DateTime? endDate = selectedDate;

            // Perform the search based on the selected category and date
            List<eventsAndAnnouncements> result = eventManager.SearchEvents(categories, startDate, endDate);

            if (result.Count > 0)
            { 
                dgEvents.ItemsSource = result;
                UpdateRecommendations();
            }
            else
            {
                // Display a message if no events are found
                MessageBox.Show("No events found for your search attempt.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                dgEvents.ItemsSource = null; // Clear the DataGrid
            }
        }


        /// <summary>
        /// Navigate back to the main window
        /// </summary>    
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Clear the search filters and reload all recent events.
        /// </summary>      
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dpSearchByDate.SelectedDate = null;
            cbCategory.SelectedIndex = -1;
            LoadEvents(eventManager.GetRecentEvents()); // Reload all recent events when cleared
        }


        /// <summary>
        /// Update the recommendations based on the search counts.
        /// Display the top 5 most searched categories as recommendations.
        /// </summary>
        private void UpdateRecommendations()
        {
            // Get the top 5 most searched categories
            var popularCategories = searchCounts
                .OrderByDescending(x => x.Value)
                .Take(5)
                .ToList();

            // Clear any existing recommendations
            lbRecommendations.Items.Clear();

            // Add popular categories to the ListBox
            foreach (var category in popularCategories) 
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = category.Key,
                    ToolTip = $"Searched {category.Value} times",
                    FontSize = 14,
                    Foreground = Brushes.Black
                };

                lbRecommendations.Items.Add(item);
            }
        }

        /// <summary>
        /// Load initial recommendations based on existing search patterns
        /// </summary>
        private void LoadRecommendations()
        {
            // Clear any existing recommendations - they will be dynamically updated
            lbRecommendations.Items.Clear();
            UpdateRecommendations(); 
        }

        /// <summary>
        /// Provides a list of dummy events and announcements 
        /// </summary>
        public static class DummyEventData
        {
            public static List<eventsAndAnnouncements> GetDummyEvents()
            {
                return new List<eventsAndAnnouncements>
        {
            new eventsAndAnnouncements("Music Festival", "A fun outdoor music festival", new DateTime(2024, 10, 30), "Main Park", "Music"),
            new eventsAndAnnouncements("Town Hall Meeting", "Community discussion on local issues", new DateTime(2024, 11, 2), "Town Hall", "Meetings"),
            new eventsAndAnnouncements("Art Exhibition", "Exhibition of local artists", new DateTime(2024, 11, 7), "Art Gallery", "Art"),
            new eventsAndAnnouncements("Tech Summit", "Tech innovations and talks", new DateTime(2024, 11, 4), "Convention Center", "Technology"),
            new eventsAndAnnouncements("Yoga Workshop", "Zen yoga class", new DateTime(2024, 11, 12), "Health Studio", "Health"),
            new eventsAndAnnouncements("Cultural Fair", "Local food and culture exhibition", new DateTime(2024, 11, 9), "City Square", "Culture"),
            new eventsAndAnnouncements("Soccer Game", "Soccer game in the park", new DateTime(2024, 11, 5), "Sports Park", "Sports"),
            new eventsAndAnnouncements("Baking Classes", "Learn how to make cookies", new DateTime(2024, 11, 2), "Kitchen on Main", "Food"),
            new eventsAndAnnouncements("Guitar Concert", "A group of 4 guitarists playing their music", new DateTime(2024, 11, 30), "Main Park", "Music"),
            new eventsAndAnnouncements("Student Art Show", "Exhibition of student art", new DateTime(2024, 12, 4), "Art Gallery", "Art"),
            new eventsAndAnnouncements("Tech Support", "Tech support for people needing help", new DateTime(2024, 11, 15), "Convention Center", "Technology"),
            new eventsAndAnnouncements("Pilates Class", "45 minute pilates class", new DateTime(2024, 11, 19), "Health Studio", "Health"),
            new eventsAndAnnouncements("Cultural Fair", "Local food and culture exhibition", new DateTime(2024, 11, 9), "City Square", "Culture"),
            new eventsAndAnnouncements("Frisbee Game", "Frisbee game for all", new DateTime(2024, 12, 5), "Sports Park", "Sports"),
            new eventsAndAnnouncements("Bread Workshop", "Taste and learn about different bread", new DateTime(2024, 11, 2), "Kitchen on Main", "Food")
        };
            }
        }
    }
}
