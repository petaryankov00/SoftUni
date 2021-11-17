using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Output
{
    [XmlType("SoldProducts")]
    public class ProductsCountModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductOutputDtoModel[] Products { get; set; }
    }
}
