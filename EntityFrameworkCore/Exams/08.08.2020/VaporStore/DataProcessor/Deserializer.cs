namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesJson = JsonConvert.DeserializeObject<ICollection<GameInputModel>>(jsonString);

            List<Game> games = new List<Game>();

            foreach (var game in gamesJson)
            {
                if (!IsValid(game))
                {
                    sb.AppendLine(Configuration.ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                var isValidReleaseDate = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isValidReleaseDate)
                {
                    sb.AppendLine(Configuration.ErrorMessage);
                    continue;
                }
                var genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = game.Genre
                    };
                    context.Genres.Add(genre);
                    context.SaveChanges();
                }



                var developer = context.Developers.FirstOrDefault(x => x.Name == game.Developer);
                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = game.Developer
                    };
                    context.Developers.Add(developer);
                    context.SaveChanges();
                }


                var gameDb = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tag in game.Tags)
                {
                    var tagDb = context.Tags.FirstOrDefault(x => x.Name == tag);

                    if (tagDb == null)
                    {
                        tagDb = new Tag()
                        {
                            Name = tag
                        };

                        context.Tags.Add(tagDb);
                        context.SaveChanges();
                    }

                    var gameTag = new GameTag()
                    {
                        Tag = tagDb,
                        Game = gameDb
                    };

                    gameDb.GameTags.Add(gameTag);
                }
                sb.AppendLine(String.Format(Configuration.SuccesfullMessage, gameDb.Name, game.Genre, gameDb.GameTags.Count));
                games.Add(gameDb);
            }

            context.Games.AddRange(games);
            context.SaveChanges();



            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersJson = JsonConvert.DeserializeObject<ICollection<UserInputModel>>(jsonString);

            List<User> users = new List<User>();

            foreach (var user in usersJson)
            {
                if (!IsValid(user))
                {
                    sb.AppendLine(Configuration.ErrorMessage);
                    continue;
                }

                var userDb = new User()
                {
                    Username = user.Username,
                    FullName = user.FullName,
                    Age = user.Age,
                    Email = user.Email
                };
                bool isCardsValid = true;
                foreach (var card in user.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine(Configuration.ErrorMessage);
                        isCardsValid = false;
                        break;
                    }

                    var cardDb = new Card()
                    {
                        Number = card.Number,
                        Cvc = card.CVC,
                        Type = card.Type
                    };

                    userDb.Cards.Add(cardDb);

                }
                if (!isCardsValid)
                {
                    continue;
                }
                users.Add(userDb);
                sb.AppendLine(String.Format(Configuration.SuccesfullUser, userDb.Username, userDb.Cards.Count()));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Purchases";
            var serializer = new XmlSerializer(typeof(List<PurchaseInputModel>), xRoot);
            var purchasesDto = (List<PurchaseInputModel>)serializer.Deserialize(new StringReader(xmlString));

            var purchases = new List<Purchase>();

            foreach (var purchase in purchasesDto)
            {
                if (!IsValid(purchase))
                {
                    sb.AppendLine(Configuration.ErrorMessage);
                    continue;
                }

                var purchaseDb = new Purchase()
                {
                    ProductKey = purchase.ProductKey,
                    Date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = purchase.Type,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchase.Card),
                    Game = context.Games.FirstOrDefault(x => x.Name == purchase.Title)
                };

                var username = context.Users.FirstOrDefault(x => x.Cards.Any(c => c.Number == purchase.Card)).Username;
                purchases.Add(purchaseDb);
                sb.AppendLine($"Imported {purchase.Title} for {username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}