using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;


        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {           
            Player playerToRemove = roster.FirstOrDefault(x => x.Name == name);
            if (playerToRemove == null)
            {
                return false;
            }
            roster.Remove(playerToRemove);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = roster.FirstOrDefault(x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        
        public void DemotePlayer(string name)
        {
            Player playerToDemote = roster.FirstOrDefault(x => x.Name == name);
            if (playerToDemote.Description != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] removedPlayers = roster.Where(x => x.Class == clas).ToArray();
            roster.RemoveAll(x => x.Class == clas);
            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }

            string report = sb.ToString().Trim();
            return report;
        }

    }
}
