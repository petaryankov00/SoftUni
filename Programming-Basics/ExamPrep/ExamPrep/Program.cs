using System;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int bees = int.Parse(Console.ReadLine());
            int flowers = int.Parse(Console.ReadLine());
            double sumHoney = (bees * flowers * 0.21);
            double honeyCombs = Math.Floor(sumHoney / 100);
            double leftHoney = sumHoney - (honeyCombs * 100);
            Console.WriteLine($"{honeyCombs} honeycombs filled.");
            Console.WriteLine($"{leftHoney:f2} grams of honey left.");
        }
    }
}
