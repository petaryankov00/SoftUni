using System;
using System.IO;

namespace RecoursiveDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();

            var files = Directory.GetFiles(folderPath);

            int fileSizes = 0;
            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);           
                fileSizes += (int)file.Length;
            }
            Console.WriteLine(fileSizes/1024.0);
        }
    }
}
