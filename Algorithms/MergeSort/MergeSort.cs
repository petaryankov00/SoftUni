using System;
namespace MergeSort
{
    public class MergeSort<T>
        where T : IComparable<T>
    {
        private static T[] temp;

        public static void Sort(T[] array, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;
            Sort(array, lo, mid);
            Sort(array, mid + 1, hi);

            Merge(array, lo, mid, hi);



        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {

            if (IsLess(arr[mid], arr[mid + 1]))
            {
                return;
            }

            temp = new T[arr.Length];

            for (int i = lo; i <= hi; i++)
            {
                temp[i] = arr[i];
            }

            int n1 = lo;
            int n2 = mid + 1;


            for (int i = lo; i <= hi; i++)
            {
                if (n1 > mid)
                {
                    arr[i] = temp[n2++];
                }
                else if (n2 > hi)
                {
                    arr[i] = temp[n1++];
                }
                else if (IsLess(temp[n1],temp[n2]))
                {
                    arr[i] = temp[n1++];
                }
                else
                {
                    arr[i] = temp[n2++];
                }
            }

        }

        private static bool IsLess(T firstElement,T secondElement)
        {
            if (firstElement.CompareTo(secondElement) < 0)
            {
                return true;
            }
            return false;
                    
        }
    }
}
