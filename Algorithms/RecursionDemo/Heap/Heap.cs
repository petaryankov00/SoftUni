using System;
using System.Collections.Generic;

namespace HeapImplementation
{
    public class Heap<T> 
        where T : IComparable<T>
    {
        private List<T> heap;

        public Heap()
        {
            heap = new List<T>();
        }

        public int Size => this.heap.Count;

        public T GetMax()
            => this.heap[0];

        public void Add(T element)
        {
            this.heap.Add(element);
            Heapify(this.Size - 1);
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

            Console.WriteLine(heap[index]);
            if (leftChildIndex < this.Size)
            {
                DFS(leftChildIndex);
            }
            if (rightChildIndex < this.Size)
            {
                DFS(rightChildIndex);
            }

        }
    }
}
