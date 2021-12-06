namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber,
                    })
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();

            var theatresJson = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return theatresJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(x => x.Rating <= rating)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(x => new PlayExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating.ToString().Equals("0") ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(c => c.IsMainCharacter == true).Select(c => new ActorExportModel
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Plays";
            var serializer = new XmlSerializer(typeof(PlayExportModel[]), xRoot);


            serializer.Serialize(new StringWriter(sb), plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
