using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            string longNum = Console.ReadLine().TrimStart('0');
            int num = int.Parse(Console.ReadLine());
            int temp = 0;
            if (num == 0 || longNum == "")
            {
                Console.WriteLine(0);
                return;
            }
            foreach (var currDig in longNum.Reverse())
            {
                int digit = int.Parse(currDig.ToString());
                int result = digit * num + temp;
                int restDigit = result % 10;
                temp = result / 10;
                sb.Insert(0, restDigit);
            }
            if (temp !=0)
            {
                sb.Insert(0, temp);
            }          
            Console.WriteLine(sb.ToString());
        }
    }
}
