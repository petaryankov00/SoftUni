using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(songsInput);

            string command = Console.ReadLine();

            while (songs.Any())
            {
                string[] cmdArgs = command.Split();
                switch (cmdArgs[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string currCmd = string.Join(" ", cmdArgs);
                        string currSong = currCmd.Substring(4, currCmd.Length - 4);
                        if (songs.Contains(currSong))
                        {
                            Console.WriteLine($"{currSong} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(currSong);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",songs));
                        break;                                              
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
