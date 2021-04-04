using LoggerProject.Enums;
using LoggerProject.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProject.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            string content = string.Format(this.layout.Template, date, reportLevel, message);

            Console.WriteLine(content);
        }
    }
}
