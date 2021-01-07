using System;

namespace ExamTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int duljina = int.Parse(Console.ReadLine());
            int shirochina = int.Parse(Console.ReadLine());
            int visochina = int.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());
            double obem = duljina * shirochina * visochina;
            double litri = obem * 0.001;
            double procent1 = procent * 0.01;
            double final = litri * (1 - procent1);
            Console.WriteLine($"{final:F3}"); 
        }
    }
}
