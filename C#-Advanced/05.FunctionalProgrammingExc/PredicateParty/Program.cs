using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command.Split();
                string cmdType = tokens[0];
                string[] cmdArgs = tokens.Skip(1).ToArray();
                Predicate<string> predicate = GetPredicate(cmdArgs);

                if (cmdType == "Remove")
                {
                    people.RemoveAll(predicate);
                }
                else if (cmdType == "Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (predicate(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i++;
                        }
                    }                   
                }
                command = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ",people)} are going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string[] cmdArgs)
        {
            string cmdName = cmdArgs[0];
            string cmdType = cmdArgs[1];
            Predicate<string> predicate = null;
            if (cmdName == "StartsWith")
            {
               predicate = new Predicate<string>(name =>
               {
                   return name.StartsWith(cmdType);
               });
            }
            else if (cmdName == "EndsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.EndsWith(cmdType);
                });
            }
            else if (cmdName == "Length")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.Length == int.Parse(cmdType);
                });
            }
            return predicate;
        }
    }
}
