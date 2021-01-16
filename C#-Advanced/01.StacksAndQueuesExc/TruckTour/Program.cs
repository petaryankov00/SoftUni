using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> pumpsData = new Queue<string>();
            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }
            for (int i = 0; i < pumpsCount; i++)
            {
                int currFuel = 0;
                bool isSuccesful = true;
                for (int j = 0; j < pumpsCount; j++)
                {                   
                    string pumpStr = pumpsData.Dequeue();
                    int[] pumpArg = pumpStr.Split().Select(int.Parse).ToArray();
                    pumpsData.Enqueue(pumpStr);
                    currFuel += pumpArg[0];
                    currFuel -= pumpArg[1];
                    if (currFuel < 0)
                    {
                        isSuccesful = false;
                    }

                }
                if (isSuccesful)
                {
                    Console.WriteLine(i);
                    break;
                }
                string temData = pumpsData.Dequeue();
                pumpsData.Enqueue(temData);
            }
        }
    }
}
