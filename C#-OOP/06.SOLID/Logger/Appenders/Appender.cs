using LoggerProject.Enums;
using LoggerProject.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProject.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);
    }
}
