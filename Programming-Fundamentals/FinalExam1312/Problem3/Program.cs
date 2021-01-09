using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split("=");
                if (cmdArgs[0] == "Add")
                {
                    string username = cmdArgs[1];
                    int sentMessages = int.Parse(cmdArgs[2]);
                    int recivedMessages = int.Parse(cmdArgs[3]);
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>
                        {
                            {"sent",sentMessages },
                            {"recived",recivedMessages }
                        });
                    }                 
                }
                else if (cmdArgs[0] == "Message")
                {
                    string sender = cmdArgs[1];
                    string reciver = cmdArgs[2];
                    if (users.ContainsKey(sender) && users.ContainsKey(reciver))
                    {
                        users[sender]["sent"]++;
                        users[reciver]["recived"]++;
                        if (users[sender]["sent"] + users[sender]["recived"] >= capacity)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (users[reciver]["sent"] + users[reciver]["recived"] >= capacity)
                        {
                            users.Remove(reciver);
                            Console.WriteLine($"{reciver} reached the capacity!");
                        }
                    }
                }
                else if (cmdArgs[0] == "Empty")
                {
                    string username = cmdArgs[1];
                    if (username == "All")
                    {
                        users.Clear();
                    }
                    else
                    {
                        users.Remove(username);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in users.OrderByDescending(x=>x.Value["recived"]).ThenBy(y=>y.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value["sent"]+user.Value["recived"]}");
            }
        }
    }
}
