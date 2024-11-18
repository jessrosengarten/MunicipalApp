using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    /// <summary>
    /// Represents a service request with properties such as status, progress description, description, and category
    /// </summary>
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        public int RequestID { get; set; }           
        public string Status { get; set; }           
        public string ProgressDescription { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; } 

        // Graph relationships: a list of adjacent (dependent) requests
        public List<ServiceRequest> Dependencies { get; set; }

        // Priority for Min-Heap
        public int Priority { get; set; } 


        // Constructor
        public ServiceRequest(int requestId, string status, string progressDescription, string description, string category)
        {
            RequestID = requestId;
            Status = status;
            ProgressDescription = progressDescription;
            Description = description;
            Category = category;

            // Assign priority based on status
            switch (status)
            {
                case "Pending":
                    Priority = 1;
                    break;
                case "In Progress":
                    Priority = 2;
                    break;
                case "Completed":
                    Priority = 3;
                    break;
                default:
                    Priority = 4; // Default priority 
                    break;
            }

            Dependencies = new List<ServiceRequest>();
        }

        // Implement IComparable for priority comparisons
        public int CompareTo(ServiceRequest other) 
        {
            return this.RequestID.CompareTo(other.RequestID);
        }


    }
}
