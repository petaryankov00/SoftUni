using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();

            string line = Console.ReadLine();



            while (line != "END")
            {

                string[] parts = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string teamName = parts[1];

                try
                {
                    if (parts[0] == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (parts[0] == "Add")
                    {
                        string playerName = parts[2];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            int endurance = int.Parse(parts[3]);
                            int sprint = int.Parse(parts[4]);
                            int dribble = int.Parse(parts[5]);
                            int passing = int.Parse(parts[6]);
                            int shooting = int.Parse(parts[7]);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            var team = teams[teamName];
                            team.AddPlayer(playerName, player);
                        }
                    }
                    else if (parts[0] == "Remove")
                    {
                        string playerName = parts[2];
                        var team = teams[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (parts[0] == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            var team = teams[teamName];
                            Console.WriteLine($"{teamName} - {team.AverageRating}");
                        }
                    }                  
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                line = Console.ReadLine();

            }

        }
    }
}
