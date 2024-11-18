using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    // Represents an event or announcement
    public class eventsAndAnnouncements
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }

        // Constructor to initialize an event or announcement
        public eventsAndAnnouncements(string title, string description, DateTime date, string location, string category)
        {
            Title = title;
            Description = description;
            Date = date;
            Location = location;
            Category = category;
        }

    }
}
