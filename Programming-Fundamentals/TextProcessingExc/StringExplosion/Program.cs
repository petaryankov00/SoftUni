using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = Console.ReadLine();
            var bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                var currCh = field[i];
                if (currCh == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString());
                    continue;
                }

                if (bomb > 0)
                {
                    field = field.Remove(i, 1);
                    i--;
                    bomb--;
                }
            }
            Console.WriteLine(field);
        }
    }
}
