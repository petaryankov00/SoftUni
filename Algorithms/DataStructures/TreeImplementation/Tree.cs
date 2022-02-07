using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeImplementation
{
    public class Tree<T>
    {
        public TNode<T> Root { get; set; }

        public void DFS(TNode<T> root)
        {
            foreach (var child in root.Children)
            {
                DFS(child);
            }
            Console.WriteLine(root.Value);
        }

        public void BFS(TNode<T> root)
        {
            var queue = new Queue<TNode<T>>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var currNode = queue.Dequeue();
                Console.WriteLine(currNode.Value);
                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
    }
}
