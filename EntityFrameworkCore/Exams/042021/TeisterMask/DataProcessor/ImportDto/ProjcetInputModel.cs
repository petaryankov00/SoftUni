using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjcetInputModel
    {
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskInputModel[] Tasks { get; set; }

    }

     //<Name>Australian</Name>
     //   <OpenDate>19/08/2018</OpenDate>
     //   <DueDate>13/07/2019</DueDate>
     //   <ExecutionType>2</ExecutionType>
     //   <LabelType>0</LabelType>

    [XmlType("Task")]
    public class TaskInputModel
    {
        [XmlElement("Name")]
        [MinLength(2), MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0,3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0,4)]
        public int LabelType { get; set; }
    }
}
