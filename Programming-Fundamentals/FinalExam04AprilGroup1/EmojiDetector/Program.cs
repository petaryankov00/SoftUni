using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string emojiPattern = @"(\:{2}|\*{2})([A-Z]{1}[a-z]{2,})\1";            
            string digitPattern = @"\d";        

            List<string> emojies = new List<string>();
            MatchCollection digits = Regex.Matches(input, digitPattern);
            List<string> coolOnes = new List<string>();

            int threshold = 1;           
            foreach (Match currDigit in digits)
            {
                int digit = int.Parse(currDigit.Value);
                threshold *= digit;
            }
            MatchCollection emojiMatches = Regex.Matches(input, emojiPattern);
            foreach (Match emoji in emojiMatches)
            {
                string currEmoji = emoji.Value.ToString();
                emojies.Add(currEmoji);
            }
            int emojiesFound = emojies.Count;
            for (int i = 0; i < emojies.Count; i++)
            {
                string currEmojiForList = emojies[i].ToString();
                string currEmoji = emojies[i].Substring(2, emojies[i].Length - 4);
                char[] currLetters = currEmoji.ToCharArray();
                long sum = 0;
                for (int j = 0; j < currLetters.Length; j++)
                {
                    char currLetter = currLetters[j];
                    sum += (long)(currLetter);
                }
                if (sum > threshold)
                {
                    coolOnes.Add(currEmojiForList);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");           
            Console.WriteLine($"{emojiesFound} emojis found in the text. The cool ones are:");
            foreach (var item in coolOnes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
