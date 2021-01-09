using System;

namespace ExamPrep2810
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int wonBattles = 0;
            bool isThereEnoughEnergy = true;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);            
                if (energy < distance)
                {
                    isThereEnoughEnergy = false;
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    break;
                }
                else
                {
                    energy -= distance;
                    wonBattles++;
                }
                if (wonBattles % 3 == 0)
                {
                    energy += wonBattles;
                }
                input = Console.ReadLine();
            }
            if (isThereEnoughEnergy)
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
            }
        }
    }
}
