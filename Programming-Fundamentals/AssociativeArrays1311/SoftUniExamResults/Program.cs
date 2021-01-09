using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] cmdArgs = input.Split("-");
                string userName = cmdArgs[0];

                if (cmdArgs.Length>2)
                {
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (!students.ContainsKey(userName))
                    {
                        students.Add(userName, points);
                    }
                    else
                    {
                        if (students[userName]<points)
                        {
                            students[userName] = points;
                        }
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    students.Remove(userName);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var currStud in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{currStud.Key} | {currStud.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var currSub in submissions.OrderByDescending(x=>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{currSub.Key} - {currSub.Value}");
            }
        }
    }
}