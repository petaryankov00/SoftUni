using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProject.Loggers
{
    public interface ILogger
    {
        void Error(string date, string message);

        void Info(string date, string message);

        void Fatal(string date, string message);

        void Critical(string date, string message);

        void Warning(string date, string message);
    }
}
