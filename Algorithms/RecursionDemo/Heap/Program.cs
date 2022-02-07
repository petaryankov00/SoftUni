namespace HeapImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Heap<int> heap = new Heap<int>();

            int[] arr = new int[] { 1, 2, 3, 10, 45, 23, 4, 6, 90 };

            foreach (var item in arr)
            {
                heap.Add(item);
            }

            heap.DFS(0);
        }
    }
}
