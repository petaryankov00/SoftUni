using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Lilie
    {
        public Lilie(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<Lilie> lilies = new Queue<Lilie>();
            foreach (var lilieValue in liliesInfo)
            {
                Lilie currLilie = new Lilie(lilieValue);
                lilies.Enqueue(currLilie);
            }

            int[] rosesInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> roses = new Stack<int>();
            foreach (var rose in rosesInfo)
            {
                roses.Push(rose);
            }

            List<int> leftFlowers = new List<int>();
            int countWreaths = 0;

            while (lilies.Any() && roses.Any())
            {
                int currLilie = lilies.Peek().Value;
                int currRose = roses.Peek();
                int sumValue = currLilie + currRose;

                if (sumValue == 15)
                {
                    countWreaths++;
                    lilies.Dequeue();
                    roses.Pop();
                }
                else if (sumValue > 15)
                {
                    lilies.Peek().Value -= 2;
                }
                else
                {
                    leftFlowers.Add(sumValue);
                    lilies.Dequeue();
                    roses.Pop();
                }
            }
            int sumFlowers = 0;

            foreach (var flower in leftFlowers)
            {
                sumFlowers += flower;
            }
            while (sumFlowers > 15)
            {
                countWreaths++;
                sumFlowers -= 15;
            }

            if (countWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-countWreaths} wreaths more!");
            }
        }
    }
}
