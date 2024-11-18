********************************************************************
			Municipal Application

********************************************************************
			  PROG7312 POE	
			   ST10153811
			 Jess Rosengarten

********************************************************************


************************************************************************
CONTENT:
************************************************************************

1) Overview 
2) System requirements
3) Installing the software
4) Using the application
5) Data Structures



************************************************************************
1) OVERVIEW
************************************************************************

The Municipal Application is a desktop program designed to improve municipal service delivery. 

Users can:
	- Report Issues: Submit municipal issues with relevant details.
	- Track Service Requests: View the status of service requests, sort and search through them.
	- View Events and Announcements: Search and filter through local events, 
		with recommendations based on user behavior.

The application incorporates advanced data structures to efficiently handle user input, 
	improve data organization, and optimize response times.




************************************************************************
2) SYSTEM REQUIREMENTS
************************************************************************

1. The system must run on one of the following operating systems:
	
	- Microsft Windows 10

2. Any of the following Microsoft operating systems:

	- MS-DOS
	- Windows 3.1
	- Windows NT 3.51
	- Windows 95
	- Windows 98
	- Windows NT 4.0

3. The system should contain at least the minimum system memory required by the operating system.

4. The following additional software is required:

	- Microsoft Visual Studio Community 2019 Version 16.9.4
        - Microsoft.NET Framework Version 4.8.04084 


************************************************************************
3) INSTALLING THE SOFTWARE
************************************************************************

1. Unzip the folder 
	- Right click on the folder and select 'Extract All'

2. Open the file in Visual Studio
	- Open the folder
	- Select and open the file

3. Click RUN to compile and run the program



************************************************************************
4. USING THE APPLICATION
************************************************************************

1. Main Menu

************************************************************************

From the main menu, users can:
	- Report Issues: Submit municipal issues.
	- Local Events and Announcements: View and filter through upcoming events.
	- Service Request Status: Track municipal service requests.

************************************************************************

2. Report Issues

************************************************************************

1) The user can fill in the following details to report an issue:
	- Location: Specify the issue's location.
	- Category: Select a category from the dropdown (e.g., Roads, Water, Sanitation).
	- Description: Add a detailed description of the issue.
	- Attach Media: Optionally upload an image or document for reference.

2) A Progress bar dynamically updates as fields are completed.

3) Click "Submit" to send the report. A unique Request ID is generated, 
and the issue is added to the Service Request Status list.

************************************************************************
3. Local Events and Announcements

************************************************************************


1) Search and Filter:
	- Search events by Category or Date.

2) Recommendations:
	- Displays frequently searched categories dynamically.

3) View Events:
	- Details such as event name, date, location, and description are displayed.

************************************************************************

4. Service Request Status

************************************************************************

1) View Requests:
	- See all service requests, including dummy data and user submissions.

2) Search Options:
	- Search requests by Request ID, Category, or Status.

3) Sort Requests:
	- Sort service requests by Status, Category, or Request ID.

4) Clear Filters:
	- Reset all filters to view the complete list of service requests.

************************************************************************
5. DATA STRUCTURES
************************************************************************

1. Min-Heap


Purpose: 
	- To manage the sorting and searching requests based on various criteria
	- It provides efficient operations for sorting requests by criteria such as Request ID, Category, or Status.

Role and Contribution:

	- The Min-Heap allows efficient sorting and dynamic retrieval of service requests for better 
	organization and visibility:

		- Sorting by Request ID: Ensures requests are displayed in ascending numerical order, 
			aiding in easy tracking and identification.

		- Sorting by Status: Groups requests into "Pending," "In Progress," and "Completed" categories 
			for streamlined monitoring.

		- Sorting by Category: Organizes requests into categories like "Electricity," "Roads," or "Sanitation" 
	
	- Example:
		- A user selects "Sort by Category."
		- The Min-Heap dynamically reorders service requests to group similar categories together in minimal time.	


Efficiency:
	- Insertion and Extraction: 
		- Operates in O(log n) time, making the Min-Heap highly efficient for maintaining 
		sorted structures even with large datasets.

	- Sorting and Searching:
		- The heap ensures that sorting operations dynamically reflect changes 
		without requiring a complete reorganization.

