using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.DataStructures
{
    public class ServiceRequestRedBlackTree
    {
        private RedBlackNode? root;

        private bool IsRed(RedBlackNode? node)
        {
            return node != null && node.IsRed;
        }

        // Rotate left to correct a right-leaning red link
        private RedBlackNode RotateLeft(RedBlackNode node)
        {
            RedBlackNode newRoot = node.Right!;

            node.Right = newRoot.Left;
            newRoot.Left = node;

            newRoot.IsRed = node.IsRed;
            node.IsRed = true;

            return newRoot;
        }

        // Rotate right when two red links appear on the left
        private RedBlackNode RotateRight(RedBlackNode node)
        {
            RedBlackNode newRoot = node.Left!;

            node.Left = newRoot.Right;
            newRoot.Right = node;

            newRoot.IsRed = node.IsRed;
            node.IsRed = true;

            return newRoot;
        }

        // Change node colours to split a temporary 4-node
        private void FlipColors(RedBlackNode node)
        {
            node.IsRed = !node.IsRed;
            node.Left!.IsRed = !node.Left.IsRed;
            node.Right!.IsRed = !node.Right.IsRed;
        }

        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            root = InsertNode(root, issue);

            // The root must always be black
            root.IsRed = false;
        }

        private RedBlackNode InsertNode(
            RedBlackNode? node,
            Issue issue)
        {
            if (node == null)
                return new RedBlackNode(issue);

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

            // Fix right-leaning red links
            if (IsRed(node.Right) && !IsRed(node.Left))
                node = RotateLeft(node);

            // Fix consecutive left-leaning red links
            if (IsRed(node.Left) && IsRed(node.Left?.Left))
                node = RotateRight(node);

            // Split a temporary 4-node
            if (IsRed(node.Left) && IsRed(node.Right))
                FlipColors(node);

            return node;
        }

        // Retrieve a request using its tracking ID
        public Issue? Search(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            RedBlackNode? current = root;

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

        // Verify that the Red-Black Tree follows its balancing rules
        public bool IsValidRedBlackTree()
        {
            if (root == null)
                return true;

            // The root must always be black
            if (root.IsRed)
                return false;

            return ValidateNode(root) != -1;
        }

        private int ValidateNode(RedBlackNode? node)
        {
            if (node == null)
                return 1;

            // Left-leaning Red-Black Trees must not have right-leaning red links
            if (IsRed(node.Right))
                return -1;

            // A red node cannot have a red child
            if (node.IsRed &&
                (IsRed(node.Left) || IsRed(node.Right)))
                return -1;

            int leftBlackHeight = ValidateNode(node.Left);
            int rightBlackHeight = ValidateNode(node.Right);

            if (leftBlackHeight == -1 || rightBlackHeight == -1)
                return -1;

            // Every path must contain the same number of black nodes
            if (leftBlackHeight != rightBlackHeight)
                return -1;

            return leftBlackHeight + (node.IsRed ? 0 : 1);
        }
    }
}
