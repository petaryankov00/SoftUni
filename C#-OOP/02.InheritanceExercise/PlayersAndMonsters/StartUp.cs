using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = "Pesho";
            int level = 5;
            SoulMaster master = new SoulMaster(username, level);
            Console.WriteLine(master);
        }
    }
}