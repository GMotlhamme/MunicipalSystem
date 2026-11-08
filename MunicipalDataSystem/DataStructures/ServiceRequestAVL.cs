using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    //This class handles insertion, searching, and automatic balancing.
    public class ServiceRequestAVL
    {
        private AVLNode? root;

        private int GetHeight(AVLNode? node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(AVLNode? node)
        {
            return node == null
                ? 0
                : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private void UpdateHeight(AVLNode node)
        {
            node.Height = 1 + Math.Max(
                GetHeight(node.Left),
                GetHeight(node.Right));
        }

        // Rotate a subtree to the right
        private AVLNode RotateRight(AVLNode node)
        {
            AVLNode newRoot = node.Left!;

            node.Left = newRoot.Right;
            newRoot.Right = node;

            UpdateHeight(node);
            UpdateHeight(newRoot);

            return newRoot;
        }

        // Rotate a subtree to the left
        private AVLNode RotateLeft(AVLNode node)
        {
            AVLNode newRoot = node.Right!;

            node.Right = newRoot.Left;
            newRoot.Left = node;

            UpdateHeight(node);
            UpdateHeight(newRoot);

            return newRoot;
        }

        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            root = InsertNode(root, issue);
        }

        private AVLNode InsertNode(AVLNode? node, Issue issue)
        {
            if (node == null)
                return new AVLNode(issue);

            int comparison = string.Compare(
                issue.RequestId,
                node.Issue.RequestId,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
                node.Left = InsertNode(node.Left, issue);
            else if (comparison > 0)
                node.Right = InsertNode(node.Right, issue);
            else
                throw new InvalidOperationException(
                    "A request with this tracking ID already exists.");

            UpdateHeight(node);

            int balance = GetBalance(node);

            // Left-left case
            if (balance > 1 &&
                string.Compare(
                    issue.RequestId,
                    node.Left!.Issue.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                return RotateRight(node);
            }

            // Right-right case
            if (balance < -1 &&
                string.Compare(
                    issue.RequestId,
                    node.Right!.Issue.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                return RotateLeft(node);
            }

            // Left-right case
            if (balance > 1 &&
                string.Compare(
                    issue.RequestId,
                    node.Left!.Issue.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                node.Left = RotateLeft(node.Left!);
                return RotateRight(node);
            }

            // Right-left case
            if (balance < -1 &&
                string.Compare(
                    issue.RequestId,
                    node.Right!.Issue.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                node.Right = RotateRight(node.Right!);
                return RotateLeft(node);
            }

            return node;
        }

        // Search for a request using its tracking ID
        public Issue? Search(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            AVLNode? current = root;

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

        // Check whether the AVL tree is correctly balanced
        public bool IsBalanced()
        {
            return CheckBalance(root) != -1;
        }

        private int CheckBalance(AVLNode? node)
        {
            if (node == null)
                return 0;

            int leftHeight = CheckBalance(node.Left);
            if (leftHeight == -1)
                return -1;

            int rightHeight = CheckBalance(node.Right);
            if (rightHeight == -1)
                return -1;

            // A difference greater than 1 means the tree is unbalanced
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
