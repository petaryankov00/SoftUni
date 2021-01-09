using System;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int keyNumber = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string decryptedWord = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char decryptedLetter = (char)(letter + keyNumber);
                decryptedWord += decryptedLetter;               
            }
            Console.WriteLine(decryptedWord);
        }
    }
}
