using System;

namespace BinaryTreeImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            BNode<int> root =
            new BNode<int>(1,
                new BNode<int>(2,
                    new BNode<int>(4),
                    new BNode<int>(5)),
                new BNode<int>(3,
                    new BNode<int>(6),
                    new BNode<int>(7))
            );

            BinaryTree<int> tree = new BinaryTree<int>(root);

            tree.DFS(root);
        }
    }
}
