using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
  //  <Purchase title = "Dungeon Warfare 2" >
  //  < Type > Digital </ Type >
  //  < Key > ZTZ3 - 0D2S-G4TJ</Key>
  //  <Card>1833 5024 0553 6211</Card>
  //  <Date>07/12/2016 05:49</Date>
  //  </Purchase>
  
    [XmlType("Purchase")]
    public class PurchaseInputModel
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public PurchaseType Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        [Required]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}
