using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, SortedSet<string>>> platform = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split();
                if (cmdArgs[1] == "joined")
                {
                    string vloggerName = cmdArgs[0];
                    if (!platform.ContainsKey(vloggerName))
                    {
                        platform.Add(vloggerName, new Dictionary<string, SortedSet<string>>
                        {
                            {"followers",new SortedSet<string>() },
                            {"following",new SortedSet<string>() }
                        });
                    }
                }
                else if (cmdArgs[1] == "followed")
                {
                    string followingVlogger = cmdArgs[0];
                    string followedVlogger = cmdArgs[2];
                    if (IsValid(followingVlogger, followedVlogger, platform))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    platform[followingVlogger]["following"].Add(followedVlogger);
                    platform[followedVlogger]["followers"].Add(followingVlogger);

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {platform.Count} vloggers in its logs.");
            int number = 1;

            foreach (var vlogger in platform.OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, " +
                    $"{vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }
        }

        private static bool IsValid(string followingVlogger, string followedVlogger, Dictionary<string, Dictionary<string, SortedSet<string>>> platform)
        {
            return !platform.ContainsKey(followingVlogger) || !platform.ContainsKey(followedVlogger)
                || followingVlogger == followedVlogger ||
                platform[followingVlogger]["following"].Contains(followedVlogger) ||
                platform[followedVlogger]["followers"].Contains(followingVlogger);
        }
    }
}
