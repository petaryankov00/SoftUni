using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SoftUniCoursePlaning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                               .Split(", ")
                               .ToList();
            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] cmdArgs = command.Split(":").ToArray();
                string firstCommand = cmdArgs[0];
                string lessonTitle = cmdArgs[1];
                if (firstCommand == "Add")
                {
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Add(lessonTitle);
                    }
                }
                else if (firstCommand == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Insert(index, lessonTitle);
                    }
                }
                else if (firstCommand == "Remove")
                {
                    lessons.Remove(lessonTitle);
                }
                else if (firstCommand == "Swap")
                {
                    string secondLessonTitle = cmdArgs[2];
                    int indexOfFirstLesson = lessons.IndexOf(lessonTitle);
                    int indexOfSecondLesson = lessons.IndexOf(secondLessonTitle);

                    if (indexOfFirstLesson != -1 && indexOfSecondLesson != -1)
                    {
                        lessons[indexOfFirstLesson] = secondLessonTitle;
                        lessons[indexOfSecondLesson] = lessonTitle;

                        string firstLessonExc = $"{lessonTitle}-Excercise";
                        int indexOfFirstExc = indexOfFirstLesson + 1;
                        if (indexOfFirstExc < lessons.Count &&
                            lessons[indexOfFirstExc] == firstLessonExc)
                        {
                            lessons.RemoveAt(indexOfFirstExc);
                            indexOfFirstLesson = lessons.IndexOf(lessonTitle);
                            lessons.Insert(indexOfFirstExc, firstLessonExc);
                        }

                        string secondLessonExc = $"{lessonTitle}-Excercise"; 
                        int indexOfSecondExc = indexOfSecondLesson + 1;
                        if (indexOfSecondExc < lessons.Count &&
                            lessons[indexOfSecondExc] == secondLessonExc)
                        {
                            lessons.RemoveAt(indexOfSecondExc);
                            indexOfSecondLesson = lessons.IndexOf(secondLessonTitle);
                            lessons.Insert(indexOfSecondLesson+1, secondLessonExc);
                        }
                    }
                }
                else if (firstCommand == "Excercise")
                {
                    int index = lessons.IndexOf(lessonTitle);
                    string exc = $"{lessonTitle}-Excercise";
                    bool isThereAreLesson = lessons.Contains(lessonTitle);
                    bool isThereAreExc = lessons.Contains(exc);
                    if (isThereAreLesson && !isThereAreExc)
                    {
                        lessons.Insert(index + 1, exc);
                    }
                    else if (!isThereAreLesson)
                    {
                        lessons.Add(lessonTitle);
                        lessons.Add(exc);
                    }
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }

        }
    }
}
