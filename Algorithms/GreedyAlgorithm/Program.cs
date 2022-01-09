using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] coins = new int[] { 1, 2, 5, 10, 20, 50 };
            //int sum = int.Parse(Console.ReadLine());
            //var result = GreedyAlgorithm1(coins, sum);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Key} - {item.Value}");
            //}

            List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            List<int[]> sets = new List<int[]>
            {
                new[] {1 ,2, 3, 4, 5},
                new[] {4 ,5, 6, 7},
                new[] {7 ,8, 9 },
                new[] {10 ,8, 12},
                new[] {11 ,5, 13},
            };

            GreedyAlgorithm2(universe, sets);
        }

        static Dictionary<int, int> GreedyAlgorithm1(int[] coins, int sum)
        {
            var sortedCoins = coins.OrderByDescending(x => x).ToArray();

            var resultCoins = new Dictionary<int, int>();
            var currSum = 0;
            var coinIndex = 0;

            while (currSum != sum || coinIndex >= sortedCoins.Length)
            {
                var currentCoinValue = sortedCoins[coinIndex];

                var remainingSum = sum - currSum;

                var numberOfCoinsToTake = remainingSum / currentCoinValue;

                if (numberOfCoinsToTake > 0)
                {
                    resultCoins.Add(currentCoinValue, numberOfCoinsToTake);
                    currSum += currentCoinValue * numberOfCoinsToTake;
                }

                coinIndex++;
            }

            return resultCoins;

        }

        static List<int[]> GreedyAlgorithm2(List<int> univirse,List<int[]> sets)
        {
            var selectedSets = new List<int[]>();  

            while (univirse.Count > 0)
            {
                var currSet = sets.OrderByDescending(x=>x.Count(univirse.Contains)).First();
                selectedSets.Add(currSet);
                sets.Remove(currSet);
                univirse.RemoveAll(x => currSet.Contains(x));

            }
            return selectedSets;
        }
    }
}
