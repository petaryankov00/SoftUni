using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeImplementation
{
    public class Program
    {
        static void Main()
        {
            TNode<int> root =
                new TNode<int>(4,
                    new TNode<int>(19,
                        new TNode<int>(10),
                        new TNode<int>(12),
                        new TNode<int>(16)),
                    new TNode<int>(20),
                    new TNode<int>(21,
                        new TNode<int>(24),
                        new TNode<int>(30)));

            Tree<int> tree = new Tree<int>();

            tree.DFS(root);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            tree.BFS(root);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            DFSIteravie<int>(root);
            
        }

        private static void DFSIteravie<T>(TNode<T> root)
        {
            var stack = new Stack<TNode<T>>();

            stack.Push(root);

            while (stack.Any())
            {
                var currNode = stack.Pop();
                Console.WriteLine(currNode.Value);

                foreach (var child in currNode.Children)
                {
                    stack.Push(child);
                }
            }
        }
    }
}
