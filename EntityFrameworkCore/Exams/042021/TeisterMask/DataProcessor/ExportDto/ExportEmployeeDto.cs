using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeDto
    {
        public string Username { get; set; }

        public TaskExportDto[] Tasks { get; set; }
    }

    //"TaskName": "Pointed Gourd",
    //    "OpenDate": "10/08/2018",
    //    "DueDate": "10/24/2019",
    //    "LabelType": "Priority",
    //    "ExecutionType": "ProductBacklog"

    public class TaskExportDto
    {
        public string TaskName { get; set; }

        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        public string LabelType { get; set; }

        public string ExecutionType { get; set; }
    }
}
