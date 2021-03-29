using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>(n);
            BaseHero hero = null;

            while (heroes.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (heroType == "Druid")
                {
                    hero = new Druid(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                    heroes.Add(hero);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");                 
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int sumPower = 0;
            foreach (var currHero in heroes)
            {
                Console.WriteLine(currHero.CastAbility());
                sumPower += currHero.Power;
            }

            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
