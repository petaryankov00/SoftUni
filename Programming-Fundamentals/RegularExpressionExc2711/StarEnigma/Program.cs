using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string letterPatern = @"[s,t,a,r,S,T,A,R]";           
            Regex regexLetter = new Regex(letterPatern);
            string pattern = @"@([A-Za-z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*!([AD])![^@\-!:>]*->([0-9]+)";
            Regex mainRegex = new Regex(pattern);
            List<string> atackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int atPl = 0;
            int desPl = 0;
            for (int i = 1; i <= n; i++)
            {
                string message = Console.ReadLine();
                MatchCollection letters = regexLetter.Matches(message);
                int counter = letters.Count;

                StringBuilder encryptedMessage = new StringBuilder();
                for (int j = 0; j < message.Length; j++)
                {                   
                    
                    encryptedMessage.Append((char)(message[j]-counter));                   
                }
                string finalMessage = encryptedMessage.ToString();
                Match match = mainRegex.Match(finalMessage);
                if (match.Success)
                {
                    string planetName = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    char index = char.Parse(match.Groups[3].Value);
                    int count = int.Parse(match.Groups[4].Value);
                    if (index == 'A')
                    {
                        atackedPlanets.Add(planetName);                       
                        atPl++;
                    }
                    else if (index == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                        desPl++;
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {atPl}");
            if (atPl > 0)
            {
                foreach (var planet in atackedPlanets.OrderBy(p=>p))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {desPl}");
            if (desPl>0)
            {
                foreach (var planet in destroyedPlanets.OrderBy(p=>p))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
          
        }
    }
}
