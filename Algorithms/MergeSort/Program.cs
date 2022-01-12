using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100000];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1000 - i;
            }
            var watch = new Stopwatch();

            watch.Start();
            MergeSort<int>.Sort(array,0,array.Length - 1);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch.Start();
            array.OrderBy(x => x);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            
        }
    }
}
