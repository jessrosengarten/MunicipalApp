using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    public class AVLTree<T> where T : IComparable<T>
    {
        // Represents a node in the AVL tree
        private class TreeNode
        {
            public T Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Height { get; set; }

            public TreeNode(T data)
            {
                Data = data;
                Left = null;
                Right = null;
                Height = 1; // New node is initially added at height 1
            }
        }

        // Root of the AVL tree
        private TreeNode root;

        // Constructor
        public AVLTree()
        {
            root = null;
        }

        // Insert a new item into the AVL tree
        public void Insert(T data)
        {
            root = InsertRec(root, data);
        }

        // Recursive method to insert a new item into the AVL tree
        private TreeNode InsertRec(TreeNode node, T data)
        {
            if (node == null)
                return new TreeNode(data); // Create a new node if the current node is null

            if (data.CompareTo(node.Data) < 0)
                node.Left = InsertRec(node.Left, data); // Insert into the left subtree
            else if (data.CompareTo(node.Data) > 0)
                node.Right = InsertRec(node.Right, data); // Insert into the right subtree
            else
                return node; 

            // Update the height of the current node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Get the balance factor and balance the tree
            int balance = GetBalance(node);

            // Left-Left case
            if (balance > 1 && data.CompareTo(node.Left.Data) < 0)
                return RotateRight(node);

            // Right-Right case
            if (balance < -1 && data.CompareTo(node.Right.Data) > 0)
                return RotateLeft(node);

            // Left-Right case
            if (balance > 1 && data.CompareTo(node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Left case
            if (balance < -1 && data.CompareTo(node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        // Search for an item in the AVL tree
        public T Search(T data)
        {
            var resultNode = SearchRec(root, data);
            return resultNode != null ? resultNode.Data : default;
        }

        // Recursive method to search for an item in the AVL tree
        private TreeNode SearchRec(TreeNode node, T data)
        {
            if (node == null || node.Data.CompareTo(data) == 0)
                return node; // Return the node if it is found or the tree is empty

            if (data.CompareTo(node.Data) < 0) // Search in the left subtree
                return SearchRec(node.Left, data);
            else
                return SearchRec(node.Right, data); // Search in the right subtree
        }

        // Get all elements in sorted order (in-order traversal)
        public List<T> GetAllElements()
        {
            List<T> elements = new List<T>();
            InOrderTraversal(root, elements);
            return elements;
        }

        // Helper method for in-order traversal
        private void InOrderTraversal(TreeNode node, List<T> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list); // Traverse the left subtree
            list.Add(node.Data); // Add the current node
            InOrderTraversal(node.Right, list); // Traverse the right subtree
        }

        // Helper method to get the height of a node
        private int GetHeight(TreeNode node)
        {
            return node == null ? 0 : node.Height;
        }

        // Helper method to get the balance factor of a node
        private int GetBalance(TreeNode node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        // Performs a right rotation to balance the tree
        private TreeNode RotateRight(TreeNode y)
        {
            TreeNode x = y.Left;
            TreeNode T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x; // Return the new root
        }

        // Performs a left rotation to balance the tree
        private TreeNode RotateLeft(TreeNode x)
        {
            TreeNode y = x.Right;
            TreeNode T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y; // Return the new root
        }
    }
}
