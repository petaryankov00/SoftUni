using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public double AverageSkillPoints
        {
            get => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
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

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.IsStatInRange(MinValue,
                    MaxValue, 
                    value,
                    $"{nameof(this.Endurance)} should be between 0 and 100.");

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.IsStatInRange(MinValue,
                    MaxValue,
                    value,
                    $"{nameof(this.Sprint)} should be between 0 and 100.");

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.IsStatInRange(MinValue,
                    MaxValue,
                    value,
                    $"{nameof(this.Dribble)} should be between 0 and 100.");

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.IsStatInRange(MinValue,
                    MaxValue,
                    value,
                    $"{nameof(this.Passing)} should be between 0 and 100.");

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.IsStatInRange(MinValue,
                    MaxValue,
                    value,
                    $"{nameof(this.Shooting)} should be between 0 and 100.");

                this.shooting = value;
            }
        }

    }
}
