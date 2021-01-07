using System;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            double Lm = double.Parse(Console.ReadLine());
            double Wm = double.Parse(Console.ReadLine());
            double Am = double.Parse(Console.ReadLine());

           

            double golemina1 = (Lm * 100) * (Wm * 100);
            double golemina2 = (Am * 100) * (Am * 100);

            double peika = golemina1 / 10;

            double free = golemina1 - golemina2 - peika;
            double tanciori = free / (40 + 7000);
            Console.WriteLine(Math.Floor(tanciori));
        }
    }
}
