using LoggerProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProject.Appenders
{
    public interface IAppender 
    {
        void Append(string date, ReportLevel reportLevet, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
