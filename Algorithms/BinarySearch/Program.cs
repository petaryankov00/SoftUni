using System;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, };
            int key = int.Parse(Console.ReadLine());

            var index = BinarySearch(array, key);
        }

        public static int? BinarySearch(int[] array, int key)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            { 
                int mid = (right + left) / 2;
                if (array[mid] == key)
                {
                    return mid;
                }
                else if (key < array[mid])
                {
                    right = mid - 1;
                }
                else if (key > array[mid])
                {
                    left = mid + 1;
                }
            }

            return null;
        }
    }
}
