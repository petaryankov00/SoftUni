﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }




    }
}
