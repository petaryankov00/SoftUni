﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("partId")]
    public class PartIds
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
