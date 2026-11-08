using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class ServiceRequestBST
    {
        private ServiceRequestNode? root;

        // Add a new service request to the tree
        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            root = InsertNode(root, issue);
        }

        private ServiceRequestNode InsertNode(
            ServiceRequestNode? node,
            Issue issue)
        {
            if (node == null)
                return new ServiceRequestNode(issue);

            int comparison = string.Compare(
                issue.RequestId,
                node.Issue.RequestId,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                node.Left = InsertNode(node.Left, issue);
            }
            else if (comparison > 0)
            {
                node.Right = InsertNode(node.Right, issue);
            }
            else
            {
                throw new InvalidOperationException(
                    "A request with this tracking ID already exists.");
            }

            return node;
        }

        // Find a request using its unique tracking ID
        public Issue? Search(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            ServiceRequestNode? current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    requestId.Trim(),
                    current.Issue.RequestId,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return current.Issue;

                current = comparison < 0
                    ? current.Left
                    : current.Right;
            }

            return null;
        }

        // Retrieve requests in tracking ID order
        public List<Issue> InOrderTraversal()
        {
            List<Issue> results = new List<Issue>();

            TraverseInOrder(root, results);

            return results;
        }

        private void TraverseInOrder(
            ServiceRequestNode? node,
            List<Issue> results)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, results);

            results.Add(node.Issue);

            TraverseInOrder(node.Right, results);
        }
    }
}
