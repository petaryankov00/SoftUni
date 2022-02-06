namespace LinkedListImplementation
{
    public class CustomLinkedList<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> Last { get; set; }

        public void AddFirst(T element)
        {
            var newHead = new Node<T>(element);
            if (this.Head == null)
            {
                this.Last = newHead;
            }
            newHead.Next = this.Head;

            this.Head = newHead;
        }

        public void AddLast(T element)
        {
            var newLast = new Node<T>(element);

            if (this.Last == null)
            {
                this.Head = newLast;
                this.Last = newLast;
            }
            else
            {
                this.Last.Next = newLast;
                this.Last = newLast;
            }   
        }

        public void RemoveFirst()
        {
            if (this.Head == null)
            {
                return;
            }

            this.Head = this.Head.Next;
        }

        public void RemoveLast()
        { 
            if (this.Head == null)
            {
                return;
            }
            if (this.Head.Next == null)
            {
                return;
            }

            var seconadLastNode = this.Head;
                
            while (seconadLastNode.Next.Next != null)
            {
                seconadLastNode = seconadLastNode.Next;
            }

            seconadLastNode.Next = null;
            this.Last = seconadLastNode;
        }

        public Node<T> Reverse(Node<T> head)
        {
            if (head == null)
            {
                return head;
            }

            // last node or only one node
            if (head.Next == null)
            {
                return head;
            }

            Node<T> newHeadNode = Reverse(head.Next);

            // change references for middle chain
            head.Next.Next = head;
            head.Next = null;

            // send back new head 
            // node in every recursion
            return newHeadNode;
        }
    }
}
