using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            //Console.WriteLine();
            //ImportJsonFile("imot.bg-raw-data-2021-03-18.json");

            var db = new ApplicationDbContext();
            AddTagToProperty(db);

        }


        private static void AddTagToProperty(ApplicationDbContext db)
        {
            ITagService tagService = new TagService(db);
            tagService.InsertTagToProperty();
        }

        private static void AddTag(ApplicationDbContext db)
        {
            ITagService service = new TagService(db);

            Dictionary<string, int> tags = new Dictionary<string, int>()
            {
                ["скъп имот"] = 8,
                ["евтин имот"] = 8,
                ["първи етаж"] = 4,
                ["последен етаж"] = 4,
                ["голям имот"] = 6,
                ["малък имот"] = 2,
            };

            foreach (var tag in tags)
            {
                service.Add(tag.Key, tag.Value);
            }
            


        }

        public static void ImportJsonFile(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(
                File.ReadAllText(fileName));
            foreach (var jsonProp in properties)
            {
                propertiesService.Add(jsonProp.District, jsonProp.Price, jsonProp.Floor,
                    jsonProp.TotalFloors, jsonProp.Size, jsonProp.YardSize,
                    jsonProp.Year, jsonProp.Type, jsonProp.BuildingType);
                Console.Write(".");
            }
        }
    }
}
