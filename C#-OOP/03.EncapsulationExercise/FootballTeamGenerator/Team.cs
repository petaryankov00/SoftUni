using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public double AverageRating
        {            
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
               return Math.Round(this.players.Values.Average(x => x.AverageSkillPoints));
            }
        }

        public void AddPlayer(string playerName,Player player)
        {
            players.Add(playerName, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(playerName);
        }


    }
}
