using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    /// <summary>
    /// Manages events and announcements, providing functionality for adding, categorizing, and searching events.
    /// </summary>
    public class EventManager
    {
        private Stack<eventsAndAnnouncements> recentEvents; // Stack to store recent events (LIFO)
        private Dictionary<string, List<eventsAndAnnouncements>> categorizedEvents; // Dictionary to categorize events by category
        private HashSet<string> uniqueCategories; // Hash set to store unique event categories

        /// <summary>
        /// Initializes a new instance of the EventManager class.
        /// </summary>
        public EventManager()
        {
            recentEvents = new Stack<eventsAndAnnouncements>(); // Initialize the stack
            categorizedEvents = new Dictionary<string, List<eventsAndAnnouncements>>(); // Initialize the dictionary
            uniqueCategories = new HashSet<string>(); // Initialize the hash set
        }

        /// <summary>
        /// Adds a new event to the event manager.
        /// This event is added to the stack of recent events and categorized by its category.
        /// </summary>
        public void AddEvent(eventsAndAnnouncements newEvent)
        {
            recentEvents.Push(newEvent); // Add the new event to the top of the stack

            // If the category does not exist in the dictionary, create a new list for that category
            if (!categorizedEvents.ContainsKey(newEvent.Category))
            {
                categorizedEvents[newEvent.Category] = new List<eventsAndAnnouncements>();
                uniqueCategories.Add(newEvent.Category); // Add the new category to the uniqueCategories set
            }

            // Add the event to the list of events for the category
            categorizedEvents[newEvent.Category].Add(newEvent); 
        }

        /// <summary>
        /// Retrieve the stack of recent events
        /// </summary>
        public Stack<eventsAndAnnouncements> GetRecentEvents()
        {
            return recentEvents; 
        }

        /// <summary>
        /// Searches for events based on categories, date range, and location.
        /// </summary>
        public List<eventsAndAnnouncements> SearchEvents(HashSet<string> categories, DateTime? startDate, DateTime? endDate, string location = null)
        {
            List<eventsAndAnnouncements> result = new List<eventsAndAnnouncements>();

            // Iterate through each category in the dictionary
            foreach (var category in categorizedEvents.Keys)
            {
                // Include the category if it is in the specified categories or if no categories are specified
                if (categories == null || categories.Contains(category))
                {
                    // Iterate through each event in the category
                    foreach (var ev in categorizedEvents[category])
                    {
                        // Check if the event date is within the specified range 
                        bool dateMatches = (!startDate.HasValue || ev.Date.Date >= startDate.Value.Date) &&
                                           (!endDate.HasValue || ev.Date.Date <= endDate.Value.Date);

                        // Check if the event location matches the specified location
                        bool locationMatches = string.IsNullOrWhiteSpace(location) || ev.Location.Equals(location, StringComparison.OrdinalIgnoreCase);

                        // Add the event if both date and location criteria match
                        if (dateMatches && locationMatches)
                        {
                            result.Add(ev);
                        }
                    }
                }
            }

            return result; // Return the list of events that match the search criteria
        }

    }
}

