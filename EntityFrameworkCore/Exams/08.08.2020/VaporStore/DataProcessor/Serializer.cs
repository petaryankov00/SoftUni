namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Microsoft.EntityFrameworkCore;
    using VaporStore.DataProcessor.Dto.Export;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;
    using VaporStore.Data.Models.Enums;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var games = context.Genres
                .Include(x=>x.Games)
                .ThenInclude(x=>x.GameTags)
                .ThenInclude(x=>x.Tag)
                .ToArray()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(y => y.Purchases.Any())
                    .Select(y => new
                    {
                        Id = y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = string.Join(", ", y.GameTags.Select(t => t.Tag.Name).ToArray()),
                        Players = y.Purchases.Count
                    })
                    .OrderByDescending(y => y.Players)
                    .ThenBy(y => y.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();


            var contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new DefaultNamingStrategy()
			};

			var options = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				ContractResolver = contractResolver
			};

			var gamesJson = JsonConvert.SerializeObject(games, options);

			return gamesJson;
		}

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(c => c.Purchases.Any()))
                .Select(x => new UserOutputModel
                {
                    Username = x.Username,
                    Purchases = context
                    .Purchases
                    .Where(p => p.Card.User.Username == x.Username && p.Type == purchaseTypeEnum)
                    .OrderBy(p => p.Date)
                    .Select(p => new PurchaseOutputtModel
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameOutputModel
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    }).ToArray(),
                    TotalSpent = context
                    .Purchases
                    .Where(p => p.Card.User.Username == x.Username && p.Type == purchaseTypeEnum)             
                    .Sum(p => p.Game.Price)
                })
                .Where(x => x.Purchases.Count() > 0)
                .OrderByDescending(x=>x.TotalSpent)
                .ThenBy(x=>x.Username)         
                .ToArray();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            var serializer = new XmlSerializer(typeof(UserOutputModel[]), xRoot);


            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
	}
}