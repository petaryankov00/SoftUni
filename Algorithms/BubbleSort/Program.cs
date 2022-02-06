using System;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 6, 8, 2, 4, 10, 7 };

            BubbleSort(arr);

            Console.WriteLine(String.Join(" ",arr));
        }
        
        private static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int currElement = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = currElement;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            return arr;
        }
    }
}
