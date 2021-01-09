using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string currentGame = Console.ReadLine();
            double totalSpentMoney = 0;
            double gamePrize = 0;
            while (currentGame != "Game Time")
            {
                if (currentGame == "OutFall 4")
                {
                    gamePrize = 39.99;
                    
                }
                else if (currentGame == "CS: OG")
                {
                    gamePrize = 15.99;
                  
                }
                else if (currentGame == "Zplinter Zell")
                {
                    gamePrize = 19.99;                 
                }
                else if (currentGame == "Honored 2")
                {
                    gamePrize = 59.99;
                    
                }
                else if (currentGame == "RoverWatch")
                {
                    gamePrize = 29.99;                    
                }
                else if (currentGame == "RoverWatch Origins Edition")
                {
                    gamePrize = 39.99;                    
                }

                bool validGame = currentGame != "OutFall 4" && currentGame != "CS: OG"
                                 && currentGame != "Zplinter Zell" && currentGame != "Honored 2"
                                 && currentGame != "RoverWatch" && currentGame != "RoverWatch Origins Edition";
                if (validGame)
                {
                    Console.WriteLine("Not Found");
                    currentGame = Console.ReadLine();
                    continue;
                }
             
                if (currentBalance < gamePrize)
                {
                    Console.WriteLine("Too Expensive");
                    currentGame = Console.ReadLine();
                    continue;
                }
                else if (currentBalance - gamePrize == 0)
                {
                    Console.WriteLine($"Bought {currentGame}");
                    Console.WriteLine("Out of money!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Bought {currentGame}");
                    currentBalance -= gamePrize;
                    totalSpentMoney += gamePrize;
                    currentGame = Console.ReadLine();
                }
            }
            if (currentGame == "Game Time")
            {
                Console.WriteLine($"Total spent: ${totalSpentMoney:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
