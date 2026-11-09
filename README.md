# Municipal Services Application

## 1. Project Overview

The Municipal Services Application is a Windows Forms application developed using C# and .NET. Its purpose is to provide residents with a platform where they can report municipal issues, view local events and announcements, and track the progress of submitted service requests.

The application was developed in three parts, with each part introducing additional functionality and data structures.

The main features include:

- **Report Issues:** Residents can submit municipal issues by providing their location, selecting a category, describing the problem and attaching supporting files.
- **Local Events and Announcements:** Residents can browse upcoming events, search for announcements and filter events according to their preferences.
- **Service Request Status:** Residents can view submitted requests, search using a unique tracking ID and monitor the status of their requests.

The application also demonstrates how advanced data structures and algorithms can be used to organise information, improve searching and manage municipal service requests.

## 2. Technologies Used

The application was developed using the following technologies:

- **C#:** The main programming language used to implement the application.
- **Windows Forms:** Used to develop the graphical user interface.
- **.NET:** Provides the framework required to build and run the application.
- **Visual Studio:** Used for development, debugging and testing.
- **Generic Collections:** Used to implement lists, dictionaries, queues, stacks, trees and graphs.

## 3. How to Build and Run the Application

### Requirements

Before running the application, ensure that the following are installed:

- Visual Studio with the .NET desktop development workload.
- .NET 9 SDK and runtime.
- Windows operating system.

### Steps

1. Open Visual Studio.
2. Select **Open a project or solution**.
3. Navigate to the project folder and open the `.sln` file.
4. Allow Visual Studio to load the solution and restore any required dependencies.
5. Select **Build > Build Solution** to compile the application.
6. Press **F5** or select **Start** to run the application.

Once the application starts, the main menu will display the three available features.

## 4. How to Use the Application

### 4.1 Report Issues

The Report Issues feature allows residents to submit problems affecting their communities.

To submit an issue:

1. Select **Report Issues** from the main menu.
2. Enter the location where the problem occurred.
3. Select the relevant issue category.
4. Provide a description of the problem.
5. Attach a supporting file if necessary.
6. Submit the report.

Once submitted, the application generates a unique tracking ID that can be used to find the request later.

For example, a resident can report a damaged road by selecting the appropriate category, entering the affected location and describing the problem.

### 4.2 Local Events and Announcements

This feature allows residents to view municipal events and announcements.

Users can:

- Browse available events.
- Search for events using keywords.
- Filter events by date or category.
- View event details.
- Receive event recommendations.

The application uses several data structures to organise events and support searching and filtering.

For example, a resident looking for community events can select a category or enter a keyword to narrow down the displayed results.

### 4.3 Service Request Status

The Service Request Status feature allows users to monitor municipal issues that have already been reported.

Users can:

- View submitted service requests.
- Search for requests using their unique tracking IDs.
- View the category, location, submission date and current status.
- View requests according to their priority.
- Explore municipal network connections using graph algorithms.

Service requests follow three statuses:

- **Submitted:** The request has been received.
- **InProgress:** Processing of the request has started.
- **Resolved:** The reported issue has been addressed.

The application also includes demonstration administrative controls for processing priority requests and marking requests as resolved.

These controls are not protected by authentication in the current version.

## 5. Data Structures and Algorithms

### 5.1 Lists

A `List<Issue>` stores submitted municipal issues.

Lists allow the application to add new issues and retrieve existing records. They also provide the underlying collection used to display service requests.

### 5.2 Binary Search Tree (BST)

A Binary Search Tree organises service requests according to their unique tracking IDs.

Each node contains a request and can have a left and right child.

The BST supports:

- Inserting new service requests.
- Searching for requests using their tracking IDs.
- Retrieving requests in sorted order through in-order traversal.

For example, when a resident enters a tracking ID, the application searches the BST to locate the matching request.

The average search time is O(log n) for a reasonably balanced BST, although the worst case is O(n) when the tree becomes unbalanced.

### 5.3 AVL Tree

An AVL Tree is a self-balancing Binary Search Tree.

Unlike a regular BST, an AVL tree maintains balance after insertions by performing rotations when necessary.

The application uses an AVL tree to demonstrate efficient searching while maintaining a balanced structure.

Its main benefits include:

- Maintaining tree balance.
- Supporting efficient searching.
- Preventing the tree from becoming excessively unbalanced.

AVL tree searching and insertion have O(log n) worst-case time complexity.

### 5.4 Red-Black Tree

A Red-Black Tree is another type of self-balancing Binary Search Tree.

It uses node colours and rotation rules to maintain a balanced structure.

