using RealEstates.Data;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }


        public void InsertTagToProperty()
        {
            var properties = this.dbContext.Properties.ToList();
            var tags = this.dbContext.Tags.Select(x => x.Name).ToList();

            IPropertiesService propertiesServie = new PropertiesService(this.dbContext);

            foreach (var prop in properties)
            {
                var averagePrice = propertiesServie.AveragePricePerSquareMeter(prop.DistrictId);
                if (prop.Price > averagePrice)
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "скъп имот");
                    prop.Tags.Add(tag);
                }
                else if(prop.Price < averagePrice && prop.Price.HasValue)
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "евтин имот");
                    prop.Tags.Add(tag);
                }

                if (prop.TotalFloors == prop.Floor && prop.Floor != null && prop.TotalFloors != null)
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "последен етаж");
                    prop.Tags.Add(tag);
                }
                else if (prop.Floor == 1)
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "първи етаж");
                    prop.Tags.Add(tag);
                }
                if (prop.Size >= 400)
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "голям имот");
                    prop.Tags.Add(tag);
                }
                else
                {
                    var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name == "малък имот");
                    prop.Tags.Add(tag);
                }
                Console.Write(".");
            }
            this.dbContext.SaveChanges();



        }
    }
}
