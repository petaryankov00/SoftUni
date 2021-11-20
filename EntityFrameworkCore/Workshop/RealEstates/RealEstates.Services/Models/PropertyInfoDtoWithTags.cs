using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Models
{
    public class PropertyInfoDtoWithTags 
    {
        public string DistrictName { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public byte? Floor { get; set; }

        public string Type { get; set; }

        public List<string> Tags { get; set; }
    }
}
