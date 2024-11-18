using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal_App
{
    //  Represents a generic doubly linked list
    public class DoublyLinkedList<T>
    {
        private Node head; // First node in the list (head)
        private Node tail; // Last node in the list (tail)


        // Initialize the doubly linked list
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        // Represents a node in a doubly linked list
        public class Node
        {
            public T Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            // Initialize a new node with data
            public Node(T data)
            {
                Data = data;
                Previous = null;
                Next = null;
            }
        }

        // Method to add a new node with data to the doubly linked list
        public void Add(T data)
        {
            Node newNode = new Node(data);

            // If the list is empty, set the new node as the head and tail
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                // Add the new node to the end of the list and update the tail
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }
        
        // Method to remove a node from the list
        public void Remove(Node node)
        {
            if (node == head && node == tail)
            {
                head = null;
                tail = null;
            }
            else if (node == head)
            {
                head = head.Next;
                if (head != null) head.Previous = null;
            }
            else if (node == tail)
            {
                tail = tail.Previous;
                if (tail != null) tail.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }
        }

        // Retrieves the first node in the list
        public Node GetFirstNode()
        {
            return head;
        }

        // Retrieves the last node in the list
        public Node GetLastNode()
        {
            return tail;
        }
    }
}
