using System;

namespace LoopsWhileExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchingBook = Console.ReadLine();
            int countBooks = int.Parse(Console.ReadLine());
            string bookName = Console.ReadLine();
            int counter = 0;
            while (bookName != searchingBook)
            {
                bookName = Console.ReadLine();
                counter++;
                if (counter == countBooks)
                {
                    break;
                }
            }
            if (bookName == searchingBook)
            {
               
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            
        }
    }
}
