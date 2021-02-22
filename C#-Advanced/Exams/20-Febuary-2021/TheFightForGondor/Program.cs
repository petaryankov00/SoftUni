using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Exam2002
{
    class Plate
    {
        public Plate(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int wavesNumber = int.Parse(Console.ReadLine());

            Queue<Plate> plates = new Queue<Plate>();
            int[] plateInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var currPlate in plateInfo)
            {
                Plate plate = new Plate(currPlate);
                plates.Enqueue(plate);
            }

            Stack<int> wariorOrcs = new Stack<int>();
            bool isOrcsWon = false;

            for (int i = 1; i <= wavesNumber; i++)
            {
                int[] currWariors = Console.ReadLine().Split().Select(int.Parse).ToArray();
                foreach (var w in currWariors)
                {
                    wariorOrcs.Push(w);
                }
                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    Plate plate = new Plate(newPlate);
                    plates.Enqueue(plate);
                }
                
                while (wariorOrcs.Any() && plates.Any())
                {
                    int currOrc = wariorOrcs.Peek();
                    int currPlate = plates.Peek().Value;

                    if (currOrc > currPlate)
                    {
                        plates.Dequeue();
                        wariorOrcs.Push(wariorOrcs.Pop() - currPlate);
                    }
                    else if (currPlate > currOrc)
                    {
                        wariorOrcs.Pop();
                        plates.Peek().Value-=currOrc;
                    }
                    else
                    {
                        wariorOrcs.Pop();
                        plates.Dequeue();
                    }
                    if (!plates.Any())
                    {
                        isOrcsWon = true;
                        break;
                    }
                }

                if (isOrcsWon)
                {
                    break;
                }
            }

            if (isOrcsWon)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }

            if (wariorOrcs.Any())
            {
                Console.WriteLine($"Orcs left: {string.Join(", ",wariorOrcs)}");
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates left: {string.Join(", ",plates.Select(x=>x.Value))}");
            }
        }
    }
}
