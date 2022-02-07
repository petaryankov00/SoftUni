using System;

namespace BinaryTreeImplementation
{
    public class BinaryTree<T>
    {
        public BinaryTree(BNode<T> root)
        {
            Root = root;
        }

        public BNode<T> Root { get; set; }

        public void DFS(BNode<T> node)
        {
            Console.WriteLine(node.Value);

            if (node.LeftNode != null)
            {
                DFS(node.LeftNode);
            }
            if (node.RightNode != null)
            {
                DFS(node.RightNode);
            }
          
        }

    }
}
