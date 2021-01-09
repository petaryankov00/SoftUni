using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] heroeStats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int hp = int.Parse(heroeStats[1]);
                int mana = int.Parse(heroeStats[2]);
                if (hp <= 100 && mana <= 200)
                {
                    heroes.Add(heroeStats[0], new Dictionary<string, int>
                    {
                        {"hp",hp },
                        {"mana",mana }
                    });
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = cmdArgs[1];
                switch (cmdArgs[0])
                {
                    case "CastSpell":
                        int manaForSpell = int.Parse(cmdArgs[2]);
                        if (heroes[heroName]["mana"] >= manaForSpell)
                        {
                            heroes[heroName]["mana"] -= manaForSpell;
                            Console.WriteLine($"{heroName} has successfully cast {cmdArgs[3]} and now has {heroes[heroName]["mana"]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {cmdArgs[3]}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(cmdArgs[2]);
                        heroes[heroName]["hp"] -= damage;
                        if (heroes[heroName]["hp"] > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {cmdArgs[3]} and now has {heroes[heroName]["hp"]} HP left!");
                        }
                        else
                        {
                            heroes.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {cmdArgs[3]}!");
                        }
                        break;
                    case "Recharge":
                        int amount = int.Parse(cmdArgs[2]);
                        heroes[heroName]["mana"] += amount;
                        if (heroes[heroName]["mana"] > 200)
                        {
                            int newAmount = heroes[heroName]["mana"] - 200;
                            int result = amount - newAmount;
                            heroes[heroName]["mana"] = 200;
                            Console.WriteLine($"{heroName} recharged for {result} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        }
                        break;
                    case "Heal":
                        int amountHeal = int.Parse(cmdArgs[2]);
                        heroes[heroName]["hp"] += amountHeal;
                        if (heroes[heroName]["hp"] > 100)
                        {
                            int resultHp = amountHeal - (heroes[heroName]["hp"] - 100);
                            heroes[heroName]["hp"] = 100;
                            Console.WriteLine($"{heroName} healed for {resultHp} HP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} healed for {amountHeal} HP!");
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (var hero in heroes.OrderByDescending(x=>x.Value["hp"]).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value["hp"]}");
                Console.WriteLine($"  MP: {hero.Value["mana"]}");
            }
        } 
    }
}
