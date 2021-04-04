using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerProject.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";


        public int Size => File.ReadAllText(FilePath).Where(a => char.IsLetter(a)).Sum(a => a);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