Advantages:
	- Dynamic Flexibility: Automatically adjusts its structure when new requests 
		are added or existing ones are modified.

	- Efficient Retrieval: Enables users to quickly sort or filter service requests based on desired criteria.

	- Scalable: Handles large numbers of requests efficiently, ensuring fast and responsive 
		operations regardless of dataset size.

************************************************************************

2. AVL Tree
Purpose: 
	- The AVL Tree is used to store and retrieve service requests while maintaining a sorted order by Request ID.

	- It ensures that search and retrieval operations remain efficient and consistent, 
		even as the number of requests grows.


Role and Contribution:
	- The AVL Tree organizes all service requests, enabling efficient search and traversal.

	- It ensures that the Service Request Status page can retrieve sorted data by Request ID 
		without requiring additional sorting operations.

	- Example:
  		- Searching for a request with Request ID 1005 involves traversing the tree, 
		which operates in O(log n) time due to the tree's balanced nature.

Efficiency:
	- The AVL Tree maintains balance by rotating nodes during insertions and deletions, ensuring consistent performance.

	-  Insertion and Deletion: Operate in O(log n) time, even as the dataset increases. 

	- In-Order Traversal: Retrieves all requests in sorted order efficiently.

Advantages:
	- Scalable Performance: The AVL Tree prevents imbalances that could slow down search or insertion operations.

	- Structured Organization: Automatically keeps data ordered, making retrieval and traversal straightforward.

	- Resilience: Handles large datasets effectively without sacrificing speed or accuracy.


************************************************************************

3. Dictionary

Purpose: 
	- To store and manage service requests in key-value pairs for quick lookups.


Role and Contribution:
	- A dictionary maps Request IDs to service request objects, enabling efficient retrieval during search operations.

	- Example:
  		- Searching for Request ID 1001 directly retrieves the corresponding service request in O(1) time.

	- Support for Sorting and Filtering: Works in conjunction with other data structures to facilitate efficient operations.
		

Efficiency:
	- Lookup Operations: Operate in O(1) time, making the dictionary the fastest method for 
		retrieving specific service requests.

	- Insertion: Adds new key-value pairs in constant time, ensuring smooth integration of new requests.


Advantages:
	- Speed: Provides unparalleled efficiency for specific searches, ensuring quick access to service request details.

	- Simplicity: Its key-value pairing mechanism is easy to implement and highly effective.

	- Versatility: Can be used in tandem with other data structures to improve overall system performance.

************************************************************************

4. Doubly Linked List

Purpose: 
	- The Doubly Linked List is used to temporarily store user-reported issues for sequential processing.
	- It allows traversal in both forward and backward directions, enhancing flexibility in issue management.


Role and Contribution:
	- The Doubly Linked List enables efficient handling of user-submitted issues before they are 
	added to the AVL Tree or Min-Heap:

		- Sequential Processing: Maintains the order in which issues are submitted, 
			ensuring fairness and accuracy.

		- Dynamic Modifications: Supports adding or removing issues at either end 
			without disrupting the entire structure.
	- Example: 
		- A user reports an issue about "Broken Pipes."
		- The issue is added to the linked list, from where it can be reviewed and processed sequentially.



Efficiency:
	- Insertions and Deletions: Operate in O(1) time at either end of the list, making it ideal for temporary storage.
	- Traversal: Supports O(n) traversal for reviewing issues, ensuring no data is overlooked.


Advantages:

	- Ease of Use: Adding or removing issues is straightforward and efficient, requiring minimal computational effort.
	- Sequential Access: The structure is ideal for handling user submissions in the order they arrive, 
	ensuring no data is lost or overlooked.

************************************************************************
CONCLUSION
************************************************************************

The Municipal Application leverages advanced data structures to enhance its functionality and efficiency.

1) Min-Heap: Dynamically sorts and searches service requests.
2) AVL Tree: Ensures structured and efficient management of service requests.
3) Dictionary: Provides lightning-fast access to specific requests.
4) Doubly Linked List: Manages user-reported issues seamlessly.

Together, these structures ensure the application remains responsive, scalable, and user-friendly, even as data volumes increase.