using System;
using System.IO;

namespace StreamFilesAndDirectories2201
{
    class Program
    {
        static void Main(string[] args)
        {
            //firstWay to close a Stream
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {         
                string firstLine = reader.ReadLine();
                Console.WriteLine(firstLine);
            }     
           //secondWay to close a Stream
            StreamWriter writer = new StreamWriter("../../../input.txt",true);
            writer.WriteLine("Files are cool");
            writer.Close();
        }
    }
}
