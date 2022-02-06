using System;

namespace BinarySearchRecursive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr,n,0,arr.Length-1));
        }

        private static int BinarySearch(int[] arr, int n, int left, int right)
        {
            if (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == n)
                {
                    return mid;
                }
                else if (n < arr[mid])
                {
                    return BinarySearch(arr, n, left, mid - 1);
                }
                else if (n > arr[mid])
                {
                    return BinarySearch(arr, n, mid + 1, right);
                }
            }
           
            return -1;
        }
    }
}

