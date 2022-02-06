namespace LinkedListImplementation
{
    public class Program
    {
        public static void Main()
        {
            var list = new CustomLinkedList<int>();

            for (int i = 0; i <= 5; i++)
            {
                list.AddLast(i);
            }

            var currentHead = list.Head;
            while (currentHead != null)
            {
                Console.WriteLine(currentHead.Value);
                currentHead = currentHead.Next;
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var reversedListHead = list.Reverse(list.Head);

            currentHead = reversedListHead;
            while (currentHead != null)
            {
                Console.WriteLine(currentHead.Value);
                currentHead = currentHead.Next;
            }
        }
    }
}