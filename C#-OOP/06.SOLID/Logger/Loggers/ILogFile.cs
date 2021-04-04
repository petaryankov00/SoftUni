using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProject.Loggers
{
    public interface ILogFile
    {
        void Write(string content);

        public int Size { get; }
    }
}
