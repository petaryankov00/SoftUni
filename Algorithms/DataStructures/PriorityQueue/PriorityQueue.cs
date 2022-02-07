using System;
using System.Collections.Generic;

namespace PriorityQueueImplementation
{
    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public int Size => this.heap.Count;

        public T Peek()
            => this.heap[0];

        public void Enqueue(T element)
        {
            this.heap.Add(element);
            Heapify(this.Size - 1);
        }

        public T Dequeue()
        {
            var top = this.heap[0];
            heap[0] = this.heap[Size - 1];
            heap.RemoveAt(Size - 1);
            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count)
            {
                return;
            }

            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                var curr = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = curr;
                HeapifyDown(maxChildIndex);
            }
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;

            if (heap[parentIndex].CompareTo(heap[index]) < 0)
            {
                var curr = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = curr;
                Heapify(parentIndex);
            }
        }
        public void DFS(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

           
            if (leftChildIndex < this.Size)
            {
                DFS(leftChildIndex);
            }
            if (rightChildIndex < this.Size)
            {
                DFS(rightChildIndex);
            }
            Console.WriteLine(heap[index]);

        }
    }
}
