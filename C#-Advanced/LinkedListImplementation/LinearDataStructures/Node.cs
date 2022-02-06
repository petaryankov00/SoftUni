namespace LinkedListImplementation
{
    public class Node<T>
    {
        public Node(T element)
        {
            Value = element;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}
