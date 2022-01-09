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
            int minIndex = 0;
            int maxIndex = array.Length - 1;

            while (minIndex <= maxIndex)
            { 
                int mid = (maxIndex + minIndex) / 2;
                if (array[mid] == key)
                {
                    return mid;
                }
                else if (key < array[mid])
                {
                    maxIndex = mid - 1;
                }
                else if (key > array[mid])
                {
                    minIndex = mid + 1;
                }
            }

            return null;
        }
    }
}
