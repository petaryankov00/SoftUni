using System;
using System.IO;
using System.Text;

namespace StreamsUnderneath
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("../../../students.txt", FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                Console.WriteLine($"Stream Position: {stream.Position}");
                for (int i = 0; i < stream.Length/buffer.Length; i++)
                {
                    stream.Read(buffer, 0, buffer.Length);
                    using (FileStream streamWriter = new FileStream($"../../../{i}.students.txt",
                        FileMode.Create, FileAccess.Write)) 
                    {
                        streamWriter.Write(buffer, 0, buffer.Length);
                    }
                }
                Console.WriteLine($"Stream Position: {stream.Position}");
            }
        }
    }
}
