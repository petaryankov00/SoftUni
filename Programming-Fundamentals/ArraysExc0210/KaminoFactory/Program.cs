using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int counter = 0;
            int bestCount = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            int BestCounter = 0;
            string bestSeq = "";
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");
                string[] dnaParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);
                //1111
                int count = 0;
                int sum = 0;
                string bestSequence = string.Empty;
                counter++;
                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }
                int beginIndex = sequence.IndexOf(bestSequence);
                if (count>bestCount ||
                    (count == bestCount && beginIndex < bestBeginIndex) ||
                    (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum) ||
                    counter == 1)
                {
                    bestCount = count;
                    bestSeq = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    BestCounter = counter; 

                }
            }
            char[] result = bestSeq.ToCharArray();
            Console.WriteLine($"Best DNA sample {BestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ",result)}");

        }
    }
}
