using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();          
            string[] text = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < text.Length; i++)
            {
                string[] currLineWords = text[i].ToLower().
                    Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    foreach (var item in currLineWords)
                    {
                        if (item == word)
                        {
                            if (!wordsCounter.ContainsKey(word))
                            {
                                wordsCounter.Add(word, 0);
                            }
                            wordsCounter[word]++;
                        }
                    }
                }
            }          
            using (StreamWriter writer = new StreamWriter("../../../actualResult.txt"))
            {
                foreach (var word in wordsCounter.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

        }
    }
}
