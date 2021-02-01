using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputArg = input.Split(":");
                string contest = inputArg[0];
                string password = inputArg[1];
                contests.Add(contest, password);
                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] tokens = secondInput.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>
                        {
                            {contest,points}
                        });
                    }
                    else if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, points);
                    }
                    else
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                }
                secondInput = Console.ReadLine();
            }
            
            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()))
            {                             
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.Values.Sum()} points.");
                break;               
            }
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
