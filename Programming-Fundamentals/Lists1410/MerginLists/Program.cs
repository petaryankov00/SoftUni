using System;
using System.Collections.Generic;
using System.Linq;

namespace MerginLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            List<int> nums2 = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            List<int> result = new List<int>();
                for (int i = 0; i < Math.Min(nums1.Count,nums2.Count); i++)
            {
                result.Add(nums1[i]);
                result.Add(nums2[i]);
            }

            for (int i = Math.Min(nums1.Count, nums2.Count); i < Math.Max(nums1.Count, nums2.Count); i++)
            {
                if (i>=nums1.Count)
                {
                    result.Add(nums2[i]);
                }
                else
                {
                    result.Add(nums1[i]);
                }
            }
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
