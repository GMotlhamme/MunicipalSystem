using MunicipalDataSystem.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.Services
{
    public class IssueService
    {

        private readonly List<Issue> reportedIssues = new List<Issue>();

        private readonly ServiceRequestBST requestTree = new ServiceRequestBST();

        private readonly ServiceRequestAVL avlTree = new ServiceRequestAVL();

        private readonly ServiceRequestRedBlackTree redBlackTree = new ServiceRequestRedBlackTree();
        private readonly ServiceRequestHeap requestHeap = new ServiceRequestHeap();

        private readonly MunicipalGraph municipalGraph = new();

        public IssueService()
        {
            municipalGraph.AddWeightedConnection("Civic Centre", "Ward 1", 4);
            municipalGraph.AddWeightedConnection("Civic Centre", "Ward 2", 3);
            municipalGraph.AddWeightedConnection("Ward 1", "Water Depot", 2);
            municipalGraph.AddWeightedConnection("Ward 1", "Power Station", 5);
            municipalGraph.AddWeightedConnection("Ward 2", "Power Station", 1);
        }

        // Add a submitted issue to the list and BST
        public void AddIssue(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            if (requestTree.Search(issue.RequestId) != null)
                throw new InvalidOperationException(
                    "A request with this tracking ID already exists.");


            requestTree.Insert(issue);
            avlTree.Insert(issue);
            redBlackTree.Insert(issue);

            requestHeap.Insert(issue);

            reportedIssues.Add(issue);
        }
        // View the most urgent service request
        public Issue? GetHighestPriorityRequest()
        {
            return requestHeap.Peek();
        }

        // Process the most urgent request
        public Issue? ProcessHighestPriorityRequest()
        {
            Issue? issue = requestHeap.RemoveHighestPriority();

            if (issue == null)
                return null;

            // Update the request's status when processing begins
            issue.Status = IssueStatus.InProgress;

            return issue;
        }

        public bool ResolveRequest(string requestId)
        {
            Issue? issue = requestTree.Search(requestId);

            if (issue == null)
                return false;

            if (issue.Status != IssueStatus.InProgress)
                return false;

            issue.Status = IssueStatus.Resolved;

            return true;
        }
        public Issue? GetIssueByIdRedBlack(string requestId)
        {
            return redBlackTree.Search(requestId);
        }

        public bool IsRedBlackTreeValid()
        {
            return redBlackTree.IsValidRedBlackTree();
        }

        public Issue? GetIssueByIdAVL(string requestId)
        {
            return avlTree.Search(requestId);
        }

        public bool IsAVLTreeBalanced()
        {
            return avlTree.IsBalanced();
        }

        // Retrieve all submitted issues
        public List<Issue> GetAllIssues()
        {
            return reportedIssues;
        }

        // Search for an issue using the BST
        public Issue? GetIssueById(string requestId)
        {
            return requestTree.Search(requestId);
        }

        // Retrieve issues sorted by tracking ID
        public List<Issue> GetIssuesSortedById()
        {
            return requestTree.InOrderTraversal();
        }

        public void AddServiceLocation(string location)
        {
            municipalGraph.AddLocation(location);
        }

        public void ConnectServiceLocations(string locationA, string locationB)
        {
            municipalGraph.AddConnection(locationA, locationB);
        }

        public List<string> GetConnectedLocationsBFS(string startLocation)
        {
            return municipalGraph.BreadthFirstSearch(startLocation);
        }

        public List<string> GetConnectedLocationsDFS(string startLocation)
        {
            return municipalGraph.DepthFirstSearch(startLocation);
        }

        public List<WeightedConnection> GetMinimumSpanningTree()
        {
            return municipalGraph.GetMinimumSpanningTree();
        }

        public List<string> GetServiceLocations()
        {
            return municipalGraph.GetLocations();
        }
    }
}
