using System;

namespace MultidimensionalArrays1501
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
                {
                    {1, 2 },
                    {1, 2 }
                };

            //matrix[0, 0] = 5;
            //matrix[0, 1] = 4;
            //matrix[1, 0] = 2;
            //matrix[1, 1] = 7;

            Console.WriteLine(matrix[1,1]);
        }
    }
}
