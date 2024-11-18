using System;
using System.Collections.Generic;
using System.Linq;

namespace Municipal_App
{
    /// <summary>
    /// Manages service requests using an AVL tree and a Min-Heap 
    /// </summary>
    public class ServiceRequestManager
    {
        private AVLTree<ServiceRequest> serviceRequestTree; // AVL tree to store service requests
        private MinHeap<ServiceRequest> serviceRequestHeap; // Min-Heap to store service requests 

        /// <summary>
        /// Initializes a new instance of the ServiceRequestManager class
        /// </summary>
        public ServiceRequestManager()
        {
            serviceRequestTree = new AVLTree<ServiceRequest>();
            serviceRequestHeap = new MinHeap<ServiceRequest>();
        }

        /// <summary>
        /// Inserts a new service request into the AVL tree and Min-Heap
        /// </summary>
        public void InsertServiceRequest(ServiceRequest request)
        {
            serviceRequestTree.Insert(request);
            serviceRequestHeap.Insert(request);
        }

        /// <summary>
        /// Searches for a service request with the specified request ID
        /// </summary>
        public ServiceRequest SearchServiceRequest(int requestId)
        {
            var dummyRequest = new ServiceRequest(requestId, "", "", "", ""); // Create a dummy request with the specified ID
            return serviceRequestTree.Search(dummyRequest);
        }

        /// <summary>
        /// Gets all service requests stored in the AVL tree
        /// </summary>
        public List<ServiceRequest> GetAllServiceRequests()
        {
            return serviceRequestTree.GetAllElements();
        }

        /// <summary>
        /// Gets the highest priority service request from the Min-Heap
        /// </summary>
        public ServiceRequest GetHighestPriorityRequest()
        {
            return serviceRequestHeap.Peek();
        }

        /// <summary>
        /// Gets all service requests sorted by priority from the Min-Heap
        /// </summary>
        public List<ServiceRequest> GetRequestsByPriority()
        {
            return serviceRequestHeap.ToList(); // Returns the Min-Heap in sorted order
        }

        /// <summary>
        /// Processes the highest priority service request by removing it from the Min-Heap
        /// </summary>
        public ServiceRequest ProcessHighestPriorityRequest()
        {
            var highestPriority = serviceRequestHeap.ExtractMin();

            var dummyRequest = new ServiceRequest(highestPriority.RequestID, "", "", "", "");
            serviceRequestTree.Search(dummyRequest); 

            return highestPriority;
        }
        /// <summary>
        /// Sorts the service requests by status
        /// </summary>
        public List<ServiceRequest> SortByStatus()
        {
            return serviceRequestTree.GetAllElements()
                .OrderBy(request => request.Status)
                .ToList();
        }

        /// <summary>
        /// Sorts the service requests by category
        /// </summary>
        public List<ServiceRequest> SortByCategory()
        {
            return serviceRequestTree.GetAllElements()
                .OrderBy(request => request.Category)
                .ToList();
        }

        /// <summary>
        /// Sorts the service requests by request ID
        /// </summary>
        public List<ServiceRequest> SortByRequestID()
        {
            return serviceRequestTree.GetAllElements()
                .OrderBy(request => request.RequestID)
                .ToList();
        }

        /// <summary>
        /// Searches for service requests by category
        /// </summary>
        public List<ServiceRequest> SearchByCategory(string category)
        {
            return serviceRequestTree.GetAllElements()
                .Where(request => request.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Searches for service requests by status
        /// </summary>
        public List<ServiceRequest> SearchByStatus(string status)
        {
            return serviceRequestTree.GetAllElements()
                .Where(request => request.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}
