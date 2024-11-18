using System.Collections.Generic;
using System;

/// <summary>
/// Represents a generic MinHeap data structure
/// </summary>
public class MinHeap<T> where T : IComparable<T>
{
    private List<T> heap; // Internal list to store the heap elements

    /// <summary>
    /// Initializes a new instance of the MinHeap class
    /// </summary>
    public MinHeap()
    {
        heap = new List<T>();
    }

    /// <summary>
    /// Inserts a new item into the MinHeap
    /// </summary>
    public void Insert(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    /// <summary>
    /// Removes and returns the minimum element from the MinHeap
    /// </summary>
    public T ExtractMin()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

        T min = heap[0]; // Root element is the minimum
        heap[0] = heap[heap.Count - 1]; // Replace root with last element
        heap.RemoveAt(heap.Count - 1); // Remove the last element
        HeapifyDown(0); // Restore the MinHeap property

        return min;
    }

    /// <summary>
    /// Returns the minimum element from the MinHeap without removing it
    /// </summary>
    public T Peek()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");
        return heap[0];
    }

    /// <summary>
    /// Returns a list of all elements in the MinHeap
    /// </summary>
    public List<T> ToList()
    {
        return new List<T>(heap);
    }

    /// <summary>
    /// Restores the MinHeap property by moving the element up the heap as necessary
    /// </summary>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            // If the current element is smaller than its parent, swap them
            if (heap[index].CompareTo(heap[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex; // Update the index to the parent index
            }
            else break; // If the current element is in the correct position, stop
        }
    }

    /// <summary>
    /// Restores the MinHeap property by moving the element down the heap as necessary
    /// </summary>
    private void HeapifyDown(int index)
    {
        int smallest = index; // Start with the current element as the smallest
        int left = 2 * index + 1; // Index of the left child
        int right = 2 * index + 2; // Index of the right child

        // Check if the left child is smaller than the current element
        if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
            smallest = left;

        // Check if the right child is smaller than the current element and the left child
        if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
            smallest = right;

        // If the smallest element is not the current element, swap them and continue
        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest); // Recursively restore the MinHeap property
        }
    }

    /// <summary>
    /// Swaps two elements in the heap
    /// </summary>
    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
