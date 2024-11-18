using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    /// <summary>
    /// Represents an issue with properties such as location, category, description, and media attachment path
    /// </summary>
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaAttachmentPath { get; set; }

        // Constructor to initialize an Issue
        public Issue(string location, string category, string description, string mediaAttachmentPath)
        {
            Location = location;
            Category = category;
            Description = description;
            MediaAttachmentPath = mediaAttachmentPath;
        }
    }
}
