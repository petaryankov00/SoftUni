using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            string numberPattern = @"[-+]?[0-9]+\.?[0-9]*";
            Regex numbersRegex = new Regex(numberPattern);

            string[] demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var demon in demons)
            {
                string filter = "0123456789+-/.*";
                double damage = CalculateDamage(numbersRegex, demon);
                int health = demon.Where(c => !filter.Contains(c)).Sum(c => c);

                allDemons.Add(new Demon { Name = demon, Health = health, Damage = damage });
            }

            foreach (var demon in allDemons.OrderBy(a=>a.Name))
            {
                Console.WriteLine(demon);
            }
        }

        private static double CalculateDamage(Regex numbersRegex, string demon)
        {
            MatchCollection numbersMatches = numbersRegex.Matches(demon);
            double damage = 0;

            foreach (Match match in numbersMatches)
            {
                damage += double.Parse(match.Value);
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damage *= 2.0;
                }
                else if (ch == '/')
                {
                    damage /= 2.0;
                }
            }

            return damage;
        }
    }
}
