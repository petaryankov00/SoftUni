using System;

namespace Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            string kind = Console.ReadLine();
            if (kind == "square")
            {
                double duljina1 = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(duljina1 * duljina1, 3));
            }
            else if (kind == "reactangle")
            {
                double duljina2 = double.Parse(Console.ReadLine());
                double duljina3 = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(duljina2 * duljina3, 3));
            }
            else if (kind == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(radius * radius, 3));
            }
            else if (kind == "triangle")
            {
                double duljina4 = double.Parse(Console.ReadLine());
                double visochina = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(duljina4 * visochina, 3));
            }
            else
            {
                Console.WriteLine("WRONG!");
            }

        }
    }
}
