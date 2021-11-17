using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("Category")]
    public class CategoryDtoModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
