# Municipal Service Manager

A desktop application designed to streamline municipal service delivery, enabling residents to report issues, track service requests, and stay informed about local events.

## Features

- Report Municipal Issues  
  Report problems like water leaks, potholes, or power outages with detailed descriptions and optional image attachments.

- Track Service Requests  
  Search, filter, and sort service requests by ID, category, or status. Monitor updates and progress in real time.

- Discover Local Events  
  Browse upcoming municipal events and announcements. Personalized recommendations based on search behavior.



## Tech Stack

- Language: C#  
- Framework: .NET Framework 4.8  
- IDE: Visual Studio Community 2019  
- Target Platform: Windows Desktop



## Installation

1. Download & Extract  
   Unzip the project folder.

2. Open in Visual Studio  
   Open the `.sln` file in Visual Studio 2019.

3. Run the App  
   Press `Start` to build and launch the application.



## Key Implementations

### Min-Heap
Used to dynamically sort service requests by status, category, or ID with `O(log n)` insertion and extraction. Keeps the interface responsive even with large datasets.

### AVL Tree
Stores service requests in a balanced binary search tree sorted by Request ID, enabling fast search and ordered retrieval.

### Dictionary
Maps Request IDs to request details for quick lookups (`O(1)`), ensuring fast and accurate access.

### Doubly Linked List
Temporarily holds newly reported issues in the order submitted. Supports fast sequential processing before they're formally added.



## Why This Project?

This project explores how efficient data structures can improve usability in real-world systems — especially where performance and organization are critical, like municipal service management.

The application is designed to be:
- Responsive  
- Well-structured  
- Scalable  
- User-friendly  