The application implements a left-leaning red-black tree to organise service requests by their tracking IDs.

This structure demonstrates another approach to balancing trees while supporting efficient insertion and searching.

Red-black trees provide O(log n) worst-case searching and insertion.

### 5.5 Heap and Priority Queue

A priority queue is used to organise municipal requests according to their urgency.

The application uses a heap-backed `PriorityQueue<Issue, int>`.

Requests are assigned priorities based on their categories:

- Electricity: High priority.
- Water: Medium priority.
- Other categories: Low priority.

When the processing function is selected, the highest-priority pending request is removed from the queue and its status changes to `InProgress`.

For example, an electricity-related request will be processed before a lower-priority road-related request.

The heap allows the highest-priority request to be retrieved efficiently.

### 5.6 Graphs

A graph represents connections between municipal locations.

The application uses an adjacency list to store these connections.

The demonstration network includes locations such as:

- Civic Centre
- Ward 1
- Ward 2
- Water Depot
- Power Station

Graphs are useful for representing connected locations and analysing relationships between different municipal service areas.

### 5.7 Breadth-First Search (BFS)

Breadth-First Search visits connected locations level by level.

It uses a queue to manage the order in which locations are visited.

In the application, BFS allows users to explore the municipal network starting from a selected location.

For example, starting at Civic Centre, BFS visits its directly connected locations before moving to locations further away.

BFS has a time complexity of O(V + E), where V represents vertices and E represents edges.

### 5.8 Depth-First Search (DFS)

Depth-First Search explores one path through the graph before returning to visit other paths.

The application uses a recursive DFS implementation.

Users can select a starting location and view the order in which connected locations are visited.

DFS also has a time complexity of O(V + E).

### 5.9 Minimum Spanning Tree (Kruskal's Algorithm)

The application uses Kruskal's algorithm to calculate a Minimum Spanning Tree.

A Minimum Spanning Tree connects all vertices in a connected, weighted graph using the minimum total edge weight without creating cycles.

Kruskal's algorithm works by:

1. Sorting the connections by weight.
2. Selecting the lowest-weight connection.
3. Checking whether the connection creates a cycle.
4. Adding connections until all locations are connected.

The application uses a disjoint-set approach to detect cycles.

In the sample municipal network, the Minimum Spanning Tree contains four connections with a total weight of 10.

These weights are demonstration values and do not represent actual municipal distances or costs.

## 6. Additional Data Structures Used for Events

The Local Events and Announcements feature also demonstrates the use of:

- **SortedDictionary:** Organises events according to their dates.
- **Dictionary:** Groups events by category and supports lookup operations.
- **HashSet:** Stores unique event categories.
- **Queue:** Demonstrates first-in, first-out event processing.
- **Stack:** Stores recent searches.
- **PriorityQueue:** Organises upcoming events according to their dates.

These structures demonstrate different ways of storing and managing information depending on the requirements of a particular feature.

## 7. Testing

The application was tested manually during development.

Testing included:

- Submitting issues and generating tracking IDs.
- Searching for existing and non-existing requests.
- Checking BST, AVL and red-black tree functionality.
- Confirming that AVL and red-black tree validation methods returned successful results.
- Checking priority ordering for electricity, water and other categories.
- Updating request statuses from Submitted to InProgress and Resolved.
- Performing BFS and DFS traversals.
- Calculating the Minimum Spanning Tree and confirming its total weight was 10.
- Navigating between the three main application features.

The tested features worked as expected during development.

## 8. Current Limitations

Although the application demonstrates the required functionality, it has some limitations:

- Data is stored in memory and is not retained after the application closes.
- The application does not currently use a database.
- Administrative actions are demonstrations and are not restricted through authentication.
- The municipal graph uses fictional locations and connection weights.
- The application does not communicate with actual municipal service systems.
- The priority rules are predefined and are not based on real municipal service-level agreements.

## 9. Possible Future Improvements

Future improvements could include:

- Integrating SQL Server to store service requests and events permanently.
- Using Entity Framework Core to manage database operations.
- Adding authentication and role-based access control.
- Allowing residents to receive notifications when their request status changes.
- Integrating mapping services to display actual municipal locations.
- Introducing configurable priority rules for service requests.
- Adding automated tests to improve reliability.

## 10. Conclusion

The Municipal Services Application demonstrates how C# Windows Forms and different data structures can be combined to solve practical problems.

Through the three development stages, the application progressed from basic issue reporting to event management and advanced service request tracking.

The project provided practical experience in implementing trees, heaps, graphs and traversal algorithms, while also improving my understanding of how to select appropriate data structures for different software development requirements.
