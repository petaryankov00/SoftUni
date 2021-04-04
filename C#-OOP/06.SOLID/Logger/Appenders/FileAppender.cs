using LoggerProject.Enums;
using LoggerProject.Layouts;
using LoggerProject.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerProject.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout,ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            string content = string.Format(this.layout.Template, date, reportLevel, message) 
                + Environment.NewLine;

            logFile.Write(content);
            
        }
    }
}
