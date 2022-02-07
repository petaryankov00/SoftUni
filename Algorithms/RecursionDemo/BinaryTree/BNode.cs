namespace BinaryTreeImplementation
{
    public class BNode<T>
    {
        public BNode(T value, BNode<T> leftNode = null, BNode<T> rightNode = null)
        {
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public T Value { get; set; }

        public BNode<T> LeftNode { get; set; }
        public BNode<T> RightNode { get; set; }
    }
}
