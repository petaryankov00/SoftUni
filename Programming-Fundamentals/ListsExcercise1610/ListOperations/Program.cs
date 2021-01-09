using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split();
                string firstCmd = command[0];
                if (firstCmd == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (firstCmd == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (isValidIndex(index,numbers.Count-1))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (firstCmd == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (isValidIndex(index, numbers.Count-1))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (firstCmd == "Shift")
                {
                    int rotation = int.Parse(command[2]);
                    if (command[1] == "left")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = numbers[0];
                            for (int j = 0; j < numbers.Count-1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }
                            numbers[numbers.Count - 1] = firstElement;
                        }

                    }
                    else if (command[1] == "right")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];
                            for (int j = numbers.Count-1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }
                            numbers[0] = lastElement;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
        static bool isValidIndex(int index,int count)
        {
            return index > count || index < 0; 
        }
    }
}
