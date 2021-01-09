using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(" : ");
                string courseName = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(studentName);
                command = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
