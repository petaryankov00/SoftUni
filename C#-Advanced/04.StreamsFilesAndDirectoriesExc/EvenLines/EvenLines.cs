using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int lineCounter = 0;
                while (line != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        Regex regex = new Regex(@"[.,!?-]");
                        line =  regex.Replace(line,"@");
                        string[] currLine = line.Split();
                        currLine = currLine.Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", currLine));
                    }
                    line = reader.ReadLine();
                    lineCounter++;
                }
            }
        }
    }
}
