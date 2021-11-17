using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Output
{
    [XmlType("Users")]
    public class UserWithProductsModel
    {
        [XmlElement("count")]
        public int Count { get; set; }
        
        [XmlArray("users")]
        public ExportUserOutputModel[] Users { get; set; }
    }
}
